using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Windows.Forms;

namespace MSMQT
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtRequest.Text.Trim()))
            {
                MessageBox.Show("请先输入传入参数！！");
                return;
            }
            //string queuePath = "FormatName:Direct=TCP:192.168.102.188\\private$\\queue";//@".\private$\lxf";
            //string queuePath = "FormatName:Direct=TCP:192.168.102.188\\mqueue";//@".\private$\lxf"
            MessageQueue mQueue = new MessageQueue();
            mQueue.Path = txtURL.Text.Trim();//queuePath;
            System.Messaging.Message msg = new System.Messaging.Message();
            msg.Formatter = new XmlMessageFormatter(new Type[]{typeof(string)});
            msg.Recoverable = true;//存储本地，防止消息丢失
            msg.Label = "这是远程发送的消息";
            msg.Body = txtRequest.Text.Trim();
            msg.Priority = MessagePriority.High;
            msg.UseJournalQueue = true;//本地日志保存
            mQueue.Send(msg);
            MessageBox.Show("成功");

            ;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtResponse.Text = "";
            //string queuePath = "FormatName:Direct=TCP:192.168.102.188\\private$\\queue";//@".\private$\lxf";
            //List<string> sMessage = QueueManger.GetAllMessage<string>(queuePath);
            //string sMessage = QueueManger.ReceiveMessage<string>(queuePath);
            //txtResponse.Text = sMessage;

            try
            {
                string queuePath = txtURL.Text.Trim();
                MessageQueue mQueue = new MessageQueue(queuePath,QueueAccessMode.ReceiveAndAdmin);
                mQueue.Formatter = new XmlMessageFormatter(new Type[]{typeof(string)});
                Trustee trustee = new Trustee();
                //trustee.TrusteeType = TrusteeType.Group;
                //MessageQueuePermission mp = new MessageQueuePermission(MessageQueuePermissionAccess.Receive, queuePath);
                System.Messaging.Message msg = mQueue.Peek();
                txtResponse.Text = msg.Body.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
    }
}

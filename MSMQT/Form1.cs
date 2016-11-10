using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;

namespace MSMQT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //http://www.cnblogs.com/shaoshun/p/3800655.html
        //http://dev.yesky.com/229/8196229_2.shtml
        //消息队列 创建 发送 获取 及 事务
        public void Show()
        {
            string queuePath = @".\private$\lxf";
            bool isPass = QueueManger.Createqueue(queuePath);//创建队列
            if (isPass == true)
            {
                Student student = new Student();
                student.Name = "風2014";
                student.Age = 25;
                isPass = QueueManger.SendMessage<Student>(student, queuePath);//发送消息到队列
                if (isPass == true)
                {
                    //Student s = QueueManger.ReceiveMessageByPeek<Student>(queuePath);//采用Peek方法接收消息
                    //Student s = QueueManger.ReceiveMessage<Student>(queuePath);//采用Receive方法来接收消息
                    //MessageBox.Show(s.Name);

                    MessageQueueTransaction tran = new MessageQueueTransaction();
                    tran.Begin();
                    try
                    {
                        Student stu;
                        for (int i = 0; i < 4; i++)
                        {
                            stu = new Student() { Name = "shaoshun" + i, Age = i };
                            QueueManger.SendMessage<Student>(stu, queuePath, tran);
                            if (i == 3)
                            {
                                throw new Exception();
                            }
                        }
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Abort();
                    }
                }
            }

            //MessageBox.Show(isPass.ToString());
        }

        //事务消息的发送和接收
        public void Show2()
        {
            //发送 事务消息
            string queuePath = @".\private$\lxfSW";
            QueueManger.Createqueue(queuePath, true);
            //MessageQueueTransaction myTransaction = new MessageQueueTransaction();
            //myTransaction.Begin();
            //Student stu1 = new Student(){Name="张三",Age=21};
            //Student stu2 = new Student(){Name="历史",Age=27};
            //List<Student> list = new List<Student>();
            //list.Add(stu1);
            //list.Add(stu2);
            //bool isPass = QueueManger.SendMessage<List<Student>>(list, queuePath, myTransaction);
            //myTransaction.Commit();
            //MessageBox.Show(isPass.ToString());

            //接收 事务消息
            //string sMessage = string.Empty;
            //MessageQueueTransaction myTransaction = new MessageQueueTransaction();
            //myTransaction.Begin();
            //List<Student> listB = QueueManger.ReceiveMessage<List<Student>>(queuePath, myTransaction);
            //foreach(Student s in listB)
            //{
            //    sMessage += s.Name + ",";
            //}
            //myTransaction.Commit();
            //MessageBox.Show(sMessage);
        }

        //异步消息队列
        public void Show3()
        {
            //发送消息
            string queuePath = @".\private$\lxfAsync";
            MessageQueueTransaction myTransaction = new MessageQueueTransaction();
            QueueManger.Createqueue(queuePath, true);
            Student stuM = new Student() { Name = "KKM", Age = 29 };
            myTransaction.Begin();
            QueueManger.SendMessage<Student>(stuM, queuePath, myTransaction);
            myTransaction.Commit();

            //异步接收消息
            MessageQueueTransaction myTransactionB = new MessageQueueTransaction();
            MessageQueue myQueue = new MessageQueue(queuePath);
            myQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(MyReceiveCompleted);
            myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(Student) });
            myTransactionB.Begin();
            myQueue.BeginReceive();
            myTransactionB.Commit();
        }

        public void MyReceiveCompleted(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue myQueue = (MessageQueue)source;
            //完成指定的异步接收操作 
            System.Messaging.Message message = myQueue.EndReceive(asyncResult.AsyncResult);
            myQueue.BeginReceive();
            MessageBox.Show(((Student)message.Body).Name);
        }

        //将邮件信息发送到消息队列中
        private void btnSend_Click(object sender, EventArgs e)
        {
            MailInfo mi = new MailInfo();
            mi.StmpServer = txtSMTP.Text.Trim();
            mi.SendAddress = txtFJRDZ.Text.Trim();
            mi.SendPwd = txtFJRMM.Text.Trim();
            mi.ReceiveAddress = txtSJRDZ.Text.Trim();
            mi.Title = txtYJZT.Text.Trim();
            mi.Content = txtYJZW.Text.Trim();
            if (mi != null)
            {
                string queuePath = @".\private$\lxfMail";
                
                bool isPass = QueueManger.Createqueue(queuePath);//创建队列
                if (isPass == true)
                {
                    isPass = QueueManger.SendMessage<MailInfo>(mi, queuePath);//发送消息到队列
                    if (isPass == true)
                    {
                        MessageBox.Show("成功");
                    }
                    else
                    {
                        MessageBox.Show("失败");
                    }
                }
            }
        }

        //将消息队列中的邮件发送到邮箱中
        private void btnAllSend_Click(object sender, EventArgs e)
        {
            string queuePath = @".\private$\lxfMail";
            //List<MailInfo> listMail = QueueManger.GetAllMessage<MailInfo>(queuePath);
            //foreach (MailInfo mi in listMail)
            //{
            //    //MessageBox.Show(mi.Content);
            //    bool isPass = SendMail(mi);
            //    if (isPass == true)
            //    {
            //    }
            //}

            MessageQueue myQueue = new MessageQueue(queuePath);
            myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(MailInfo) });
            MessageEnumerator enumerator = myQueue.GetMessageEnumerator2();
            while (enumerator.MoveNext())
            {
                MailInfo mi = (MailInfo)enumerator.Current.Body;
                bool isPass = SendMail(mi);
                if (isPass == true)
                {
                    //enumerator.RemoveCurrent();
                    myQueue.ReceiveById(enumerator.Current.Id);
                }
                MessageBox.Show(mi.Content);
            }
        }

        //邮件服务
        private bool SendMail(MailInfo mi)
        {
            SmtpClient client = new SmtpClient();
            client.Host = mi.StmpServer;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(mi.SendAddress, mi.SendPwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Timeout = 1000000;

            MailMessage message = new MailMessage(mi.SendAddress, mi.ReceiveAddress);
            message.Subject = mi.Title;
            message.Body = mi.Content;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            if(mi.attachment != null && mi.attachment.ContentStream.Length > 0)
            {
                message.Attachments.Add(mi.attachment);
            }

            try
            {
                client.Send(message);
                MessageBox.Show("邮件已发送到：" + mi.ReceiveAddress);
                txtFJ.Text = "";
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("邮件发送失败：{0}。失败原因：{1}", mi.ReceiveAddress, ex.Message));
                return false;
            }
            finally
            {
                foreach (Attachment item in message.Attachments)
                {
                    item.Dispose();   //一定要释放该对象,否则无法删除附件
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailInfo mi = new MailInfo();
            mi.StmpServer = txtSMTP.Text.Trim();
            mi.SendAddress = txtFJRDZ.Text.Trim();
            mi.SendPwd = txtFJRMM.Text.Trim();
            mi.ReceiveAddress = txtSJRDZ.Text.Trim();
            mi.Title = txtYJZT.Text.Trim();
            mi.Content = txtYJZW.Text.Trim();

            //添加附件
            string file = txtFJ.Text.Trim() ;
            if(!string.IsNullOrEmpty(file))
            {
                Attachment data = new Attachment(file, System.Net.Mime.MediaTypeNames.Application.Octet);
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(file);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                mi.attachment = data;
            }
            
            bool isPass = SendMail(mi);
            MessageBox.Show(isPass.ToString());
        }

        //附件
        private void btnFJ_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "所有文件(*.*)|*.*";
            openFileDialog1.InitialDirectory = @"D:\\";
            openFileDialog1.RestoreDirectory = false;
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFJ.Text = openFileDialog1.FileName;
            }
        }

        private void txtYJZW_DoubleClick(object sender, EventArgs e)
        {
            txtYJZW.SelectAll();
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class MailInfo
    {
        public string StmpServer { get; set; }
        public string SendAddress { get; set; }
        public string SendPwd { get;set;}
        public string ReceiveAddress { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        //邮件附件
        public Attachment attachment { get; set; }
    }
}

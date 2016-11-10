using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;

namespace MSMQT
{
    public class QueueManger
    {
        /// <summary>
        /// 创建MSMQ队列
        /// </summary>
        /// <param name="queuePath">队列路径</param>
        /// <param name="transactional">是否事务队列</param>
        public static bool Createqueue(string queuePath, bool transactional = false)
        {
            try
            {
                //判断队列是否存在
                if (!MessageQueue.Exists(queuePath))
                {
                    MessageQueue.Create(queuePath, transactional);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 删除队列
        /// </summary>
        /// <param name="queuePath">队列路径</param>
        public static bool Deletequeue(string queuePath)
        {
            try
            {
                //判断队列是否存在
                if (MessageQueue.Exists(queuePath))
                {
                    MessageQueue.Delete(queuePath);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <typeparam name="T">用户数据类型</typeparam>
        /// <param name="target">用户数据</param>
        /// <param name="queuePath">队列路径</param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public static bool SendMessage<T>(T target, string queuePath, MessageQueueTransaction tran = null)
        {
            try
            {
                //连接到本地的队列
                MessageQueue myQueue = new MessageQueue(queuePath);
                Message myMessage = new Message();
                myMessage.Body = target;
                myMessage.Formatter = new XmlMessageFormatter(new Type[] { typeof(T) });
                //发送消息到队列中
                if (tran == null)
                {
                    myQueue.Send(myMessage);
                }
                else
                {
                    myQueue.Send(myMessage, tran);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <typeparam name="T">用户的数据类型</typeparam>
        /// <param name="queuePath">队列路径</param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public static T ReceiveMessage<T>(string queuePath, MessageQueueTransaction tran = null)
        {
            try
            {
                //连接到本地队列
                MessageQueue myQueue = new MessageQueue(queuePath);
                myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(T) });
                //从队列中接收消息
                Message myMessage = tran == null ? myQueue.Receive() : myQueue.Receive(tran);
                return (T)myMessage.Body;
            }
            catch (Exception)
            {
                
            }
            return default(T);
        }

        /// <summary>
        /// 采用Peek方法接收消息
        /// </summary>
        /// <typeparam name="T">用户数据类型</typeparam>
        /// <param name="queuePath">队列路径</param>
        /// <returns></returns>
        public static T ReceiveMessageByPeek<T>(string queuePath)
        {
            try
            {
                //连接到本地队列
                MessageQueue myQueue = new MessageQueue(queuePath);
                myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(T) });
                Message myMessage = myQueue.Peek();
                return (T)myMessage.Body;
            }
            catch (Exception)
            {
                
            }
            return default(T);
        }

        /// <summary>
        /// 获取队列中的所有消息
        /// </summary>
        /// <typeparam name="T">用户数据类型</typeparam>
        /// <param name="queuePath">队列路径</param>
        /// <returns></returns>
        public static List<T> GetAllMessage<T>(string queuePath)
        {
            try
            {
                MessageQueue myQueue = new MessageQueue(queuePath);
                myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(T) });
                Message[] msgArr = myQueue.GetAllMessages();
                List<T> list = new List<T>();
                msgArr.ToList().ForEach((o) =>
                {
                    list.Add((T)o.Body);
                });
                return list;
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }

        //public static List<T> GetAllMessage2<T>(string queuePath)
        //{
        //    MessageQueue myQueue = new MessageQueue(queuePath);

        //}

    }
}

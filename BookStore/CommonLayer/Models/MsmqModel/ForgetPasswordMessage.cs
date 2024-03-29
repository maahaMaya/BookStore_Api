﻿using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;
using Experimental.System.Messaging;

namespace CommonLayer.Models.MsmqModel
{
    public class ForgetPasswordMessage
    {
      MessageQueue messageQueue = new MessageQueue();
        public void sendData2Queue(string token)
        {
            messageQueue.Path = @".\private$\FunDoNote";
            if (!MessageQueue.Exists(messageQueue.Path))
            {
                MessageQueue.Create(messageQueue.Path);
            }
            messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            messageQueue.ReceiveCompleted += Mq_ReceiveCompleted;
            messageQueue.Send(token);
            messageQueue.BeginReceive();
            messageQueue.Close();
        }
        private void Mq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e) // event 
        {
            var message = messageQueue.EndReceive(e.AsyncResult);
            string token = message.Body.ToString();
            string subject = "Forgot Passwoord";
            string body = token;
            var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("12sourav12s@gmail.com", "dfppgqmykelndmvx"),
                EnableSsl = true,
            };
            smtp.Send("12sourav12s@gmail.com", "12sourav12s@gmail.com", subject, body);
            messageQueue.BeginReceive();
        }
    }
}

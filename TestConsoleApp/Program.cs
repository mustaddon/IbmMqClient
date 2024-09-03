using com.ibm.msg.client.jms;
using com.ibm.msg.client.wmq.common;
using javax.jms;
using System;

namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ff = JmsFactoryFactory.getInstance(JmsConstants.WMQ_PROVIDER);
            var cf = ff.createConnectionFactory();

            cf.setIntProperty(CommonConstants.WMQ_CONNECTION_MODE, CommonConstants.WMQ_CM_CLIENT);
            cf.setStringProperty(CommonConstants.WMQ_HOST_NAME, "127.0.0.1");
            cf.setIntProperty(CommonConstants.WMQ_PORT, 8010);
            cf.setStringProperty(CommonConstants.WMQ_CHANNEL, "EXAMPLE.CHANNEL.ONE");
            cf.setStringProperty(CommonConstants.WMQ_QUEUE_MANAGER, "EXAMPLE_QUEUE_MANAGER");
            cf.setStringProperty(CommonConstants.WMQ_APPLICATIONNAME, "JMS EXAMPLE");
            cf.setStringProperty(CommonConstants.USERID, "EXAMPLE_USER");

            using var context = cf.createContext();
            var queue = context.createQueue("queue:///EXAMPLE_QUEUE_NAME");

            // sending
            var producer = context.createProducer();
            producer.send(queue, "Hello World");

            // receiving
            var consumer = context.createConsumer(queue);
            Message message;
            while ((message = consumer.receiveNoWait()) != null)
                Console.WriteLine(message.getBody(typeof(string)));
        }
    }
}

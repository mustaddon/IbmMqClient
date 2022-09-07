using com.ibm.msg.client.jms;
using com.ibm.msg.client.wmq.common;

namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ff = JmsFactoryFactory.getInstance(JmsConstants.__Fields.WMQ_PROVIDER);
            var cf = ff.createConnectionFactory();

            cf.setIntProperty(CommonConstants.__Fields.WMQ_CONNECTION_MODE, CommonConstants.__Fields.WMQ_CM_CLIENT);
            cf.setStringProperty(CommonConstants.__Fields.WMQ_HOST_NAME, "127.0.0.1");
            cf.setIntProperty(CommonConstants.__Fields.WMQ_PORT, 8010);
            cf.setStringProperty(CommonConstants.__Fields.WMQ_CHANNEL, "EXAMPLE.CHANNEL.ONE");
            cf.setStringProperty(CommonConstants.__Fields.WMQ_QUEUE_MANAGER, "EXAMPLE_QUEUE_MANAGER");
            cf.setStringProperty(CommonConstants.__Fields.WMQ_APPLICATIONNAME, "JMS EXAMPLE");
            cf.setStringProperty(CommonConstants.USERID, "EXAMPLE_USER");

            using (var context = cf.createContext())
            {
                var queue = context.createQueue("queue:///EXAMPLE_QUEUE_NAME");
                var producer = context.createProducer();
                producer.send(queue, "Hello World");
            }
        }
    }
}

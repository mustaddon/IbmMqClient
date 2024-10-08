# IbmMqClient  [![NuGet version](https://badge.fury.io/nu/IbmMqClient.svg)](http://badge.fury.io/nu/IbmMqClient)
IBM MQ standalone client for .NET (converted official java client v9.0 via IKVM)


*.NET CLI*
```cli
dotnet new console --name "IbmMqClientExample"
cd IbmMqClientExample
dotnet add package IbmMqClient -v 9.0.4
```

*Program.cs:*
```C#
using com.ibm.msg.client.jms;
using com.ibm.msg.client.wmq.common;


var ff = JmsFactoryFactory.getInstance(JmsConstants.WMQ_PROVIDER);
var cf = ff.createConnectionFactory();

cf.setIntProperty(CommonConstants.WMQ_CONNECTION_MODE, CommonConstants.WMQ_CM_CLIENT);
cf.setStringProperty(CommonConstants.WMQ_HOST_NAME, "127.0.0.1");
cf.setIntProperty(CommonConstants.WMQ_PORT, 8010);
cf.setStringProperty(CommonConstants.WMQ_CHANNEL, "EXAMPLE.CHANNEL.ONE");
cf.setStringProperty(CommonConstants.WMQ_QUEUE_MANAGER, "EXAMPLE_QUEUE_MANAGER");
cf.setStringProperty(CommonConstants.WMQ_APPLICATIONNAME, "JMS EXAMPLE");
cf.setStringProperty(CommonConstants.USERID, "EXAMPLE_USER");

using (var context = cf.createContext())
{
    var queue = context.createQueue("queue:///EXAMPLE_QUEUE_NAME");
    var producer = context.createProducer();
    producer.send(queue, "Hello World");
}
```
[Program.cs](https://github.com/mustaddon/IbmMqClient/blob/master/TestConsoleApp/Program.cs)

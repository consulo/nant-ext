using System;
using org.mustbe.consulo.ant.core.message;
using Thrift.Protocol;
using Thrift.Transport;

namespace NAnt.Consulo.Ext
{
    public class ConsuloConnector
    {
        private static ConsuloConnector myInstance;

        private TSocket mySocket;
        private MessageService.Client myClient;

        public static ConsuloConnector Instance
        {
            get
            {
                return myInstance = myInstance ?? new ConsuloConnector();
            }
        }

        private ConsuloConnector()
        {
            try
            {
                String port = Environment.GetEnvironmentVariable("TO_CONSULO_NANT_PORT");
                mySocket = new TSocket("localhost", Int32.Parse(port));
                myClient = new MessageService.Client(new TBinaryProtocol(mySocket));
                mySocket.Open();
            }
            catch
            {
            }
        }

        public void BuildStarted(int priority)
        {
            if (myClient != null)
            {
                myClient.buildStarted(priority);
            }
        }

        public void BuildFinished(int priority, String exception)
        {
            if (myClient != null)
            {
                myClient.buildFinished(priority, exception);
            }
        }

        public void TaskStarted(int priority, String task)
        {
            if (myClient != null)
            {
                myClient.taskStarted(priority, task);
            }
        }

        public void TargetStarted(int priority, String target)
        {
            if (myClient != null)
            {
                myClient.targetStarted(priority, target);
            }
        }

        public void TargetFinished(int priority, string exception)
        {
            if (myClient != null)
            {
                myClient.targetFinished(priority, exception);
            }
        }

        public void TaskFinished(int priority, string exception)
        {
            if (myClient != null)
            {
                myClient.taskFinished(priority, exception);
            }
        }

        public void LogInfo(int priority, string message)
        {
            if (myClient != null)
            {
                myClient.logInfo(priority, message);
            }
        }

        public void LogError(int priority, string message)
        {
            if (myClient != null)
            {
                myClient.logError(priority, message);
            }
        }
    }
}

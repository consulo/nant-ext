using System;
using NAnt.Core;

namespace NAnt.Consulo.Ext
{
    public class ToConsuloLogger : DefaultLogger
    {
        public override void BuildStarted(object sender, BuildEventArgs e)
        {
            ConsuloConnector.Instance.BuildStarted((int)e.MessageLevel);
        }

        public override void BuildFinished(object sender, BuildEventArgs e)
        {
            ConsuloConnector.Instance.BuildFinished((int)e.MessageLevel, GetExceptionText(e));
        }

        public override void TaskStarted(object sender, BuildEventArgs e)
        {
            ConsuloConnector.Instance.TaskStarted((int)e.MessageLevel, e.Task.Name);
        }

        public override void TaskFinished(object sender, BuildEventArgs e)
        {
            ConsuloConnector.Instance.TaskFinished((int)e.MessageLevel, GetExceptionText(e));
        }

        public override void TargetStarted(object sender, BuildEventArgs e)
        {
            ConsuloConnector.Instance.TargetStarted((int)e.MessageLevel, e.Target.Name);
        }

        public override void TargetFinished(object sender, BuildEventArgs e)
        {
            ConsuloConnector.Instance.TargetFinished((int)e.MessageLevel, GetExceptionText(e));
        }

        public override void MessageLogged(object sender, BuildEventArgs e)
        {
            if (e.MessageLevel == Level.Error)
            {
                ConsuloConnector.Instance.LogError((int)e.MessageLevel, e.Message);
            }
            else
            {
                ConsuloConnector.Instance.LogInfo((int)e.MessageLevel, e.Message);
            }
        }

        private String GetExceptionText(BuildEventArgs e)
        {
            Exception ex = e.Exception;
            if (ex != null)
            {
                return ex.StackTrace;
            }
            return null;
        }
    }
}

using System.Diagnostics;
using System.ServiceProcess;

namespace HelloService
{
    class Program
    {
        static void Main(string[] args) {
            ServiceBase.Run(new UserService1());
        }
    }

    public class UserService1 : ServiceBase
    {
        const string sourceName = "MyHelloService";

        public UserService1() {
            this.ServiceName = "MyHelloService";
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }
        protected override void OnStart(string[] args) {
            base.OnStart(args);
        }
        protected override void OnSessionChange(SessionChangeDescription changeDescription) {
            if (changeDescription.Reason == SessionChangeReason.SessionLock) {
                WriteEntry("Hello");
            }
            base.OnSessionChange(changeDescription);
        }

        void WriteEntry(string entry) {
            if (!System.Diagnostics.EventLog.SourceExists(sourceName)) {
                string myLogName = "myLogName";
                EventSourceCreationData mySourceData = new EventSourceCreationData(sourceName, myLogName);
                EventLog.CreateEventSource(mySourceData);
            }
            EventLog.WriteEntry(sourceName, message:entry, EventLogEntryType.Information);
        }
    }
}

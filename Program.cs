using System;
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
        public UserService1() {
            this.ServiceName = "MyHelloService";
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }
        protected override void OnStart(string[] args) {
            base.OnStart(args);
        }
    }
}

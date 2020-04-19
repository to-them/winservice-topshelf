using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ConsoleApp_Service
{
    internal static class ConfigureService
    {
        internal static void Configure()
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<SimpleTimerService>(s =>
                {
                    s.ConstructUsing(timerservice => new SimpleTimerService());
                    s.WhenStarted(timerservice => timerservice.Start());
                    s.WhenStopped(timerservice => timerservice.Stop());
                });

                //Set account that windows service to run at
                x.RunAsLocalSystem();

                x.SetServiceName("ConsoleApp-Service");
                x.SetDisplayName("Ayitech Simple Timer Windows Service");
                x.SetDescription("This is a simple timer windows service.");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}

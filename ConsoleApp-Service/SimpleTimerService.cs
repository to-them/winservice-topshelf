using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp_Service
{
    public class SimpleTimerService
    {
        private readonly Timer _timer;

        public SimpleTimerService()
        {
            _timer = new Timer(5000) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            // write code here that runs when the time elapsed
            string[] lines = new string[] { DateTime.Now.ToString() + ": A message from Simple Timer Service..." };
            File.AppendAllLines(@"C:\Temp\Demo\SimpleTimerService.txt", lines);
        }

        public void Start()
        {
            // write code here that runs when the Windows Service starts up. 
            _timer.Start();
        }

        public void Stop()
        {
            // write code here that runs when the Windows Service stops.
            _timer.Stop();
        }

    }
}

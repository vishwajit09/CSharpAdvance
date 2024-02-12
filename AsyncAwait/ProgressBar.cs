using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class ProgressBar
    {
        public int Progress { get; set; }

        public async Task<Task> ProgressBarProgress()
        {
            while (true)
            {


                if (Progress >= 100)
                {
                    // break;
                    return Task.CompletedTask;
                }
                else
                {
                    Console.WriteLine($"[{Progress}%]");
                    await Task.Delay(3000);
                }
            }


        }

        public async Task<Task> AddProgress()
        {
            while (true)
            {
                Progress += 1;
                Console.WriteLine(Progress);
                await Task.Delay(1000);
                if (Progress > 100)
                {
                    //break; 
                    return Task.CompletedTask;
                }
            }


        }

        public async Task Readfiles()
        {
            string[] Files = System.IO.Directory.GetFiles(@"C:\Users\Visat\OneDrive\Desktop\");
            foreach (string sFile in Files)
            {
                Task.Delay(5000).Wait();
                await Console.Out.WriteLineAsync(sFile);

            }
        }
    }
}

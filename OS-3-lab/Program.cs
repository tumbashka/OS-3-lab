using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_3_lab
{
    class Program
    {
        static Random rand = new Random((int)DateTime.Now.Ticks);
        static void Main(string[] args)
        {
            OperatingSystem operatingSystem = new OperatingSystem(256, 64);
            for (int processId = 0; processId < rand.Next(1, 5); processId++)
            {
                operatingSystem.addProcess();
                for (int pageId = 0; pageId < operatingSystem.getProcess(processId).getCountPages(); pageId++)
                {
                    operatingSystem.addPage(processId);
                }
                operatingSystem.printMemory();
            }
            operatingSystem.printMemory();
            Console.ReadKey();
        }
    }
}

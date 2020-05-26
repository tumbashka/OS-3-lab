using System;
using System.Collections.Generic;
using System.Text;

namespace OS_3_lab
{
    public class OperatingSystem
    {
        static Random rand = new Random((int)DateTime.Now.Ticks);
        private Memory memory;
        private MemoryManagement MM;
        private List<Process> processes;
        private List<Page> pages;
        public OperatingSystem(int memorySize, int pageSize)
        {
            memory = new Memory(memorySize, pageSize);
            MM = new MemoryManagement();
            processes = new List<Process>();
            pages = new List<Page>();
        }
        public void addProcess()
        {
            Process process = new Process(this.processes.Count, rand.Next(1, 5));
            this.processes.Add(process);
            Console.WriteLine("Creating a new process " + process.getId() + " requiring " + process.getCountPages() + " pages");
        }
        public Process getProcess(int processId)
        {
            foreach (Process process in this.processes)
            {
                if (process.getId() == processId)
                {
                    return process;
                }
            }
            return null;
        }
        public void addPage(int processId)
        {
            Process process = this.getProcess(processId);
            if (process != null)
            {
                int pageId = this.MM.addPage(process);
                this.getPage(processId, pageId);
                Console.WriteLine("Creating page " + pageId + " for process " + process.getId());
            }
        }
        public void getPage(int processId, int pageId)
        {
            Process process = this.getProcess(processId);
            if (process != null)
            {
                if (process.getPagesIds().Contains(pageId))
                {
                    this.MM.getPage(pageId, memory, pages);
                    Console.WriteLine("Process " + process.getId() + " requested page " + pageId);
                }
                else
                {
                    Console.WriteLine("У процесса " + process.getId() + " нет страницы " + pageId);
                }
            }
        }
        public void printMemory()
        {
            Console.WriteLine("Operating memory:");
            Console.WriteLine("   Page   Process   Recourse  ");
            for (int pageId = 0; pageId < memory.getPagesCount(); pageId++)
            {
                Page page = memory.getPage(pageId);
                if (page == null)
                {
                    Console.WriteLine(" |    " + pageId);
                }
                else
                {
                    Process process = this.getProcess(page.getProcessId());
                    Console.WriteLine(" |    " + pageId + " |    " + process.getId() + " |    " + page.isRecourse().ToString());
                }
            }
        }
    }
}

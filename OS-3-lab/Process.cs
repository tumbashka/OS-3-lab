using System;
using System.Collections.Generic;
using System.Text;

namespace OS_3_lab
{
    public class Process
    {
        private int id;
        private int countPages;
        private List<int> pagesIds;
        private List<Page> processes;


        public Process(int id, int countPages)
        {
            this.id = id;
            this.countPages = countPages;
            this.processes = new List<Page>();
            this.pagesIds = new List<int>();
        }
        public int getCountPages()
        {
            return countPages;
        }
        public int getId()
        {
            return id;
        }
        public List<int> getPagesIds()
        {
            return pagesIds;
        }
        public Page getPage(int pageId)
        {
            return processes[pageId];
        }
        public int addPage(Page page)
        {
            processes.Add(page);
            return processes.IndexOf(page);
        }
    }
}

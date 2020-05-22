using System;
using System.Collections.Generic;
using System.Text;

namespace OS_3_lab
{
    public class Memory
    {
        private Page[] pages;
        public Memory(int memorySize, int pageSize)
        {
            this.pages = new Page[memorySize / pageSize];
        }
        public int getPagesCount()
        {
            return pages.Length;
        }
        public Page getPage(int pageId)
        {
            return this.pages[pageId];
        }
        public void setPage(int pageId, Page page)
        {
            this.pages[pageId] = page;
        }
        public int getEmptyPageId()
        {
            for (int index = 0; index < this.pages.Length; index++)
            {
                if (this.pages[index] == null)
                {
                    return index;
                }
            }
            return -1;
        }
    }
}

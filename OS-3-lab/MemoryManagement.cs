using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OS_3_lab
{
    public class MemoryManagement
    {
        private Process process;
        private List<Page> clock;
        public MemoryManagement() 
        {
            process = new Process(5, 15);
            this.clock = new List<Page>();
        }
        public int addPage(Process process)
        {
            int pageId = this.process.addPage(new Page(process.getId()));
            process.getPagesIds().Add(pageId);
            return pageId;
        }
        public Page getPage(int pageId,Memory memory, List<Page> pages)
        {
            Page page = this.process.getPage(pageId);
            if (page.isPresent())
            {
                page.setRecourse(true);
            }
            else
            {
                int emptyPageId = memory.getEmptyPageId();
                if (emptyPageId != -1)
                {
                    memory.setPage(emptyPageId, page);
                    page.setRecourse(true);
                    page.setPresence(true);
                    page.setPhysicalAddress(emptyPageId);
                    this.clock.Add(page);
                }
                else
                {
                    while (true)
                    {
                        Page replacePage = this.clock[0];
                        clock.RemoveAt(clock.Count - 1);
                        if (replacePage.isRecourse())
                        {
                            replacePage.setRecourse(false);
                            this.clock.Add(replacePage);
                        }
                        else
                        {
                            if (replacePage.getVirtualAddress() != -1)
                            {
                                memory.setPage(replacePage.getPhysicalAddress(), pages[replacePage.getVirtualAddress()]);                                   
                            }
                            else
                            {
                                memory.setPage(replacePage.getPhysicalAddress(), page);
                            }
                            page.setRecourse(true);
                            page.setPresence(true);
                            page.setPhysicalAddress(replacePage.getPhysicalAddress());
                            this.clock.Add(page);
                            replacePage.setPresence(false);
                            replacePage.setVirtualAddress(process.addPage(replacePage));
                            replacePage.setPhysicalAddress(-1);
                            break;
                        }
                    }
                }
            }
            return page;
        }
    }
}

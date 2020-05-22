using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OS_3_lab
{
    public class MemoryManagement
    {
        private Process process;
        private LinkedList<Page>  clock;
        public MemoryManagement()
        {
            process = new Process(5, 15);
            this.clock = new LinkedList<Page>();
        }
        public int addPage(Process process)
        {
            int pageId = this.process.addPage(new Page(process.getId()));
            process.getPagesIds().Add(pageId);
            return pageId;
        }
        public Page getPage(int pageId)
        {
            Page page = this.process.getPage(pageId);
            if (page.isPresent())
            {
                page.setRecourse(true);
            }
            else
            {
                int emptyPageId = OperatingSystem.memory.getEmptyPageId();
                if (emptyPageId != -1)
                {
                    OperatingSystem.memory.setPage(emptyPageId, page);
                    page.setRecourse(true);
                    page.setPresence(true);
                    page.setPhysicalAddress(emptyPageId);
                    this.clock.AddLast(page);
                }
                else
                {
                    while (true)
                    {
                        Page replacePage = this.clock.First.Value;
                        clock.RemoveLast();
                        if (replacePage.isRecourse())
                        {
                            replacePage.setRecourse(false);
                            this.clock.AddLast(replacePage);
                        }
                        else
                        {
                            if (replacePage.getVirtualAddress() != -1)
                            {
                                OperatingSystem.memory.setPage(replacePage.getPhysicalAddress(),
                                      OperatingSystem.returnPage(replacePage.getVirtualAddress()));
                            }
                            else
                            {
                                OperatingSystem.memory.setPage(replacePage.getPhysicalAddress(), page);
                            }
                            page.setRecourse(true);
                            page.setPresence(true);
                            page.setPhysicalAddress(replacePage.getPhysicalAddress());
                            this.clock.AddLast(page);
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

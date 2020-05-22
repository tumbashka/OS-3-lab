using System;
using System.Collections.Generic;
using System.Text;

namespace OS_3_lab
{
    public class Page
    {
        private int processId;
        private int physicalAddress;
        private int virtualAddress;
        private bool recourse;
        private bool presence;

        public Page(int processId)
        {
            this.processId = processId;
            this.physicalAddress = -1;
            this.virtualAddress = -1;
            this.recourse = false;
            this.presence = false;
        }
        public bool isRecourse()
        {
            return recourse;
        }
        public void setRecourse(bool recourse)
        {
            this.recourse = recourse;
        }
        public bool isPresent()
        {
            return presence;
        }
        public void setPresence(bool presence)
        {
            this.presence = presence;
        }
        public int getProcessId()
        {
            return processId;
        }
        public int getPhysicalAddress()
        {
            return physicalAddress;
        }
        public void setPhysicalAddress(int physicalAddress)
        {
            this.physicalAddress = physicalAddress;
        }
        public int getVirtualAddress()
        {
            return virtualAddress;
        }
        public void setVirtualAddress(int virtualAddress)
        {
            this.virtualAddress = virtualAddress;
        }       
    }
}

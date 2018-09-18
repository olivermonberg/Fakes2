using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakes2
{
    public interface IEntryNotification
    {
        void NotifyEntryGranted();
        void NotifyEntryDenied();
    }

    public class EntryNotification : IEntryNotification
    {
        public void NotifyEntryGranted()
        {

        }

        public void NotifyEntryDenied()
        {

        }
    }
}

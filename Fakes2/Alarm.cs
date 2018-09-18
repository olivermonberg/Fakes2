using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakes2
{
    public interface IAlarm
    {
        void RaiseAlarm();
    }
    public class Alarm : IAlarm
    {
        public void RaiseAlarm()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakes2
{
    public class DoorControl
    {
        private readonly IUserValidation _uv;
        private readonly IEntryNotification _en;
        private readonly IDoor _d;
        private readonly IAlarm _a;

        private bool CurrentDoorState = false;

        public DoorControl(IUserValidation uv, IEntryNotification en, IDoor d, IAlarm a)
        {
            _uv = uv;
            _en = en;
            _d = d;
            _a = a;
        }

        public void RequestEntry(string id)
        {
            if(_uv.ValidateEntryRequest(id) == true)
            {
                CurrentDoorState = true;
                _d.Open();
                _en.NotifyEntryGranted();
            }
            else if (_uv.ValidateEntryRequest(id) == false)
            {
                _en.NotifyEntryDenied();
            }
        }

        public void DoorOpened()
        {
            if (CurrentDoorState == false)
            {
                _d.Close();
                _a.RaiseAlarm();
            }
            else if(CurrentDoorState == true)
            {
                _d.Close();
                CurrentDoorState = false;
            }
        }

        public void DoorClosed()
        {
            if(CurrentDoorState == true)
                CurrentDoorState = false;
        }
    }
}

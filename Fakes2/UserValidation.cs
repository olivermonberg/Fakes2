using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakes2
{
    public interface IUserValidation
    {
        bool ValidateEntryRequest(string id);
    }

    public class UserValidation : IUserValidation
    {
        public bool ValidateEntryRequest(string id)
        {
            return false;
        }
    }
}

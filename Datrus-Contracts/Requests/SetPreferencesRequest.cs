using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datrus_Contracts.Requests
{
    public record  SetPreferencesRequest(string clientId,string language, string gender, int minAge, int maxAge);
}

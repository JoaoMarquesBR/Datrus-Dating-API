using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datrus_Contracts.Requests
{
    public record AddUserRequest(string username, string firstName,int age, string religion, string firstLanguage, string lastName, string email,string gender);
}

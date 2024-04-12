using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datrus_Contracts.Requests
{
    public record SetImageRequest(string clientId, IFormFile file);
}

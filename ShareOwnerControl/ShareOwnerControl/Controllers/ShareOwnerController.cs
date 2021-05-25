using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShareOwnerControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShareOwnerControl.Controllers
{
    [Route("api/[controller]")]
    public class ShareOwnerController : Controller
    {
        private TransactionServiceDomain _domain;
        public ShareOwnerController(IHttpClientFactory httpClientFactory)
        {
            _domain = new TransactionServiceDomain(httpClientFactory);
        }
    }    
        

   
    

}

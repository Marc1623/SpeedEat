using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using BLL;

namespace WebSpeedEatApp.Controllers
{
    public class DelivererController : Controller
    {
        // GET: Deliverer
        private IConfiguration Configuration { get; }
        public DelivererController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyWorkout.Bll.Services;
using MyWorkout.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyWorkout.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class SubscribeController : Controller
    {
        public SubsrciptionService SubsrciptionService { get; }
       

        public SubscribeController( SubsrciptionService subsrciptionService )
        {
            SubsrciptionService = subsrciptionService;
        }

    }
}

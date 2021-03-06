﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

using Mgnd.Paired.Web.Models;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

using Owin;

namespace Mgnd.Paired.Web.Controllers
{
    [Authorize]
    public class MeController : ApiController
    {
        private ApplicationUserManager userManager;

        public MeController()
        {
        }

        public MeController(ApplicationUserManager userManager)
        {
            this.UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

            private set
            {
                this.userManager = value;
            }
        }

        // GET api/Me
        public GetViewModel Get()
        {
            var user = this.UserManager.FindById(User.Identity.GetUserId());
            return new GetViewModel() { Hometown = user.Hometown };
        }
    }
}
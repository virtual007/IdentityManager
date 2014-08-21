﻿/*
 * Copyright (c) Dominick Baier, Brock Allen.  All rights reserved.
 * see license
 */
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Thinktecture.IdentityManager.Assets;
using Thinktecture.IdentityManager.Api.Filters;
using System.Security.Claims;

namespace Thinktecture.IdentityManager.Api.Controllers
{
    [SecurityHeaders]
    [OverrideAuthorization, Authorize]
    public class PageController : ApiController
    {
        IdentityManagerConfiguration idmConfig;
        public PageController(IdentityManagerConfiguration idmConfig)
        {
            if (idmConfig == null) throw new ArgumentNullException("idmConfig");

            this.idmConfig = idmConfig;
        }

        [HttpGet]
        public IHttpActionResult Index()
        {
            var cp = (ClaimsPrincipal)User;
            return new EmbeddedHtmlResult(Request, "Thinktecture.IdentityManager.Assets.Templates.index.html");
        }
    }
}

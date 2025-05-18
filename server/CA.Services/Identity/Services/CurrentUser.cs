﻿using CA.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Identity.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        private Guid? userId;

        public CurrentUser(IHttpContextAccessor httpContextAccessor = default!)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public Guid? Id
        {
            get
            {
                if (!this.userId.HasValue)
                {
                    var rawUserId = this.httpContextAccessor
                        .HttpContext?
                        .User?
                        .Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?
                        .Value;

                    if(!string.IsNullOrWhiteSpace(rawUserId) && Guid.TryParse(rawUserId, out var parseUserId))
                    {
                        this.userId = parseUserId;
                    }
                }

                return userId;
            }
        }
    }
}

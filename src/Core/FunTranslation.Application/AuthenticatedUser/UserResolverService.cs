using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.AuthenticatedUser
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _context;
        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public int GetUserId()
        {

            //var userIdString = _context.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            string userIdString = null;
            int id = !string.IsNullOrEmpty(userIdString) ? Convert.ToInt32(userIdString) : 1;

            return id;
        }

        public string GetUserName()
        {
            return _context.HttpContext.User?.Identity?.Name;
        }
    }
}

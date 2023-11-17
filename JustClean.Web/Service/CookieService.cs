using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;

namespace JustClean.Web.Service
{
    public class CookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public void SetCookie(string key, int id, int? expireTimeDays = null)
        {
            var options = new CookieOptions
            {
                HttpOnly = true,
                IsEssential = true
            };

            if (expireTimeDays.HasValue)
            {
                options.Expires = DateTime.Now.AddDays(expireTimeDays.Value);
            }

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, id.ToString(), options);
        }

        public int GetCookie(string key)
        {
            var cookieValue = _httpContextAccessor.HttpContext.Request.Cookies[key];

            return string.IsNullOrEmpty(cookieValue) ? -1 : Convert.ToInt32(cookieValue);
        }

        public void DeleteCookie(string key)
        {
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1),
                IsEssential = true, 
                HttpOnly = true
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key, options);
        }
    }
}

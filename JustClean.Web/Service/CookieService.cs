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

        //public void SetCookie<T>(string key, T value, int? expireTimeDays = null)
        //{
        //    var serializedValue = JsonSerializer.Serialize(value);

        //    var options = new CookieOptions
        //    {
        //        HttpOnly = true,
        //        IsEssential = true // Сделайте настройки по своему усмотрению
        //    };

        //    if (expireTimeDays.HasValue)
        //    {
        //        options.Expires = DateTime.Now.AddDays(expireTimeDays.Value);
        //    }

        //    _httpContextAccessor.HttpContext.Response.Cookies.Append(key, serializedValue, options);
        //}

        //public T GetCookie<T>(string key)
        //{
        //    var cookieValue = _httpContextAccessor.HttpContext.Request.Cookies[key];
        //    if (cookieValue != null)
        //    {
        //        return JsonSerializer.Deserialize<T>(cookieValue);
        //    }

        //    return default;
        //}

        public void SetCookie(string key, int id, int? expireTimeDays = null)
        {
            var options = new CookieOptions
            {
                HttpOnly = true,
                IsEssential = true // Сделайте настройки по своему усмотрению
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
    }
}

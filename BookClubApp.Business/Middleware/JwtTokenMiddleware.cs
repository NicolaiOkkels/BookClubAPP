using BookClubApp.Business.Services;

namespace BookClubApp.Business.Middleware
{
    public class JwtTokenMiddleware
    {
        private readonly RequestDelegate _request;


        public JwtTokenMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context, IAuthService authService)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
            // Generate a new JWT token
            var token = authService.GenerateJwtToken();
            context.Request.Headers.Add("Authorization", "Bearer " + token);
            }

            await _request(context);
        }
    }
}
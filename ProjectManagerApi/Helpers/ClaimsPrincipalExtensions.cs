using System.Security.Claims;

namespace ProjectManagerApi.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        // This is an "extension method" that adds GetUserId() to the User object
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirstValue(ClaimTypes.NameIdentifier);
            
            // This line is for older JWT standards, just in case
            if (string.IsNullOrEmpty(userIdClaim))
            {
                userIdClaim = user.FindFirstValue("sub");
            }
            
            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
            {
                throw new InvalidOperationException("User ID not found in token.");
            }
            
            return userId;
        }
    }
}
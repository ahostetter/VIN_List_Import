using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Newmar.Pages
{
    [Authorize(Roles = @"AdamsDesktop\achos")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}

// Can use this in HTML to display only if authorized
//@if(User.Identity.IsAuthenticated)
//{
//
//}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ST.Razor.Web.Pages
{
    [Authorize(Policy= "AdminOnly")]
    public class SettingsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

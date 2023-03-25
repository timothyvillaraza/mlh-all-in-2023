using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using MLHAllinInOne2023.Models;

namespace MLHAllinInOne2023.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class DebugModel : PageModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<DebugModel> _logger;

        private readonly IHttpContextAccessor _contextAccessor;

        public BrowserModel bParser { get; set; }
        public DebugModel(ILogger<DebugModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _contextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            bParser = new BrowserModel(_contextAccessor);
            
            
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
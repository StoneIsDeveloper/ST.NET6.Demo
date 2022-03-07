using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ST.WebAPI.Mini.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogDemoController : Controller
    {
        private readonly ILogger<LogDemoController> logger;

        readonly IDiagnosticContext _diagnosticContext;

        public LogDemoController(ILogger<LogDemoController> logger, IDiagnosticContext diagnosticContext)
        {
            // ILogger is the default logging abstraction built into ASP.NET Core
            this.logger = logger;

            _diagnosticContext = diagnosticContext ??
               throw new ArgumentNullException(nameof(diagnosticContext));

            // Serilog.ILogger is the native logger from serilog.
            // this.serilogLogger = serilogLogger;
        }

        [HttpGet("simple")]
        public IActionResult Get()
        {
            // Log messages with structured content embedded into msg text.
            // The following line uses the ASP.NET core logging abstraction.
            logger.LogInformation("Entered {Controller}.{Method}", nameof(LogDemoController), nameof(Get));

            // The following line demonstrates how we could use serilog's
            // own abstraction. Offers more features than ASP.NET core logging.
           
            return Ok();
        }

        [HttpGet("UserName")]
        public string GetUserName()
        {
            _diagnosticContext.Set("CatalogLoadTime", 2022);
           // _diagnosticContext.Set("UserId", "Li");

            // Log messages with structured content embedded into msg text.
            // The following line uses the ASP.NET core logging abstraction.
            logger.LogInformation("Entered {Controller}.{Method}", nameof(LogDemoController), nameof(Get));

            // The following line demonstrates how we could use serilog's
            // own abstraction. Offers more features than ASP.NET core logging.

            return "STONE";
        }

    }
}

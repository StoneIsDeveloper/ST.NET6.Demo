using Microsoft.AspNetCore.Mvc;

namespace NET6.Web.MVC.Controllers
{
    public class SecondController : Controller
    {
        private readonly ILogger<SecondController> _Logger;
        private readonly ILoggerFactory _LoggerFactory;

        public SecondController(ILogger<SecondController> logger, ILoggerFactory loggerFactory)
        {
            this._Logger = logger;
            this._Logger.LogInformation($"{this.GetType().Name}被构造了。。。_Logger1");
          
            this._LoggerFactory = loggerFactory;
            ILogger<SecondController> _Logger2 = this._LoggerFactory.CreateLogger<SecondController>();
            _Logger2.LogInformation($"{this.GetType().Name} 被构造了。。。_Logger2");
        }


        public IActionResult Index()
        {
            this._Logger.LogInformation($"{this.GetType().Name}Access Second Page。。。_Logger1");
            return View();
        }
    }
}

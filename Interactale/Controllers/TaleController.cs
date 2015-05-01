using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Interactale.Logging;
using Interactale.Repository;

namespace Interactale.Controllers
{
    public class TaleController : Controller
    {
        public IFileLogger FileLogger { get; set; }
        public ITaleRepository TaleRepository { get; private set; }

        public TaleController(IFileLogger fileLogger,
            ITaleRepository taleRepository)
        {
            this.FileLogger = fileLogger;
            this.TaleRepository = taleRepository;
        }

        // GET: Tale
        public ActionResult Test()
        {
            foreach (var tale in TaleRepository.GetTales())
            {
                this.FileLogger.Info("TALE: " + tale.Name);
            }
            return View();
        }
    }
}

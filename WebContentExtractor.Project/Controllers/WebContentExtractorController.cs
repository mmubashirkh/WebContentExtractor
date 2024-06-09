using System.Web.Mvc;
using WebContentExtractor.Project.Mediator;
using WebContentExtractor.Project.Models;

namespace WebContentExtractor.Project.Controllers
{
    public class WebContentExtractorController : Controller
    {
        private IWebContentExtractorMediator _WebContentExtractorMediator;

        public WebContentExtractorController(IWebContentExtractorMediator WebContentExtractorMediator)
        {
            this._WebContentExtractorMediator = WebContentExtractorMediator;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(WebContentModel model)
        {
                if (ModelState.IsValid)
                {
                    model = _WebContentExtractorMediator.GetWebPageModel(model.TargetUrl);
                }
                return View(model);
        }
    }
}
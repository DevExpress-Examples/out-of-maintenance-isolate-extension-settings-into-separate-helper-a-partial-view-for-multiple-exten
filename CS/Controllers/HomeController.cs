using System.Web.Mvc;

namespace GridViewSharePartialHelper.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult GridViewPartial(GridType gridType) {
            object model = null;

            if (gridType == GridType.Invoices)
                model = Invoice.GetData();
            else if (gridType == GridType.Products)
                model = Product.GetData();

            ViewData["gridType"] = gridType;

            return PartialView(model);
        }

        public ActionResult Details(int key) {
            return View(key);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;

namespace SC.Recaptcha.MVC.Sample.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[ValidateRecaptcha]
		public async Task<ActionResult> Index(string dummy)
		{
			if (ModelState.IsValid)
			{
				return RedirectToAction("Checked", "Home");
			}
			else
			{
				List<string> errors = HttpContext.Items["SC.Recaptcha.Errors"] as List<string>;
				if (errors != null && errors.Any())
				{
					// you can get all necessary details about validation problems here
				}
			}

			return View();
		}

		public ActionResult Checked()
		{
			return View();
		}
	}
}

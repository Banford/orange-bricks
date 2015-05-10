using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property
{
    public class PropertyController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public PropertyController(IOrangeBricksContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Seller")]
        public ActionResult Create()
        {
            var viewModel = new CreatePropertyViewModel();

            viewModel.PossiblePropertyTypes = new string[] { "House", "Flat", "Bungalow" }
                .Select(x => new SelectListItem { Value = x, Text = x })
                .AsEnumerable();

            return View(viewModel);
        }

        [Authorize(Roles = "Seller")]
        [HttpPost]
        public ActionResult Create(CreatePropertyCommand command)
        {
            var handler = new CreatePropertyCommandHandler(_context);

            command.SellerUserId = User.Identity.GetUserId();

            handler.Handle(command);

            return RedirectToAction("MyProperties");
        }

        [Authorize(Roles = "Seller")]
        public ActionResult MyProperties()
        {
            return View();
        }
    }
}
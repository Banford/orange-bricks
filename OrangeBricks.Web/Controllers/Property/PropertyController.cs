using System.Collections.Generic;
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
            var builder = new MyPropertiesViewModelBuilder(_context);
            var viewModel = builder.Build(User.Identity.GetUserId());

            return View(viewModel);
        }
    }

    public class MyPropertiesViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MyPropertiesViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public MyPropertiesViewModel Build(string sellerId)
        {
            return new MyPropertiesViewModel
            {
                Properties = _context.Properties
                    .Where(p => p.SellerUserId == sellerId)
                    .Select(p => new PropertyViewModel
                    {
                        StreetName = p.StreetName,
                        Description = p.Description,
                        NumberOfBedrooms = p.NumberOfBedrooms,
                        PropertyType = p.PropertyType
                    })
                    .ToList()
            };
        }
    }

    public class PropertyViewModel
    {
        public string StreetName { get; set; }
        public string Description { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string PropertyType { get; set; }
    }

    public class MyPropertiesViewModel
    {
        public List<PropertyViewModel> Properties { get; set; }
    }
}
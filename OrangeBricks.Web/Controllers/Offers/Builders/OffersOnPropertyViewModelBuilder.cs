using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class OffersOnPropertyViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public OffersOnPropertyViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public OffersOnPropertyViewModel Build(int id)
        {
            return new OffersOnPropertyViewModel();
        }
    }
}
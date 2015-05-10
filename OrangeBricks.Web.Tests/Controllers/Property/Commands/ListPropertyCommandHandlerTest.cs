using System.Data.Entity;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Tests.Controllers.Property.Commands
{
    [TestFixture]
    public class ListPropertyCommandHandlerTest
    {
        private ListPropertyCommandHandler _handler;
        private IOrangeBricksContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
            _context.Properties.Returns(Substitute.For<IDbSet<Models.Property>>());
            _handler = new ListPropertyCommandHandler(_context);
        }

        [Test]
        public void HandleShouldUpdatePropertyToBeListedForSale()
        {
            // Arrange
            var command = new ListPropertyCommand
            {
                PropertyId = 1
            };

            var property = new Models.Property
            {
                Description = "Test Property",
                IsListedForSale = false
            };

            // Act
            _handler.Handle(command);

            // Assert
            _context.Properties.Received(1).Find(1).Returns(property);
            _context.Received(1).SaveChanges();
            Assert.True(property.IsListedForSale);
        }
    }

    public class ListPropertyCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public ListPropertyCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(ListPropertyCommand command)
        {
            
        }
    }

    public class ListPropertyCommand
    {
        public int PropertyId { get; set; }
    }
}

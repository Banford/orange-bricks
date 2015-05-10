using System.Data.Entity;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Tests.Controllers.Property.Commands
{
    [TestFixture]
    public class CreatePropertyCommandHandlerTest
    {
        private CreatePropertyCommandHandler _handler;
        private IOrangeBricksContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
            _context.Properties.Returns(Substitute.For<IDbSet<Models.Property>>());
            _handler = new CreatePropertyCommandHandler(_context);
        }

        [Test]
        public void HandleShouldAddProperty()
        {
            // Arrange
            var command = new CreatePropertyCommand();

            // Act
            _handler.Handle(command);

            // Assert
            _context.Properties.Received(1).Add(Arg.Any<Models.Property>());
        }

        [Test]
        public void HandleShouldAddPropertyWithCorrectPropertyType()
        {
            // Arrange
            var command = new CreatePropertyCommand
            {
                PropertyType = "House"
            };

            // Act
            _handler.Handle(command);

            // Assert
            _context.Properties.Received(1).Add(Arg.Is<Models.Property>(x => x.PropertyType == "House"));
        }

        [Test]
        public void HandleShouldAddPropertyWithCorrectStreetName()
        {
            // Arrange
            var command = new CreatePropertyCommand
            {
                StreetName = "Barnard Road"
            };

            // Act
            _handler.Handle(command);

            // Assert
            _context.Properties.Received(1).Add(Arg.Is<Models.Property>(x => x.StreetName == "Barnard Road"));
        }
    }
}

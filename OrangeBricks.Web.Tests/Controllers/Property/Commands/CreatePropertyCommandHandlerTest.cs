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
        [Test]
        public void HandleShouldAddProperty()
        {
            // Arrange
            var context = Substitute.For<IOrangeBricksContext>();
            context.Properties.Returns(Substitute.For<IDbSet<Models.Property>>());
            var handler = new CreatePropertyCommandHandler(context);

            var command = new CreatePropertyCommand();

            // Act
            handler.Handle(command);

            // Assert
            context.Properties.Received(1).Add(Arg.Any<Models.Property>());
        }
    }
}

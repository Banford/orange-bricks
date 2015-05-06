using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
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

    public class CreatePropertyCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public CreatePropertyCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(CreatePropertyCommand command)
        {
            var property = new Models.Property
            {
               
            };

            _context.Properties.Add(property);
        }
    }

    public class CreatePropertyCommand
    {
    }
}

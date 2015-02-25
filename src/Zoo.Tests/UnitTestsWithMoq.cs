using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Xunit;
using Zoo.Controllers;
using Zoo.Models;

namespace Zoo.Tests
{
    public class UnitTestsWithMoq
    {
        [Fact]
        public void Animal_needs_an_enclosure()
        {
            var mockContext = new Mock<IZooDbContext>();

            var animals = new List<Animal>
            {
                new Animal
                {
                    Id = 1,
                    Name = "Pumba",
                    Enclosure = new Enclosure
                    {
                        Id = 1, Name = "Kenya Room", 
                        Location = "Center", 
                        Environment = "Africa"
                    }
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Animal>>();
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Provider).Returns(animals.Provider);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Expression).Returns(animals.Expression);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.ElementType).Returns(animals.ElementType);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.GetEnumerator()).Returns(animals.GetEnumerator()); 

            mockContext.Setup(x => x.Animals)
                .Returns(mockSet.Object);

            var db = mockContext.Object;
            var controller = new HomeController() { Database = db };

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }
    }
}
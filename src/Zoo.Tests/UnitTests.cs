using System;
using System.Linq;
using System.Web.Mvc;
using Xunit;
using Xunit.Sdk;
using Zoo.Controllers;
using Zoo.Models;

namespace Zoo.Tests
{
    public class UnitTests
    {
        [Fact]
        public void Can_add_an_animal()
        {
            var db = new FakeZooDbContext();

            db.Animals.Add(new Animal {Name = "Simba", EnclosureId = 1, Species = "Lion"});
            db.SaveChanges();

            var animal = db.Animals.Find(1);

            Assert.Equal("Simba", animal.Name);
        }

        [Fact]
        public void Can_add_an_animal_via_a_controller()
        {
            var controller = new AnimalsController {Database = new FakeZooDbContext()};

            var result = controller.Create(new Animal {Name = "Scar", EnclosureId = 1, Species = "Lion"});

            Assert.IsType<RedirectToRouteResult>(result);
            Assert.Equal(1, controller.Database.Animals.Count());
        }

        [Fact]
        public void Can_add_a_keeper()
        {
            using (var db = new FakeZooDbContext())
            {
                db.Keepers.Add(new Keeper() {FirstName = "Ranger", LastName = "Rick"});
                db.SaveChanges();

                var keeper = db.Keepers.Find(1);

                Assert.Equal("Ranger", keeper.FirstName);
            }
        }

        [Fact]
        public void Animal_needs_an_enclosure()
        {
            using (var db = new FakeZooDbContext())
            {
                db.Animals.Add(new Animal { Name = "Mufasa", EnclosureId = 1, Species = "Lion" });
                db.SaveChanges();

                var controller = new HomeController() {Database = db};

                Assert.Throws<NullReferenceException>(() => controller.Index());

                db.Enclosures.Add(new Enclosure());
                db.SaveChanges();

                Assert.Throws<NullReferenceException>(() => controller.Index());

                db.Animals.Find(1).Enclosure = new Enclosure();

                var result = controller.Index();

                Assert.IsType<ViewResult>(result);
            }
        }
    }
}

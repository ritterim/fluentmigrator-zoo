using System.Linq;
using System.Web.Mvc;
using RimDev.Automation.Sql;
using Xunit;
using Zoo.Controllers;
using Zoo.Models;
using Zoo.Models.Migrations;
using Zoo.Models.ViewModels.Home;

namespace Zoo.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void Can_get_animals_using_implicity_relationship_between_animal_and_enclosure()
        {
            using (var sandbox = new LocalDb())
            {
                Runner.MigrateToLatest(sandbox.ConnectionString);

                using (var context = new ZooDbContext(sandbox.ConnectionString))
                {
                    var enclosure = new Enclosure() { Name="Kenya", Location = "Africa", Environment = "Sahara"};
                    var animal = new Animal() {Name = "Nala", Species = "Lion", Enclosure = enclosure};

                    context.Animals.Add(animal);
                    context.SaveChanges();

                    var controller = new HomeController() { Database = context };

                    var result = controller.Index() as ViewResult;
                    var model = result == null ? new IndexViewModel() : result.Model as IndexViewModel;

                    Assert.Equal(1, model.Animals.Count());
                    Assert.Equal("Nala", model.Animals.First().AnimalName);
                }
            }
        }

        [Fact]
        public void can_get_animals_using_explicit_relationship_between_animal_and_enclosure()
        {
            using (var sandbox = new LocalDb())
            {
                Runner.MigrateToLatest(sandbox.ConnectionString);

                using (var context = new ZooDbContext(sandbox.ConnectionString))
                {
                    var enclosure = new Enclosure() { Id = 1, Name = "Kenya", Location = "Africa", Environment = "Sahara" };
                    var animal = new Animal() { Name = "Nala", Species = "Lion", EnclosureId = 1 };

                    context.Animals.Add(animal);
                    context.Enclosures.Add(enclosure);
                    context.SaveChanges();

                    var controller = new HomeController() { Database = context };

                    var result = controller.Index() as ViewResult;
                    var model = result == null ? new IndexViewModel() : result.Model as IndexViewModel;

                    Assert.Equal(1, model.Animals.Count());
                    Assert.Equal("Nala", model.Animals.First().AnimalName);
                }
            }
        }
    }
}
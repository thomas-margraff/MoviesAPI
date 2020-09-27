using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviesAPI.Controllers;
using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAPI.Tests.UnitTests
{
    [TestClass]
    public class GenreControllerTests: BaseTests
    {
        [TestMethod]
        public async Task GetAllGenres()
        {
            // Preparation
            var databaseName = Guid.NewGuid().ToString();
            var context = BuildContext(databaseName);
            var mapper = BuildMap();

            context.Genres.Add(new Genre() { Name = "Genre 1" });
            context.Genres.Add(new Genre() { Name = "Genre 2" });
            context.SaveChanges();

            var context2 = BuildContext(databaseName);

            // Testing
            var controller = new GenresController(context2, mapper);
            var response = await controller.Get();

            // Verification
            var genres = response.Value;
            Assert.AreEqual(2, genres.Count);

        }
    }
}

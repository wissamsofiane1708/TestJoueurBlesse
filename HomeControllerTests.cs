using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace JoueurBlesse.Tests
{
    public class HomeControllerTests
    : IClassFixture<WebApplicationFactory<JoueurBlesse.Startup>>
    {
        private readonly WebApplicationFactory<JoueurBlesse.Startup> _factory;

        public HomeControllerTests(WebApplicationFactory<JoueurBlesse.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Equipe/Create")]
        [InlineData("/Equipe/Delete")]
        [InlineData("/Equipe/Details")]
        [InlineData("/Equipe/Edit")]
        [InlineData("/Equipe/Index")]
        [InlineData("/Joueur/Create")]
        [InlineData("/Joueur/Delete")]
        [InlineData("/Joueur/Details")]
        [InlineData("/Joueur/Edit")]
        [InlineData("/Joueur/Index")]
        [InlineData("/Selectionneur/Create")]
        [InlineData("/Selectionneur/Delete")]
        [InlineData("/Selectionneur/Details")]
        [InlineData("/Selectionneur/Edit")]
        [InlineData("/Selectionneur/Index")]
        [InlineData("/Trophee/Create")]
        [InlineData("/Trophee/Delete")]
        [InlineData("/Trophee/Details")]
        [InlineData("/Trophee/Edit")]
        [InlineData("/Trophee/Index")]
        [InlineData("/TypeBlessure/Create")]
        [InlineData("/TypeBlessure/Delete")]
        [InlineData("/TypeBlessure/Details")]
        [InlineData("/TypeBlessure/Edit")]
        [InlineData("/TypeBlessure/Index")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
using FakeItEasy;
using Artister.API.Services;
using Artister.API.Models.Artist;
using Artister.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Artister.Tests.Controller
{
    public class ArtistControllerTests
    {
        private readonly IArtistService _artistService;
        private readonly ArtistController _artistController;

        public ArtistControllerTests()
        {
            //Dependencies
            _artistService = A.Fake<IArtistService>();

            //SUT
            _artistController = new ArtistController(_artistService);
        }
        [Fact]
        public void ArtistController_GetAll_ReturnsSuccess()
        {
            //Arange
            var artist = A.Fake<List<ArtistDto>>();
            A.CallTo(() => _artistService.GetAll()).Returns(artist);
            //Act
            var result = _artistController.GetAll();
            //Assert
            result.Should().BeOfType<OkObjectResult>();
            //result.
        }
        [Fact]
        public void ArtistController_GetById_ReturnsSuccess()
        {
            //Arange
            var id = 1;
            var artist = A.Fake<ArtistDto>();
            A.CallTo(() => _artistService.GetById(id)).Returns(artist);
            //Act
            var result = _artistService.GetById(id);
            //Assert
            result.Should().BeOfType<OkObjectResult>();

        }
    }
}

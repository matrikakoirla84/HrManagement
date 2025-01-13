using HrManagement.API.Controllers;
using HrManagement.Application.Responses;
using HrManagement.UnitTest.MockData;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HrManagement.UnitTest.Systems.Controller
{
    public class TestCandidateController
    {
        [Fact]
        public async Task AddUpdateCandidate_ShouldReturn200_WhenCommandExecutesSuccessfully()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var command = CandidateInfoMockData.GetAddUpdateCandidateInfo();
            var mockResponse = new CommonResponse
            {
                Success = true,
                Message = "Candidate Added successfully."
            };

            mockMediator
                .Setup(mediator => mediator.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockResponse);

            var controller = new CandidateController(mockMediator.Object); // Replace with actual controller name

            // Act
            var result = await controller.AddUpdateCandidate(command);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result); // Ensure response is OkObjectResult
            var response = Assert.IsType<CommonResponse>(actionResult.Value); // Ensure the response is of type CommonResponse

            Assert.Equal(200, actionResult.StatusCode); // Check HTTP status code
            Assert.True(response.Success);
        }
        [Fact]
        public async Task RegisterUser_ShouldReturn404_WhenCommandReturnsNull()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var command = CandidateInfoMockData.GetAddUpdateCandidateInfo();


            // Mock mediator to return null
            mockMediator
                .Setup(mediator => mediator.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync((CommonResponse)null);

            var controller = new CandidateController(mockMediator.Object); // Replace with actual controller name

            // Act
            var result = await controller.AddUpdateCandidate(command);

            // Assert
            Assert.IsType<NotFoundResult>(result); // Ensure response is NotFoundResult
        }
    }
}

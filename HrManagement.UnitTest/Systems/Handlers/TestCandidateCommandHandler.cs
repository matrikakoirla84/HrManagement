using HrManagement.Application.Handlers.CandidateHandler;
using HrManagement.Core.ModelEntities.Candidate;
using HrManagement.Core.Repositories;
using HrManagement.UnitTest.MockData;
using Moq;

namespace HrManagement.UnitTest.Systems.Handlers
{
    public class TestCandidateCommandHandler
    {
        [Fact]
        public async Task Handle_ShouldAddCandidate_WhenCandidateDoesNotExist()
        {
            // Arrange
            var mockRepository = new Mock<ICandidateRepository>();

            var command = CandidateInfoMockData.GetAddUpdateCandidateInfo();


            mockRepository.Setup(repo => repo.GetUser(command.Email))
                .ReturnsAsync((CandidateInfo)null); // Candidate does not exist

            mockRepository.Setup(repo => repo.AddCandidate(It.IsAny<CandidateInfo>()))
                .ReturnsAsync(1); // Candidate added successfully

            var handler = new CandidateCommandHandler(mockRepository.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("000", result.Code);
            Assert.Equal("Successfully Added", result.Message);
        }
        [Fact]
        public async Task Handle_ShouldUpdateCandidate_WhenCandidateExists()
        {
            // Arrange
            var mockRepository = new Mock<ICandidateRepository>();

            var existingCandidate = new CandidateInfo
            {
                Id = 1,
                Email = "test@gmail.com"
            };

            var command = CandidateInfoMockData.GetAddUpdateCandidateInfo();


            mockRepository.Setup(repo => repo.GetUser(command.Email))
                .ReturnsAsync(existingCandidate); // Candidate exists

            mockRepository.Setup(repo => repo.UpdateCandidate(It.IsAny<CandidateInfo>()))
                .ReturnsAsync(1); // Candidate updated successfully

            var handler = new CandidateCommandHandler(mockRepository.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("000", result.Code);
            Assert.Equal("Successfully Updated", result.Message);
        }
        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenAddCandidateFails()
        {
            // Arrange
            var mockRepository = new Mock<ICandidateRepository>();

            var command = CandidateInfoMockData.GetAddUpdateCandidateInfo();


            mockRepository.Setup(repo => repo.GetUser(command.Email))
                .ReturnsAsync((CandidateInfo)null); // Candidate does not exist

            mockRepository.Setup(repo => repo.AddCandidate(It.IsAny<CandidateInfo>()))
                .ReturnsAsync(0); // Adding candidate fails

            var handler = new CandidateCommandHandler(mockRepository.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("111", result.Code);
            Assert.Equal("Unable to Add Candidate Details", result.Message);
        }
    }
}

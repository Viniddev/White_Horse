using App.Api.Controllers.V1;
using App.Domain;
using App.Domain.Services;
using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Response.UserInfo;
using App.Tests.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Xunit;

namespace App.Tests.Controllers;

public class UsersControllerTest
{
    private readonly Mock<IUserService> _userServiceMock;
    private readonly CancellationToken _cancelationToken;
    public UsersControllerTest()
    {
        _userServiceMock = new Mock<IUserService>();
        _cancelationToken = new CancellationToken();
    }

    [Fact]
    public async Task GetAll_WhenRepository_IsNotEmpty() 
    {
        //Arrange
        var expectedResponse = new PagedResponse<List<UserInformationResponse>>(
            UserControllerData.ListaUserInformationsResponse,
            UserControllerData.ListaUserInformationsResponse.Count,
            Configuration.DefaultPageSize,
            Configuration.DefaultPageNumber
        );

        var request = new PagedRequest();

        _userServiceMock
            .Setup(x => x.GetAllUsersService(It.IsAny<PagedRequest>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(expectedResponse));

        //act
        var response = await UsersController.GetAll(request, _userServiceMock.Object, _cancelationToken);
        
        //Assert
        var okResult = Assert.IsType<Ok<PagedResponse<List<UserInformationResponse>>>>(response);
        Assert.NotEmpty(okResult.Value?.Data);
        Assert.Equal(expectedResponse.Data?.Count, okResult.Value?.Data.Count);

        _userServiceMock
            .Verify(x => x.GetAllUsersService(It.IsAny<PagedRequest>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}

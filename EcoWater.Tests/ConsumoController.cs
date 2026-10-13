using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace EcoWater.Tests;

public class ConsumoControllerTests :
    IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ConsumoControllerTests(
        WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Get_ReturnsHttpStatusCode200()
    {
        var response =
            await _client.GetAsync("/api/consumo");

        Assert.Equal(
            HttpStatusCode.OK,
            response.StatusCode);
    }
}
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace JacoAPITests;

public class JacoApiShould : IClassFixture<WebApplicationFactory<Program>>
{
    readonly HttpClient client;

    public JacoApiShould(WebApplicationFactory<Program> application)
    {
        client = application.CreateClient();
    }

    [Fact]
    public async Task GetHelloWorld()
    {
        var response = await client.GetStringAsync("/");

        Assert.Equal("Hello World!", response);
    }
}
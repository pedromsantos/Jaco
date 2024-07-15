using FluentAssertions;
using JacoApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;

namespace JacoAPITests;

public class JacoApiShould
{
    [Fact]
    public void JacoControllerShould()
    {
        var controller = new JacoController(new LoggerFactory().CreateLogger<JacoController>());

        controller.Get().As<OkObjectResult>().Value.Should().Be("Hello from Jaco API!");
    }
}
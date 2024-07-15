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
        new JacoController(new LoggerFactory().CreateLogger<JacoController>())
            .Get().As<OkObjectResult>().Value
            .Should().Be("Hello from Jaco API!");
    }
}
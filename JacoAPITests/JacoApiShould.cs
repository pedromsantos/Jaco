using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace JacoAPITests;

public class JacoApiShould
{
    [Fact]
    public void SillyTest()
    {
        true.Should().BeTrue();
    }
}
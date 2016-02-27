using FluentAssertions;
using Jaco.Chords;
using Xunit;

namespace JacoTests.Chords
{
    public class FunctionShould
    {
        public static TheoryData<Function, string, int> Functions 
           => new TheoryData<Function, string, int>
           {
               { Function.Root, "R", 0 },
               { Function.Third, "3", 1 },
               { Function.Fifth, "5", 2 },
               { Function.Seventh, "7", 3 },
               { Function.Ninth, "9", 4 },
               { Function.Eleventh, "11", 5 },
               { Function.Thirteenth, "13", 6 },
           };

        [Theory, MemberData(nameof(Functions))]
        public void RelateFunctionToNAmeAndIndex(Function function, string name, int index)
        {
            function.Name.Should().Be(name);
            function.Index.Should().Be(index);
        }
    }
}
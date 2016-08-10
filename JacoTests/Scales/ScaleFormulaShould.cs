using FluentAssertions;
using Jaco.Notes;
using Jaco.Scales;
using Xunit;

namespace JacoTests.Scales
{
    public class ScaleFormulaShould
    {
        [Fact]
        public void CreateIonian()
        {
            ScaleFormula.Ionian.CreateForRoot(Note.C)
                .Notes
                .Should().ContainInOrder(Note.C, Note.D, Note.E, Note.F, Note.G, Note.A, Note.B);
        }

        [Fact]
        public void CreateAeolian()
        {
            ScaleFormula.Aolian.CreateForRoot(Note.A)
                .Notes
                .Should().ContainInOrder(Note.A, Note.B, Note.C, Note.D, Note.E, Note.F, Note.G);
        }
    }
}
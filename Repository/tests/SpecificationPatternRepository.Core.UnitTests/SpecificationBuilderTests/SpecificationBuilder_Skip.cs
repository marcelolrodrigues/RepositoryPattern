using FluentAssertions;
using SpecificationPatternRepository.Core.Exceptions;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests.SpecificationBuilderTests
{
    public class SpecificationBuilder_Skip
    {
        [Fact]
        public void SetsSkipProperty_GivenValue()
        {
            StoreNamesPaginatedSpec spec = new StoreNamesPaginatedSpec(1, 10);
            spec.Skip.Should().Be(1);
        }

        //[Fact]
        //public void DoesNothing_GivenSkipWithFalseCondition()
        //{
        //    var spec = new CompanyByIdWithFalseConditions(1);
        //    spec.Skip.Should().BeNull();
        //}

        [Fact]
        public void ThrowsDuplicateSkipException_GivenSkipUsedMoreThanOnce()
        {
            Action sutAction = () => new StoreDuplicateSkipSpec();
            sutAction.Should()
                .Throw<DuplicateSkipException>()
                .WithMessage("Duplicate use of Skip(). Ensure you don't use Skip() more than once in the same specification!");
        }
    }
}

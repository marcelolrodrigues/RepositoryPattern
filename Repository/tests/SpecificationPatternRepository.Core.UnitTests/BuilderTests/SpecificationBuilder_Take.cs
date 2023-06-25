using FluentAssertions;
using SpecificationPatternRepository.Core.Exceptions;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests.BuilderTests
{
    public class SpecificationBuilder_Take
    {
        [Fact]
        public void SetsTakeProperty_GivenValue()
        {
            StoreNamesPaginatedSpec spec = new StoreNamesPaginatedSpec(0, 10);
            spec.Take.Should().Be(10);
        }

        //[Fact]
        //public void DoesNothing_GivenTakeWithFalseCondition()
        //{
        //    var spec = new CompanyByIdWithFalseConditions(1);
        //    spec.Take.Should().BeNull();
        //}

        [Fact]
        public void ThrowsDuplicateTakeException_GivenTakeUsedMoreThanOnce()
        {
            Action sutAction = () => new StoreDuplicateTakeSpec();
            sutAction.Should()
                .Throw<DuplicatedTakeException>()
                .WithMessage("Duplicate use of Take(). Ensure you don't use Take() more than once in the same specification!");
        }
    }
}

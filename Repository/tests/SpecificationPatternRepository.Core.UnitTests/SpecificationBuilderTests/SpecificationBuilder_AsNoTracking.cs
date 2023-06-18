using FluentAssertions;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests.SpecificationBuilderTests
{
    public class SpecificationBuilder_AsNoTracking
    {
        [Fact]
        public void DoesNothing_GivenSpecWithoutAsNoTracking()
        {
            // arrange 
            StoreEmptySpec spec = new StoreEmptySpec();

            // assert
            spec.AsNoTracking.Should().BeFalse();
        }

        [Fact]
        public void DoesNothing_GivenAsNoTrackingWithFalseCondition()
        {
            // arrange
            AsNoTrackingWithFalseCondition spec = new AsNoTrackingWithFalseCondition();

            // assert
            spec.AsNoTracking.Should().BeFalse();
        }

        [Fact]
        public void FlagsAsNoTracking_GivenSpecWithAsNoTracking()
        {
            // arrange
            AsNoTrackingWithTrueCondition spec = new AsNoTrackingWithTrueCondition();

            // assert
            spec.AsNoTracking.Should().BeTrue();
        }
    }
}

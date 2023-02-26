﻿namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Company> Companies { get; set; } = new List<Company>();
    }
}

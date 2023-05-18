namespace SpecificationPatternRepository.Core.Exceptions
{
    public class DuplicatedTakeException : Exception
    {
        private const string message = "Duplicate use of Take(). " +
            "Ensure you don't use Take() more than once in the same specification!";

        public DuplicatedTakeException() : base(message)
        {
        }

        public DuplicatedTakeException(Exception innerException) : base(message, innerException)
        {
        }
    }
}

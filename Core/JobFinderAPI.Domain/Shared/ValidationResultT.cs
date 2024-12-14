namespace JobFinderAPI.Domain.Shared
{
    public class ValidationResultT<T> : Result<T> , IValidationResult 
    {
        private ValidationResultT(Error[] errors) : base(false, default!, IValidationResult.ValidationError)
            => Errors = errors;

        public Error[] Errors { get; }
    }
}

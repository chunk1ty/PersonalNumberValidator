namespace PersonalNumberValidator.Common
{
    public class Result
    {
        private Result(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }

        private Result(bool isSuccessful,string errors)
        {
            IsSuccessful = isSuccessful;
            Error = errors;
        }

        public bool IsSuccessful { get; }

        public string Error { get; }

        public static Result Success()
        {
            return new Result(true);
        }

        public static Result Failure(string error)
        {
            return new Result(false, error);
        }
    }
}

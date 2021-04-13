namespace MozaeekCore.Exceptions
{
    public class UserFriendlyException : System.Exception
    {
        public UserFriendlyException(string? message) : base(message)
        {
        }
    }

    public class UnAuthorizedUserFriendlyException : System.Exception
    {
        public UnAuthorizedUserFriendlyException(string? message) : base(message)
        {
        }
    }

    public class NotFoundUserFriendlyException : System.Exception
    {
        public NotFoundUserFriendlyException(string? message) : base(message)
        {
        }
    }
}
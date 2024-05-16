using ErrorOr;

namespace TechStore.Domain.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error EmailExists => Error.Conflict(
                code: "User.EmailExists.",
                description: "Email is already in use.");
        }
    }
}

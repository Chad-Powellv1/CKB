using ErrorOr;

namespace CKB.Domain.Common.Errors;

public static partial class Errors
{
    public static class Post
    {
        public static Error NotFound => Error.NotFound(
            code: "Post.NotFound",
            description: "The post was not found.");

        public static Error TitleTooShort => Error.Validation(
            code: "Post.TitleTooShort",
            description: "The post title is too short.");
    }
}

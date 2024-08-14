using CKB.Domain.Common.Models;
using CKB.Domain.Users.ValueObjects;

namespace CKB.Domain.Entities;

public class User : Entity<UserId>
{
    public string Username { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty; 

    private readonly List<Post> _posts = new();
    public IReadOnlyList<Post> Posts => _posts.AsReadOnly();

    private readonly List<Comment> _comments = new();
    public IReadOnlyList<Comment> Comments => _comments.AsReadOnly();

    private readonly List<Like> _likes = new();
    public IReadOnlyList<Like> Likes => _likes.AsReadOnly();

    protected User() { } 

    public User(UserId id, string username, string email)
        : base(id)
    {
        Username = username;
        Email = email;
    }
}

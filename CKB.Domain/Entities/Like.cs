using CKB.Domain.Common.Models;

namespace CKB.Domain.Entities;

public class Like : Entity<Guid>
{
    public Guid PostId { get; private set; }
    public Post Post { get; private set; } = default!; 
    public Guid UserId { get; private set; }
    public User User { get; private set; } = default!; 

    protected Like() { }

    public Like(Guid id, Guid postId, Post post, Guid userId, User user)
        : base(id)
    {
        PostId = postId;
        Post = post;
        UserId = userId;
        User = user;
    }
}
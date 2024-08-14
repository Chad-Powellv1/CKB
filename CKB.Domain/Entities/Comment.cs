using CKB.Domain.Common.Models;

namespace CKB.Domain.Entities;

public class Comment : AuditableEntity
{
    public string Content { get; private set; } = string.Empty; 
    public Guid PostId { get; private set; }
    public Post Post { get; private set; } = default!; 
    public Guid AuthorId { get; private set; }
    public User Author { get; private set; } = default!; 

    protected Comment() { } 

    public Comment(Guid id, string content, Guid postId, Post post, Guid authorId, User author, DateTime createdAt)
        : base(id, createdAt, createdAt)
    {
        Content = content;
        PostId = postId;
        Post = post;
        AuthorId = authorId;
        Author = author;
    }
}
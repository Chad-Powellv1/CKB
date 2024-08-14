using CKB.Domain.Common.Models;
using CKB.Domain.Users.ValueObjects;
using CKB.Domain.ValueObjects;

namespace CKB.Domain.Entities;

public class Post : AuditableEntity
{
    public UserId AuthorId { get; private set; } = default!; // Default value
    public User Author { get; private set; } = default!; // Default value

    private readonly List<Comment> _comments = new();
    public IReadOnlyList<Comment> Comments => _comments.AsReadOnly();

    private readonly List<Like> _likes = new();
    public IReadOnlyList<Like> Likes => _likes.AsReadOnly();

    private readonly List<Tag> _tags = new();
    public IReadOnlyList<Tag> Tags => _tags.AsReadOnly();

    private readonly List<Category> _categories = new();
    public IReadOnlyList<Category> Categories => _categories.AsReadOnly();

    public string Title { get; private set; } = string.Empty; 
    public Slug Slug { get; private set; } = default!; 
    public string Content { get; private set; } = string.Empty; 

    public string SearchableContent => $"{Title} {Content}";

    protected Post() { } 

    public Post(Guid id, string title, Slug slug, string content, UserId authorId, User author, DateTime createdAt)
        : base(id, createdAt, createdAt)
    {
        Title = title;
        Slug = slug;
        Content = content;
        AuthorId = authorId;
        Author = author;
    }
}
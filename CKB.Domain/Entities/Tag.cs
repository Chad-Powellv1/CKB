using CKB.Domain.Common.Models;
using CKB.Domain.ValueObjects;

namespace CKB.Domain.Entities;

public class Tag : Entity<Guid>
{
    public TagName Name { get; private set; } = default!; // Default value

    private readonly List<Post> _posts = new();
    public IReadOnlyList<Post> Posts => _posts.AsReadOnly();

    protected Tag() { }

    public Tag(Guid id, TagName name)
        : base(id)
    {
        Name = name;
    }

    public void AddPost(Post post)
    {
        _posts.Add(post);
    }
}

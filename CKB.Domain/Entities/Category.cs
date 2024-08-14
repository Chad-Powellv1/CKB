using CKB.Domain.Common.Models;
using CKB.Domain.ValueObjects;

namespace CKB.Domain.Entities;

public class Category : Entity<Guid>
{
    public CategoryName Name { get; private set; } = default!; 

    private readonly List<Post> _posts = new();
    public IReadOnlyList<Post> Posts => _posts.AsReadOnly();

    protected Category() { }

    public Category(Guid id, CategoryName name)
        : base(id)
    {
        Name = name;
    }

    public void AddPost(Post post)
    {
        _posts.Add(post);
    }
}

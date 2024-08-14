using CKB.Domain.Entities;
using System.Linq.Expressions;

namespace CKB.Application.Services;

public class SearchService
{
    public IEnumerable<Post> SearchPosts(
        string? searchTerm, 
        IEnumerable<Post> posts, 
        string? authorName = null, 
        IEnumerable<string>? tags = null,
        DateTime? createdAfter = null,
        DateTime? createdBefore = null,
        int page = 1, 
        int pageSize = 10,
        string sortBy = "CreatedAt", 
        bool ascending = true)
    {
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            searchTerm = searchTerm.ToLower();
            posts = posts.Where(p => p.SearchableContent.ToLower().Contains(searchTerm));
        }

        if (!string.IsNullOrWhiteSpace(authorName))
        {
            authorName = authorName.ToLower();
            posts = posts.Where(p => p.Author.Username.ToLower().Contains(authorName));
        }

        if (tags != null && tags.Any())
        {
            var tagSet = new HashSet<string>(tags.Select(t => t.ToLower()));
            posts = posts.Where(p => p.Tags.Any(tag => tagSet.Contains(tag.Name.Value.ToLower())));
        }

        if (createdAfter.HasValue)
        {
            posts = posts.Where(p => p.CreatedAt >= createdAfter.Value);
        }

        if (createdBefore.HasValue)
        {
            posts = posts.Where(p => p.CreatedAt <= createdBefore.Value);
        }

        posts = SortPosts(posts, sortBy, ascending);

        return Paginate(posts, page, pageSize);
    }

    private IEnumerable<Post> SortPosts(IEnumerable<Post> posts, string sortBy, bool ascending)
    {
        Expression<Func<Post, object>> keySelector = sortBy.ToLower() switch
        {
            "title" => p => p.Title,
            "author" => p => p.Author.Username,
            "createdat" => p => p.CreatedAt,
            _ => p => p.CreatedAt, // Default to CreatedAt
        };

        return ascending ? posts.OrderBy(keySelector.Compile()) : posts.OrderByDescending(keySelector.Compile());
    }

    private IEnumerable<Post> Paginate(IEnumerable<Post> posts, int page, int pageSize)
    {
        return posts.Skip((page - 1) * pageSize).Take(pageSize);
    }
}

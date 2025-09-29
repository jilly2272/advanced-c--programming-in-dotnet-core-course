//Represents a comment on a blog post, including properties like Id, Content, DateCreated, and a foreign key (BlogId) to associate it with a specific blog post.

namespace BlogManagementSystem___Entity_Framework.Model;

public class Comment
{
    public string CommentId { get; set; }
    public string Content { get; set; }
    public DateTime DateCreated { get; set; }
    
    public string BlogId { get; set; }
    public Blog Blog { get; set; }
}
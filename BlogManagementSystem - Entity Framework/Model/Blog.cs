//Represents the structure of a blog post, including properties such as Id, Title, Content, DateCreated, and a list of associated comments.

namespace BlogManagementSystem___Entity_Framework.Model;

public class Blog
{
    public string BlogId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime DateCreated { get; set; }

    public List<Comment> Comments;

    public Blog()
    {
        Comments = new List<Comment>();
    }
}
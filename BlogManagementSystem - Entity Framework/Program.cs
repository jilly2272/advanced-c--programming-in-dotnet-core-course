//Overview: The Blog Management System is a console application developed in C# using Entity Framework Core and Visual Studio 2022. The system models a basic blog platform allowing users to create blog posts and add comments to them. It showcases the implementation of CRUD operations on both blog posts and comments using Entity Framework Core for data persistence.

using BlogManagementSystem___Entity_Framework.Data;
using BlogManagementSystem___Entity_Framework.Model;

using (var context = new AppDbContext())
{
    //creates db if it doesn't exist
    context.Database.EnsureCreated();

    //create first time entity objects
    string blog1Id = "cheese";
    Blog blog1 = context.Blogs.FirstOrDefault(b => b.BlogId == blog1Id);
    if (blog1 is null)
    {
        blog1 = new Blog
        {
            BlogId = blog1Id,
            Title = "Cheese Post",
            Content = "Cheese is underrated and deserves more love.",
            DateCreated = DateTime.Now
        };
        context.Blogs.Add(blog1);
    }

    string comment1Id = "i-hate-cheese";
    Comment comment1 = context.Comments.FirstOrDefault(c => c.CommentId == comment1Id);
    if (comment1 is null)
    {
        comment1 = new Comment
        {
            CommentId = comment1Id,
            Content = "Cheese is literally disgusting, I hate it!",
            DateCreated = DateTime.Now,
            Blog = blog1,
            BlogId = blog1.BlogId
        };
        context.Comments.Add(comment1);
    }

    //save data to the database tables
    context.SaveChanges();

    bool exit = false;

    while (!exit)
    {
        Console.Clear();
        Console.WriteLine("=== Blog Management System ===");
        Console.WriteLine("1. View All Blog Posts");
        Console.WriteLine("2. View Blog Post Details");
        Console.WriteLine("3. Create New Blog Post");
        Console.WriteLine("4. Add Comment to Blog Post");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice (1-5): ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ViewAllBlogPosts(context);
                break;
            case "2":
                ViewBlogPostDetails(context);
                break;
            case "3":
                CreateNewBlogPost(context);
                break;
            case "4":
                AddCommentToBlogPost(context);
                break;
            case "5":
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid choice. Press any key to continue...");
                Console.ReadKey();
                break;
        }
    }

    static void ViewAllBlogPosts(AppDbContext context)
    {
        Console.Clear();
        Console.WriteLine("=== All Blog Posts ===");

        var blogs = context.Blogs.ToList();

        if (blogs.Count == 0)
        {
            Console.WriteLine("No blog posts found.");
        }
        else
        {
            foreach (var blog in blogs)
            {
                Console.WriteLine($"ID: {blog.BlogId}");
                Console.WriteLine($"Title: {blog.Title}");
                Console.WriteLine($"Date: {blog.DateCreated.ToShortDateString()}");
                Console.WriteLine(new string('-', 30));
            }
        }

        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }

    static void ViewBlogPostDetails(AppDbContext context)
    {
        Console.Clear();
        Console.WriteLine("=== Blog Post Details ===");
        Console.Write("Enter Blog ID: ");
        string blogId = Console.ReadLine();

        var blog = context.Blogs.FirstOrDefault(b => b.BlogId == blogId);

        if (blog == null)
        {
            Console.WriteLine("Blog post not found.");
        }
        else
        {
            Console.WriteLine($"ID: {blog.BlogId}");
            Console.WriteLine($"Title: {blog.Title}");
            Console.WriteLine($"Content: {blog.Content}");
            Console.WriteLine($"Date Created: {blog.DateCreated}");
            Console.WriteLine(new string('-', 30));

            Console.WriteLine("Comments:");
            var comments = context.Comments.Where(c => c.BlogId == blogId).ToList();

            if (comments.Count == 0)
            {
                Console.WriteLine("No comments found for this blog post.");
            }
            else
            {
                foreach (var comment in comments)
                {
                    Console.WriteLine($"  Comment ID: {comment.CommentId}");
                    Console.WriteLine($"  Content: {comment.Content}");
                    Console.WriteLine($"  Date: {comment.DateCreated.ToShortDateString()}");
                    Console.WriteLine($"  {new string('-', 25)}");
                }
            }
        }

        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }

    static void CreateNewBlogPost(AppDbContext context)
    {
        Console.Clear();
        Console.WriteLine("=== Create New Blog Post ===");

        Console.Write("Enter Blog ID (unique identifier): ");
        string blogId = Console.ReadLine();

        if (context.Blogs.Any(b => b.BlogId == blogId))
        {
            Console.WriteLine("A blog with this ID already exists. Please try again with a different ID.");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter Blog Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Blog Content: ");
        string content = Console.ReadLine();

        Blog newBlog = new Blog
        {
            BlogId = blogId,
            Title = title,
            Content = content,
            DateCreated = DateTime.Now
        };

        context.Blogs.Add(newBlog);
        context.SaveChanges();

        Console.WriteLine("Blog post created successfully!");
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }

    static void AddCommentToBlogPost(AppDbContext context)
    {
        Console.Clear();
        Console.WriteLine("=== Add Comment to Blog Post ===");

        Console.Write("Enter Blog ID to comment on: ");
        string blogId = Console.ReadLine();

        var blog = context.Blogs.FirstOrDefault(b => b.BlogId == blogId);

        if (blog == null)
        {
            Console.WriteLine("Blog post not found.");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter Comment ID (unique identifier): ");
        string commentId = Console.ReadLine();

        if (context.Comments.Any(c => c.CommentId == commentId))
        {
            Console.WriteLine("A comment with this ID already exists. Please try again with a different ID.");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter Comment Content: ");
        string content = Console.ReadLine();

        Comment newComment = new Comment
        {
            CommentId = commentId,
            Content = content,
            DateCreated = DateTime.Now,
            BlogId = blogId,
            Blog = blog
        };

        context.Comments.Add(newComment);
        context.SaveChanges();

        Console.WriteLine("Comment added successfully!");
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }
}
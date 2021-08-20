using System;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new BloggingContext())
            {
                Create(db);
                Read(db);
                Update(db);
                Delete(db);                
            }
        }
        
        static void Create(BloggingContext db)
        {
            Console.WriteLine("Inserting a new blog");
            db.Add(new Blog {Url = "http://blogs.msdn.com/adonet"});
            db.SaveChanges();
        }

        static void Read(BloggingContext db)
        {
            Console.WriteLine("\nQuerying for a blog");
            var blog = db.Blogs.OrderBy(b => b.BlogId).First();
            Console.WriteLine($"Blog Id: {blog.BlogId} ");
            Console.WriteLine($"Blog URL: {blog.Url}");
        }

        static void Update(BloggingContext db)
        {
            Console.WriteLine("\nUpdating the blog and adding a post");
            var blog = db.Blogs.OrderBy(b => b.BlogId).First();
            blog.Url = "https://devblogs.microsoft.com/dotnet";
            blog.Posts.Add(new Post {Title = "Hello World", Content = "I wrote an app using EF Core!"});
            db.SaveChanges();
        }

        static void Delete(BloggingContext db)
        {
            Console.WriteLine("\nDelete the blog");
            var blog = db.Blogs.OrderBy(b => b.BlogId).First();
            db.Remove(blog);
            db.SaveChanges();
        }

    }
}

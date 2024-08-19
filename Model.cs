using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static EF_blog.Post;

namespace EF_blog
{
    class DB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }

        string _path = "blogging.db";

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={_path}");
    }

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public List<Post> Posts { get; } = new();

        public void addposttouser(Post a)
        {
            Posts.Add(a);
            a.User = this;
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Post> Posts { get; } = new();

        public void AddPostsToBlog(Post a)
        {
            Posts.Add(a);
            a.Blog = this;
        }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public Post Post { get; set; }
        public List<Post> Posts { get; } = new();

        public void AddPostsToCategory(Post a)
        {
            Posts.Add(a);
            a.Category = this;
        }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public Category Category { get; set; }
        public List<Category> Categories { get; } = new();

        public void AddCategories(Category c)
        {
            Categories.Add(c);
            c.Post = this;
        }
    }
}
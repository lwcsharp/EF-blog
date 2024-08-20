using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EF_blog;

class DB : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Blog> Blogs { get; set; }

    public string path = "blogging.db";

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={path}");
}

public class User
{
    public int UserId { get; set; }
    public string? Name { get; set; }

    public List<Post> Posts { get; } = new(); //en användare har många inlägg

    public void AddPostToUser(Post a)
    {
        Posts.Add(a); //lägg till ett inlägg till användaren
        a.User = this; //ställ in User på inlägget> inlägget tillhör den aktuella användaren
    }
}
public class Post
{
    public int PostId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }

    public int BlogId { get; set; }
    public Blog? Blog { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; } //varje inlägg har en användare

    public List<Category> Categories { get; } = new();

    public void AddCategory(Category c)
    {
        Categories.Add(c); //lägg till en kategori till inlägget
        c.Posts.Add(this); //lägg till inlägget till kategorins lista
    }
}

public class Category
{
    public int CategoryId { get; set; }
    public string? Name { get; set; }

    public List<Post> Posts { get; } = new();

    public void AddPost(Post a)
    {
        Posts.Add(a); //lägg till inlägget till kategorins lista
        a.Categories.Add(this); //lägg till kategorin till inläggets lista
    }
}

public class Blog
{
    public int BlogId { get; set; }
    public string? Url { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    public List<Post> Posts { get; } = new();

    public void AddPostToBlog(Post a)
    {
        Posts.Add(a);
        a.Blog = this;
    }
}
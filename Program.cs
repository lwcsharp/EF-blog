using EF_blog;
using var db = new DB();

Console.WriteLine($"Database path: {db.path}.");

/* Create - user */
Console.WriteLine("Inserting a new user");
db.Users.Add(new User { Name = "Yummy" });
db.SaveChanges();

/* Update - user < blog */
Console.WriteLine("Updating the user and adding a blog");
User user = db.Users.Where(u => u.Name == "Yummy").First();
db.Blogs.Add(new Blog { Url = "FoodBlog", User = user });
db.SaveChanges();

/* Update - user <> post <> blog */
Console.WriteLine("Updating the blog with a new post and adding it to usern");
Blog blog = db.Blogs.Where(b => b.Url == "FoodBlog").First();
db.Users.First().Posts.Add(new Post { Title = "Taiyaki", Content = "Classic with anko" , User = user, Blog = blog});
db.SaveChanges();

/* Update - post <> category */
Console.WriteLine("Updating the post and adding a new category");
Post post = db.Users.Where(c => c.Name == "Yummy").First()
    .Posts.Where(p => p.Title == "Taiyaki").First();
post.AddCategory(new Category { Name = "Food" });
db.SaveChanges();

/*Create*//*
Console.WriteLine("Inserting a new user");
var user = new User
{ 
    Name = "foodlover" 
};
db.Users.Add(user);
db.SaveChanges();

Console.WriteLine("Inserting a new category");
var category = new Category
{
    Name = "food",
};
db.Categories.Add(category);
db.SaveChanges();

*//*Update*//*
Console.WriteLine("Updating the user and adding a blog");
var blog = new Blog
{
    Url = "http://realfoodie.blog.com/reviews",
    User = user
};
db.Blogs.Add(blog);
db.SaveChanges();

Console.WriteLine("Updating the blog and adding a post");
var post = new Post
{
    Title = "Okonomiyaki in Osaka",
    Content = "Osakas okonomiyakis is a must try if you are in Japan!",
    Blog = blog,
    User = user,
};
//post.Categories.Add(category);
//category.Posts.Add(post);
*//*
user.AddPostToUser(post);
blog.AddPostToBlog(post);
category.AddPost(post);
*//*
post.AddCategory(category);
db.Posts.Add(post);
db.SaveChanges();

*//*Read*//*
Console.WriteLine("Querying for a user");
user = db.Users
    .Where(u => u.Name == "foodlover")
    .FirstOrDefault();
if (user == null)
{
    Console.WriteLine("User 'user' not found.");
    return;
}

Console.WriteLine("Querying for a blog");
blog = db.Blogs
    .Where(b => b.Url == "http://realfoodie.blog.com/reviews")
    .FirstOrDefault();
if (blog == null)
{
    Console.WriteLine("User 'blog' not found.");
    return;
}

Console.WriteLine("Querying for a post");
post = db.Posts
    .Where(p => p.Title == "Okonomiyaki in Osaka")
    .FirstOrDefault();
if (blog == null)
{
    Console.WriteLine("User 'post' not found.");
    return;
}

*//*Delete*//*
Console.WriteLine("Delete the user");
db.Remove(user);
Console.WriteLine("Delete the category");
db.Remove(category);
db.SaveChanges();*/
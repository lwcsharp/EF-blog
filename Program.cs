using EF_blog;
using var db = new DB();

Console.WriteLine($"Database path: {db.path}.");

//db.Users.Add(new User { Name = "Yummy" });
//db.SaveChanges();
//db.Users.First().Posts.Add(new Post { Title = "Taiyaki" });
//db.Users.First().Posts.Add(new Post { Title = "Takoyaki" });
//db.SaveChanges();

//db.Blogs.Add(new Blog { Url = "FoodBlog" });
//db.SaveChanges();

//db.Categories.Add(new Category { Name = "Food" });
//db.SaveChanges();

//Post Post = db.Users.Where
//    (u => u.Name == "Yummy")
//    .First()
//    .Posts.Where
//    (p => p.Title == "Taiyaki")
//    .First();


// Create
Console.WriteLine("Inserting a new user");
db.Add(new User { Name = "foodlover" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a user");
var user = db.Users
    .Where(u => u.Name == "foodlover")
    .FirstOrDefault();
if (user == null)
{
    Console.WriteLine("User 'user' not found.");
    return;
}

// Update
Console.WriteLine("Updating the user and adding a blog");
Blog b = new Blog{ Url = "http://realfoodie.blog.com/reviews", User = user };
db.Blogs.Add(b);
db.SaveChanges();

//Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .Where(b => b.Url == "http://realfoodie.blog.com/reviews")
    .FirstOrDefault();
if (blog == null)
{
    Console.WriteLine("User 'blog' not found.");
    return;
}

//Update
Console.WriteLine("Updating the blog and adding a post");
blog.Posts.Add(
    new Post { Title = "Okonomiyaki in Osaka", Content = "Osakas okonomiyakis is a must try if you are in Japan!" });
db.SaveChanges();

//Read
Console.WriteLine("Querying for a post");
var post = db.Posts
    .Where(p => p.Title == "Okonomiyaki in Osaka")
    .FirstOrDefault();
if (blog == null)
{
    Console.WriteLine("User 'post' not found.");
    return;
}


// Delete
Console.WriteLine("Delete the user");
db.Remove(user);
db.SaveChanges();
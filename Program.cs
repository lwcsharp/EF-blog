using EF_blog;
using var db = new DB();

Console.WriteLine($"Database path: {db.path}.");

/* Create - user */
Console.WriteLine("Inserting > user");
db.Users.Add(new User { Name = "Yummy" });
db.SaveChanges();

/* Update - user < blog */
Console.WriteLine("Updating the user and adding a blog");
User user = db.Users.Where(u => u.Name == "Yummy").First();
db.Blogs.Add(new Blog { Url = "http://foodyummy.blog.com/recipes", User = user });
db.SaveChanges();

/* Update - user <> post <> blog */
Console.WriteLine("Updating the blog with a new post and adding it to usern");
Blog blog = db.Blogs.Where(b => b.Url == "http://foodyummy.blog.com/recipes").First();
db.Users.First().Posts.Add(new Post { Title = "Taiyaki", Content = "Classic with anko" , User = user, Blog = blog});
db.SaveChanges();

/* Update - post <> category */
Console.WriteLine("Updating the post and adding a new category");
Post post = db.Users.Where(c => c.Name == "Yummy").First()
    .Posts.Where(p => p.Title == "Taiyaki").First();
var category = new Category { Name = "Food" };
post.AddCategory(category);
db.SaveChanges();

//----- Another way to populate data -----//
/*Create*/
Console.WriteLine("Inserting > user");
var user2 = new User
{ 
    Name = "foodLover" 
};
db.Users.Add(user2);
db.SaveChanges();

Console.WriteLine("Inserting > category");
var category2 = new Category
{
    Name = "Japan",
};
db.Categories.Add(category2);
db.SaveChanges();

/*Update*/
Console.WriteLine("Updating the user and adding a blog");
var blog2 = new Blog
{
    Url = "http://realfoodie.blog.com/reviews",
    User = user2
};
db.Blogs.Add(blog2);
db.SaveChanges();

Console.WriteLine("Updating the blog and adding a post");
var post2 = new Post
{
    Title = "Okonomiyaki in Osaka",
    Content = "Osakas okonomiyakis is a must try if you are in Japan!",
    Blog = blog2,  
    User = user2, 
};
//post2.Categories.Add(category2);  //2 way, comment out row 70-75
//post2.Categories.Add(category);  //-**-
//category2.Posts.Add(post2);     //-***-
//user2.AddPostToUser(post2);       //3 way, comment out row 67-69&74-75
//blog2.AddPostToBlog(post2);      //-**-
//category2.AddPost(post2);       //-***-
//category.AddPost(post2);       //-****-
post2.AddCategory(category);
post2.AddCategory(category2);
db.Posts.Add(post2);
db.SaveChanges();

/*Read*/
Console.WriteLine("Querying >> user");
user2 = db.Users
    .Where(u => u.Name == "foodLover")
    .FirstOrDefault();
if (user2 == null)
{
    Console.WriteLine("User 'name' not found.");
    return;
}

Console.WriteLine("Querying >> blog");
blog2 = db.Blogs
    .Where(b => b.Url == "http://realfoodie.blog.com/reviews")
    .FirstOrDefault();
if (blog2 == null)
{
    Console.WriteLine("User 'blog' not found.");
    return;
}

Console.WriteLine("Querying >> post");
post2 = db.Posts
.Where(p => p.Title == "Okonomiyaki in Osaka")
.FirstOrDefault();
if (post2 == null)
{
    Console.WriteLine("User 'post' not found.");
    return;
}

Console.WriteLine("Querying >> category");
category2 = db.Categories
.Where(p => p.Name == "Japan")
.FirstOrDefault();
if (category2 == null)
{
    Console.WriteLine("Post 'category' not found.");
    return;
}

var getPrinter = new DataPrinter(db);
getPrinter.PrintAllData();

/*Delete*/
Console.WriteLine("\nDelete > user & relating data");
//db.Remove(user2); ////remove a specific user
db.Users.RemoveRange(db.Users);
Console.WriteLine("Delete > category");
db.Categories.RemoveRange(db.Categories);
//db.Remove(category2); ////remove a specific category
db.SaveChanges();
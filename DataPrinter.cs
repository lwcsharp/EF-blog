using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_blog;

public class DataPrinter
{
    private readonly DB _db;
    public DataPrinter(DB db)
    {
        _db = db;
    }

    public void PrintAllData()
    {
        var users = _db.Users
            .Include(u => u.Posts)
            .ThenInclude(p => p.Blog)
            .Include(u => u.Posts)
            .ThenInclude(p => p.Categories)
            .ToList();
        int nr = 1;
        foreach (var user in users)
        {
            Console.WriteLine($"\n{nr++}.User - {user.Name}");
            foreach (var post in user.Posts)
            {
                Console.WriteLine($"Post - Title: {post.Title}");
                Console.WriteLine($"Content: {post.Content}");

                Console.WriteLine($"Blog - URL: {post.Blog?.Url}");

                foreach (var category in post.Categories)
                {
                    Console.WriteLine($"Category - Name: {category.Name}");
                }
            }
        }
    }
}

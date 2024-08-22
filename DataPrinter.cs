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
        //"eager loading" of related data
        var users = _db.Users
            .Include(u => u.Posts)                  //hämtar användarnas inlägg
                .ThenInclude(p => p.Blog)          //hämtar blogg kopplade till inläggen
            .Include(u => u.Posts)                //hämtar användatrnas inlägg igen för kategorier
                .ThenInclude(p => p.Categories)  //hämtar kategorier kopplade till inläggen
            .ToList();                          //konverterar resultatet till en lista

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

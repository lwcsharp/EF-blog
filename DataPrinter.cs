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

    public void PrintAllUsers()
    {

    }
    public void PrintAllBlogs()
    {

    }
    public void PrintAllPost()
    {

    }
    public void PrintAllCategories()
    {

    }

}

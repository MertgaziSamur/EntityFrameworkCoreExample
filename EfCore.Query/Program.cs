using System;
using System.Linq;
using EfCore.Query.Data.Context;
using EfCore.Query.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Query
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new BlogContext();

            //context.Add(new Blog()
            //{
            //    Title = "Blog1",
            //    Url = "asdssaasas.com/blog-1"
            //});

            //context.Add(new Blog()
            //{
            //    Title = "Blog2",
            //    Url = "asdasdasdf.com/blog-2"
            //});

            //context.Add(new Blog()
            //{
            //    Title = "Blog3",
            //    Url = "kjasdjkgksda.com/blog-3"
            //});

            //context.Add(new Blog()
            //{
            //    Title = "Blog4",
            //    Url = "otydgldagoaor.com/blog-4"
            //});

            //context.SaveChanges();

            // ** IEnumerable and IQueryable**
            //var query = context.Blogs.AsQueryable();
            //var blogs = query.Where((x => x.Title.Contains("Blog-1") || x.Title.Contains("Blog-2"))).ToList();
            //foreach (var item in blogs)
            //{
            //    Console.WriteLine(item.Title);
            //}

            // ** Tracking and No-Tracking ** 

            // *Tracking 
            //var updatedBlog= context.Blogs.SingleOrDefault(x => x.Id == 1);
            //updatedBlog.Title = "Güncellendi";
            //var updatedBlogState = context.Entry(updatedBlog).State;

            // *No-Tracking
            //var updatedBlog = context.Blogs.AsNoTracking().SingleOrDefault(x => x.Id == 1);
            //updatedBlog.Title = "Güncellendi";
            //var updatedBlogState = context.Entry(updatedBlog).State;
            //context.SaveChanges();


            // ** Lazy, Eager, Explicit Load ** 
            var blogs = context.Blogs.Include(x => x.Comments).ToList();
            foreach (var blog in blogs)
            {
                Console.WriteLine($"{blog.Title} Bloğun yorumları");
                foreach (var comment in blog.Comments)
                {
                    Console.WriteLine($"     {comment.Content}");
                }
            }
        }
    }
}

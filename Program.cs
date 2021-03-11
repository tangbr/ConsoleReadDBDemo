using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Console26App1
{
	class Program
	{
		static async Task Main()
		{
            var p = new Program();
            //       		await p.AddBooksAsync();
                   await p.ReadBooksAsync_linq();
          //  await p.UpdateBookAsync();
        }

        private static async Task ReadBooksAsync()
		{
            using (var context = new BooksContext())
			{
                //        List<Book> books = await context.Books.ToListAsync();
                List<Book> books = await context.Books.FromSqlRaw(
                 //   @"SELECT * FROM Books where Publisher = 'Wrox press'")
                              @"SELECT * FROM Books")
                            .ToListAsync();
				foreach (var b in books)
                {
                    Console.WriteLine($"{b.Title}{b.Publisher}");
				}
			}
            Console.WriteLine();
        }

        private async Task ReadBooksAsync_linq()
        {
            using (var context = new BooksContext())
            {
                //        List<Book> books = await context.Books.ToListAsync();
                List<Book> books = await context.Books
                    .Where(b => b.Publisher == "Wrox Press")
                            .ToListAsync();
                foreach (var b in books)
                {
                    Console.WriteLine($"{b.Title}{b.Publisher}");
                }
            }
            Console.WriteLine();
        }

        private async Task AddBooksAsync()
        {
            Console.WriteLine(nameof(AddBooksAsync));
            using (var context = new BooksContext())
            {
                var b1 = new Book("Professional C# 6 and .NET Core 1.0", "Wrox Press");
                var b2 = new Book("Professional C# 5 and .NET 4.5.1", "Wrox Press");
                var b3 = new Book("JavaScript for Kids", "Wrox Press");
                var b4 = new Book("HTML and CSS", "John Wiley");
                await context.Books.AddRangeAsync(b1, b2, b3, b4);

                int records = await context.SaveChangesAsync();

                Console.WriteLine($"{records} records added");
            }
            Console.WriteLine();
        }

        private async Task UpdateBookAsync()
		{
            using (var context = new BooksContext())
			{
                int records = 0;
                Book book = await context.Books
                .Where(b => b.Title == "Professional C# 6 and .NET Core 1.0")
                    .FirstOrDefaultAsync();

                if (book!=null)
				{
                    book.Title = "Professional C# 7 and .NET Core 2.0";
                    records = await context.SaveChangesAsync();
				}
                Console.WriteLine($"{records} record update");
			}
            Console.WriteLine();
		}

        private async Task DeleteBooksAsync()
		{
            using (var context = new BooksContext())
			{
                var books = context.Books;
                context.Books.RemoveRange(books);
                int records = await context.SaveChangesAsync();
                Console.WriteLine($"{records} records deleted");
			}
            Console.WriteLine();
		}



    }
}


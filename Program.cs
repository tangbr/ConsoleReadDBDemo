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
            //		await p.AddBooksAsync();
            await p.ReadBooksAsync();
        }

        private async Task ReadBooksAsync()
		{
            using (var context = new BooksContext())
			{
                List<Book> books = await context.Books.ToListAsync();
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
    }
}


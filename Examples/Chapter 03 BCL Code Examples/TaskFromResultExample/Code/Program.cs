using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TaskFromResultExample
{
    class Program
    {
        static void Main(string[] args)
        {

            var bookTitleToFind = "Ten Things I Forgot to Remember";
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Looking for a book...");
            stopwatch.Start();
            
            BookStore.FindBookAsync(bookTitleToFind)
            .ContinueWith(t =>
            {
                stopwatch.Stop();
                Console.WriteLine("time taken to find \"{0}\": {1}", t.Result.Title, stopwatch.Elapsed);
            })
            .Wait();

            stopwatch.Restart();
            BookStore.FindBookAsync(bookTitleToFind)
                .ContinueWith(t =>
           {
               stopwatch.Stop();
               Console.WriteLine("time taken to find \"{0}\": {1}", t.Result.Title, stopwatch.Elapsed);
           })
           .Wait();

            Console.Read();
        }
    }

    public class Book
    {
        public string Title { get; set; }
    }

    class BookStore
    {
        static ConcurrentDictionary<string, Book> booksOnTheShelves =
          new ConcurrentDictionary<string, Book>();

        public static Task<Book> FindBookAsync(string bookTitle)
        {
            // First try to retrieve the content from cache.
            Book requestedBook;
            if (booksOnTheShelves.TryGetValue(bookTitle, out requestedBook))
            {
                return Task.FromResult<Book>(requestedBook);
            }

            return Task.Run<Book>(() =>
            {

                var newBook = Task.Run<Book>(async () =>
                     {
                         await Task.Delay(TimeSpan.FromSeconds(3));
                         return new Book { Title = bookTitle };
                     });
                booksOnTheShelves.TryAdd(bookTitle, newBook.Result);
                return newBook;
            });
        }

    }
}
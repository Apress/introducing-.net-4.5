using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestBookApi.Models;

namespace RestBookApi.Controllers
{
    public class BooksController : ApiController
    {
        private readonly Dictionary<string, Book> bookDictionary =
            new Dictionary<string, Book>
                {
                    {
                        "9780470524657",
                        new Book
                            {
                                Title = "Silverlight for Dummies",
                                Isbn = "9780470524657",
                                Authors = new[]
                                              {
                                                  new Author {FirstName = "Mahesh", LastName = "Krishnan"},
                                                  new Author {FirstName = "Philip", LastName = "Beadle"},
                                              },
                            }
                    },
                    {
                        "9781430243328",
                        new Book
                            {
                                Title = "Introducing .NET 4.5",
                                Isbn = "9781430243328",
                                Authors = new[]
                                              {
                                                  new Author {FirstName = "Mahesh", LastName = "Krishnan"},
                                                  new Author {FirstName = "Alex", LastName = "Mackey"},
                                                  new Author {FirstName = "William", LastName = "Tulloch"},
                                              },
                            }
                    },
                };

        // GET /api/books
        public IQueryable<Book> Get()
        {
            return bookDictionary.Values.AsQueryable();
        }

        // GET /api/books/5
        public Book Get(string id)
        {
            try
            {
                return bookDictionary[id];
            }
            catch (Exception)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
        }

        // POST /api/books
        public HttpResponseMessage Post(Book book)
        {
            bookDictionary[book.Isbn] = book;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, book);
            string uri = Url.Route(null, new {id = book.Isbn});
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }


        // PUT /api/books/5
        public void Put(string id, Book value)
        {
            if (bookDictionary.ContainsKey(id))
                bookDictionary[id] = value;
            else
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }


        // DELETE /api/books/5
        public void Delete(string id)
        {
            if (bookDictionary.ContainsKey(id))
                bookDictionary.Remove(id);
        }
    }
}
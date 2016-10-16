using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using RestBookApi.Models;

namespace RestBookApi
{
    public class CsvFormatter : BufferedMediaTypeFormatter
    {
        public CsvFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return typeof (IEnumerable<Book>).IsAssignableFrom(type);
        }

        public override void WriteToStream(Type type, object value, Stream stream, HttpContent content)
        {
            var books = value as IEnumerable<Book>;
            if (books != null)
            {
                var writer = new StreamWriter(stream);
                writer.WriteLine("Isbn, Title");

                foreach (var book in books)
                {
                    writer.WriteLine("{0}, {1}", book.Isbn, book.Title);
                }
                writer.Flush();
            }
        }
    }
}
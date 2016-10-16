namespace RestBookApi.Models
{
    public class Book
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public Author[] Authors { get; set; }
    }

    public class Author
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
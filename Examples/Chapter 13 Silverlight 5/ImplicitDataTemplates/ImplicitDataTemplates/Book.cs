namespace ImplicitDataTemplates
{
    public class Book
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public int Pages { get; set; }
    }

    public class EBook : Book
    {
        public string Format { get; set; }
        public int Size { get; set; }
    }
}
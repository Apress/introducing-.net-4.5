using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SemanticZoom
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            var data = new[]
                           {
                               new
                                   {
                                       Title = "Silverlight 4 for dummies",
                                       Isbn = "978-0470524657 ",
                                       Publisher = "Wiley",
                                       Authors = "Krishnan, Beadle",
                                       YearPublished = "2010",
                                       Genre = "Technical"
                                   },
                               new
                                   {
                                       Title = "Introducing .NET 4",
                                       Isbn = "978-1430224556",
                                       Publisher = "Apress",
                                       Authors = "Mackey",
                                       YearPublished = "2010",
                                       Genre = "Technical"
                                   },
                               new
                                   {
                                       Title = "Introducing .NET 4.5",
                                       Isbn = "978-1430243328",
                                       Publisher = "Apress",
                                       Authors = "Mackey, Tulloch, Krishnan",
                                       YearPublished = "2012",
                                       Genre = "Technical"
                                   },
                               new
                                   {
                                       Title = "Fox in socks",
                                       Isbn = "978-0307931801",
                                       Publisher = "Random House ",
                                       Authors = "Dr. Seuss",
                                       YearPublished = "1965",
                                       Genre = "Childrens"
                                   },
                               new
                                   {
                                       Title = "Green Eggs and Ham ",
                                       Isbn = "978-0583324205 ",
                                       Publisher = "Random House ",
                                       Authors = "Dr. Seuss",
                                       YearPublished = "2008",
                                       Genre = "Childrens"
                                   },
                               new
                                   {
                                       Title = "The Cat in the Hat",
                                       Isbn = "978-0545014571 ",
                                       Publisher = "Random House ",
                                       Authors = "Dr. Seuss",
                                       YearPublished = "2008",
                                       Genre = "Childrens"
                                   },
                               new
                                   {
                                       Title = "Hop on Pop",
                                       Isbn = "978-0375828379 ",
                                       Publisher = "Random House",
                                       Authors = "Dr. Seuss",
                                       YearPublished = "2004",
                                       Genre = "Childrens"
                                   },
                               new
                                   {
                                       Title = "Steve Jobs",
                                       Isbn = "978-1451648539 ",
                                       Publisher = "Simon & Schuster",
                                       Authors = "Isaacson",
                                       YearPublished = "2011",
                                       Genre = "Non-fiction"
                                   },
                               new
                                   {
                                       Title = "Bossypants",
                                       Isbn = "978-0316056861",
                                       Publisher = "Reagan Arthur Books",
                                       Authors = "Fey",
                                       YearPublished = "2011",
                                       Genre = "Non-fiction"
                                   },
                               new
                                   {
                                       Title = "1Q84",
                                       Isbn = "978-0307593313",
                                       Publisher = "Knopf",
                                       Authors = "Murakami",
                                       YearPublished = "2619",
                                       Genre = "Fiction"
                                   },
                           };

            var query = from item in data
                        orderby item.Genre
                        group item by item.Genre
                        into g
                        select new {Genre = g.Key, Items = g};

            BookCollection.Source = query.ToList();
            ZoomOut.ItemsSource = BookCollection.View.CollectionGroups;
        }


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
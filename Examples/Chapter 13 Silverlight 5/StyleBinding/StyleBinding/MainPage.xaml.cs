using System.Windows.Controls;
using System.Windows.Media;

namespace StyleBinding
{
    public class UserPreference
    {
        public UserPreference()
        {
            FavouriteColor = new SolidColorBrush(Colors.Blue);
            FavouriteFont = new FontFamily("Gabriola");
        }

        public SolidColorBrush FavouriteColor { get; set; }
        public FontFamily FavouriteFont { get; set; }
    }

    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
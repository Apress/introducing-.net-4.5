using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConventionBasedExample.Contracts;
using System.Windows.Media;

namespace TileLibrary
{
    public class BlueTile : ITileViewModel
    {
        public string Title { get; set; }

        public string BackgroundColour { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// Initializes a new instance of the BlueTile class.
        /// </summary>
        public BlueTile()
        {
            Title = "The Blue Tile";
            BackgroundColour = Colors.Blue.ToString();
            Message = "A message from the blue tile";
        }
    }
}

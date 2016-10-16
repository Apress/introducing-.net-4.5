using System;
using System.Collections.Generic;
using System.Linq;
using ConventionBasedExample.Contracts;
using System.Windows.Media;

namespace TileLibrary
{
    public class RedTile : ITileViewModel
    {

        public string Title { get; set; }

        public string BackgroundColour { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// Initializes a new instance of the RedTile class.
        /// </summary>
        public RedTile()
        {
            Title = "The Red Tile";
            BackgroundColour = Colors.Red.ToString();
            Message = "A Message from the red tile";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;

namespace TileLibrary 
{
   // [PartNotDiscoverable]
    public class YellowTile : ITileViewModel
    {
        public string Title { get; set; }

        public string BackgroundColour { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// Initializes a new instance of the YellowTile class.
        /// </summary>
        public YellowTile()
        {
            Title = "The Yellow Tile";
			BackgroundColour = "Gold";
            Message = "A Message from the Yellow tile";
        }

    }
}

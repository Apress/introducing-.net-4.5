using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConventionBasedExample.Contracts;
using System.Windows.Media;
using System.ComponentModel.Composition;

namespace TileLibrary 
{
    [PartNotDiscoverable]
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
            BackgroundColour = Color.FromRgb(0xFF, 0xCC, 0x66).ToString();
            Message = "A Message from the Yellow tile";
        }

    }
}

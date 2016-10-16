using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using System.Composition;


namespace Win8ConventionBuilder
{
    public class TilesContainer
    {
       [ImportMany("Tile")]
        public IEnumerable<ITileViewModel> Tiles { get; set; }

		public Logger MessageLogger { get; set; }


      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace ConventionBasedExample.Contracts
{
    public interface ITileViewModel
    {
        string Title { get; set; }
        string BackgroundColour { get; set; }
        string Message {get; set;}
    }
}

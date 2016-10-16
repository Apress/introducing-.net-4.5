using System;
using System.Collections.Generic;
using System.Linq;

namespace Contracts
{
    public interface ITileViewModel
    {
        string Title { get; set; }
        string BackgroundColour { get; set; }
        string Message {get; set;}
    }
}

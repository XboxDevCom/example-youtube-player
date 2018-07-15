using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToolkit.Multimedia;

namespace XboxDev___Youtube_Player___UWP.Models
{
    public class YouTubeVideo
    {
        public string YouTubeId { get; set; }

        public string Title { get; set; }

        public Uri ThumbnailUri { get; set; }

        public YouTubeUri VideoUri { get; set; }
    }
}

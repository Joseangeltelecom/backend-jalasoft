using System;

namespace Delegates
{
    public class VideoEventArgs : EventArgs
    {
        // It determines the video that was encoded:
        public Video Video { get; set; }
    }
}
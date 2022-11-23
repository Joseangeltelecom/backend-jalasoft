using System;
using System.Threading;

namespace Delegates
{
    public class VideoEncoder
    {
        // 1 -  Define delegate (Event Handler)
        // 2 - Define an event based on that delegate.
        // 3 - Raise the event.

        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args); // a reference to a method

        // send a reference to the videos so the subscribers know which video we encoded.
        public event VideoEncodedEventHandler VideoEncoded; 

       //public event EventHandler<VideoEventArgs> VideoEncoded; 
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);
            OnVideoEncoded(video);
        }

        // dotNet suggest that our event should be protected, virtual and void. And start with "On" and the name of the event.
        protected virtual void OnVideoEncoded(Video video) // this method will be in charge of raising the event. (VideoEncoded)
        {
            if (VideoEncoded != null) // if there's no event. (WIll have our subscriber here.)
            { 
                VideoEncoded(this, new VideoEventArgs(){Video = video}); // the event.
            }
        }
    }
}

using System;

namespace Delegates
{
    public class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("Sending Message... " + args.Video.Title);
        }
    }
}
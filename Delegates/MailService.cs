using System;

namespace Delegates
{
    public class MailService
        {
            public void OnVideoEncoded(object source, VideoEventArgs e)
            {
                Console.WriteLine("MailServices: Sending an email..." + e.Video.Title);
            }
        }
}
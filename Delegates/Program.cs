namespace Delegates
{
     class Program
    {
        static void Main(string[] args)
        {
            var video = new Video(){ Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); // Publisher.

            var mailService = new MailService(); // 1st subscriber.
            var messageService = new MessageService(); // 2nd subscriber.

            // add or subscribe my handler to the event. (It's just a reference or pointer to that method).
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded; 
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
            // we need subscribe before calling the Encode method.
            videoEncoder.Encode(video);
        }
    }
}
using System;
using Akka.Actor;
using EstudosAkkanet.Presentation.Messages;

namespace EstudosAkkanet.Presentation.Actors
{
    public class PlaybackActor : ReceiveActor
    {
        public PlaybackActor()
        {
            Console.WriteLine("Creating a Playback Actor");
            Receive<PlayMovieMessage>(message => HandlePlayMovieMessage(message));
        }

        private static void HandlePlayMovieMessage(PlayMovieMessage message)
        {
            Console.WriteLine("Received movie title: " + message.MovieTitile);
            Console.WriteLine("User Id: " + message.UserId);
        }
    }
}
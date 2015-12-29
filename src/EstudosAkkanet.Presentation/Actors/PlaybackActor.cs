using System;
using Akka.Actor;
using EstudosAkkanet.Presentation.Messages;

namespace EstudosAkkanet.Presentation.Actors
{
    public class PlaybackActor : UntypedActor
    {
        public PlaybackActor()
        {
            Console.WriteLine("Creating a Playback Actor");
        }

        protected override void OnReceive(object message)
        {
            if (message is PlayMovieMessage)
            {
                var playMovieMessage = message as PlayMovieMessage;
                Console.WriteLine("Received movie title: " + playMovieMessage.MovieTitile);
                Console.WriteLine("User Id: " + playMovieMessage.UserId);
            }
            else
                Unhandled(message);
        }
    }
}
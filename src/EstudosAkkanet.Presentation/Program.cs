using System;
using Akka.Actor;
using EstudosAkkanet.Presentation.Actors;
using EstudosAkkanet.Presentation.Messages;

namespace EstudosAkkanet.Presentation
{
    class Program
    {
        private static ActorSystem _movieStreamingActorSystem;

        static void Main(string[] args)
        {
            PlaygroundAkka();
        }

        private static void PlaygroundAkka()
        {
            _movieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");
            Console.WriteLine("Actor System created!");

            Props playbackActorProps = Props.Create<PlaybackActor>();
            IActorRef playbackActorRef = _movieStreamingActorSystem.ActorOf(playbackActorProps, "PlaybackActor");
            playbackActorRef.Tell(new PlayMovieMessage("The Movie", 42));
            Console.ReadKey();
            _movieStreamingActorSystem.Shutdown();
        }
    }
}

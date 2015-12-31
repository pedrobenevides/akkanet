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

            Props userActorProps = Props.Create<UserActor>();
            IActorRef userActorRef = _movieStreamingActorSystem.ActorOf(userActorProps, "PlaybackActor");

            userActorRef.Tell(new PlayMovieMessage("The Movie", 42));
            userActorRef.Tell(new PlayMovieMessage("Another Movie", 43));

            Console.ReadKey();
            _movieStreamingActorSystem.Shutdown();
        }
    }
}

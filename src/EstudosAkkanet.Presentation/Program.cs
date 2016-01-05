using System;
using Akka.Actor;
using EstudosAkkanet.Presentation.Actors;
using EstudosAkkanet.Presentation.Messages;

namespace EstudosAkkanet.Presentation
{
    class Program
    {
        private static ActorSystem movieStreamingActorSystem;

        static void Main(string[] args)
        {
            const string PATH = "/user/Playback/UserCoordinator";
            Console.WriteLine("Creating MovieStreamingActorSystem");
            movieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");

            Console.WriteLine("Creating actor supervisory hierarchy");
            movieStreamingActorSystem.ActorOf(Props.Create<PlaybackActor>(), "Playback");
            
            do
            {
                Console.WriteLine("enter a command and hot enter");
                var command = Console.ReadLine();

                if(string.IsNullOrEmpty(command))
                    throw new Exception("Invalid Command");

                if (command.StartsWith("play"))
                {
                    var userId = int.Parse(command.Split(',')[1]);
                    var movieTitle = command.Split(',')[2];

                    var message = new PlayMovieMessage(movieTitle, userId);
                    movieStreamingActorSystem.ActorSelection(PATH).Tell(message);
                }

                if (command.StartsWith("stop"))
                {
                    movieStreamingActorSystem.ActorSelection(PATH).Tell(message);
                }

            } while (true);
        }

        private static void PlaygroundAkka()
        {
            movieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");
            Console.WriteLine("Actor System created!");

            Props userActorProps = Props.Create<UserActor>();
            IActorRef userActorRef = movieStreamingActorSystem.ActorOf(userActorProps, "PlaybackActor");

            userActorRef.Tell(new PlayMovieMessage("The Movie", 42));
            userActorRef.Tell(new PlayMovieMessage("Another Movie", 43));

            Console.ReadKey();
            movieStreamingActorSystem.Shutdown();
        }
    }
}

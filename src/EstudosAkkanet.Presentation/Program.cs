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
            //Actor System são criados atraves do ActorSystemCreate
            movieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");
            Console.WriteLine("Actor System created");

            var userActorProps = Props.Create<UserActor>();
            var userActorRef = movieStreamingActorSystem.ActorOf(userActorProps, "UserActor");
            
            Console.ReadKey();
            Console.WriteLine("Sending a PlayMovieMessage (Partial Recall)");
            userActorRef.Tell(new PlayMovieMessage("Partial Reacall", 99));

            Console.ReadKey();
            Console.WriteLine("Sending a PlayMovieMessage (Boolean Lies)");
            userActorRef.Tell(new PlayMovieMessage("Boolean Lies", 77));

            Console.ReadKey();
            Console.WriteLine("Sending a PlayMovieMessage (Codenan the Destroyer)");
            userActorRef.Tell(new PlayMovieMessage("Codenan the Destroyer", 1));

            Console.ReadKey();
            Console.WriteLine("Sending a StopMovieMessage");
            userActorRef.Tell(new StopMovieMessage());

            Console.ReadKey();
            Console.WriteLine("Sending another StopMovieMessage");
            userActorRef.Tell(new StopMovieMessage());
            
            //Avisa aos Actors e aos Child Actors to Shutdown
            movieStreamingActorSystem.Shutdown();

            //Bloqueia a Tread atual ate que ocorra o Shutdown do sistema
            movieStreamingActorSystem.AwaitTermination();
            Console.WriteLine("Actor system shutdown");

            Console.ReadKey();
        }
    }

}

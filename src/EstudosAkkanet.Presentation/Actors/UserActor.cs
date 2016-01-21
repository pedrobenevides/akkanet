using System;
using System.Threading.Tasks;
using Akka.Actor;
using EstudosAkkanet.Presentation.Messages;

namespace EstudosAkkanet.Presentation.Actors
{
    public class UserActor : ReceiveActor
    {
        private string _currentlyWatching;

        public UserActor(int userId)
        {
            Console.WriteLine("Creating a UserActor");
            Console.WriteLine("Setting initial behavior to stopped");
            Stopped();
        }

        private void Playing()
        {
            Receive<PlayMovieMessage>(message => Console.WriteLine("Error: cannot start playing another movie before stopping existing one"));
            Receive<StopMovieMessage>(message => StopPlayingCurrentMovie());
            Console.WriteLine("User actor has now become playing");
        }

        private void Stopped()
        {
            Receive<StopMovieMessage>(message => Console.WriteLine("Error: Cannot stop if nothing is playing"));
            Receive<PlayMovieMessage>(message => StartPlayingMovie(message.MovieTitile));
            Console.WriteLine("User now has become stopped");
        }

        private void StopPlayingCurrentMovie()
        {
            _currentlyWatching = null;
            Console.WriteLine("Movie has been stopped.");

            Become(Stopped);
        }

        private void StartPlayingMovie(string movieTitile)
        {
            _currentlyWatching = movieTitile;
            Console.WriteLine($"Now user is watching {movieTitile}");

            Become(Playing);
        }
    }
}

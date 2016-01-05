using System;
using Akka.Actor;
using EstudosAkkanet.Presentation.Messages;

namespace EstudosAkkanet.Presentation.Actors
{
    public class UserActor : ReceiveActor
    {
        private string watchinMovieName;
        private int userId;

        public UserActor()
        {
            Console.WriteLine("Actor created!");
            Stopped();
        }

        public UserActor(int userId)
        {
            this.userId = userId;
        }

        private void Playing()
        {
            Receive<PlayMovieMessage>(
                message => Console.WriteLine("Error: cannot start playing another movie, before stoping existing one"));

            Receive<StopMovieMessage>(message => StopPlayingCurrentMovie());
        }

        private void StopPlayingCurrentMovie()
        {
            Console.WriteLine($"User has sopped watching {0}", watchinMovieName);
            watchinMovieName = null;

            Become(Stopped);
        }

        private void Stopped()
        {
            Receive<PlayMovieMessage>(message => StartPlayingMovie(message.MovieTitile));
            Receive<StopMovieMessage>(message => Console.WriteLine("Error: you cannot stop if nothing is playing"));
        }

        private void StartPlayingMovie(string movieTitle)
        {
            Console.WriteLine($"User has started the movie {0}", movieTitle);
            watchinMovieName = movieTitle;

            Become(Playing);
        }
    }
}

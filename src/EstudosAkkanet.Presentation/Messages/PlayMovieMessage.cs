namespace EstudosAkkanet.Presentation.Messages
{
    public class PlayMovieMessage
    {
        public PlayMovieMessage(string movieTitile, int userId)
        {
            MovieTitile = movieTitile;
            UserId = userId;
        }

        public string MovieTitile { get; private set; }
        public int UserId { get; private set; } 
    }
}
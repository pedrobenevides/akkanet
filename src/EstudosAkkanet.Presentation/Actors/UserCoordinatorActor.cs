using System.Collections.Generic;
using Akka.Actor;
using EstudosAkkanet.Presentation.Messages;

namespace EstudosAkkanet.Presentation.Actors
{
    public class UserCoordinatorActor : ReceiveActor
    {
        private readonly Dictionary<int, IActorRef> _users;
         
        public UserCoordinatorActor()
        {
            _users = new Dictionary<int, IActorRef>();
            Receive<PlayMovieMessage>(message =>
            {
                CreateChildIfNotExists(message.UserId);
                var childActorRef = _users[message.UserId];
                childActorRef.Tell(message);
            });
        }

        private void CreateChildIfNotExists(int userId)
        {
            if(!_users.ContainsKey(userId))
                _users.Add(userId, Context.ActorOf(Props.Create(() => new UserActor(userId)), "User"));
        }
    }
}

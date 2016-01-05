using System;
using System.Collections.Generic;
using Akka.Actor;
using EstudosAkkanet.Presentation.Messages;

namespace EstudosAkkanet.Presentation.Actors
{
    public class UserCoordinatorActor : ReceiveActor
    {
        private readonly Dictionary<int, IActorRef> users;

        public UserCoordinatorActor()
        {
            users = new Dictionary<int, IActorRef>();
            Receive<PlayMovieMessage>(message =>
            {
                CreateChildIfNotExists(message.UserId);
                IActorRef childActorRef = users[message.UserId];

                childActorRef.Tell(message);
            });

            //Receive<StopMovieMessage>(message =>
            //{
            //    IActorRef chiActorRef = users[message]
            //});
        }

        private void CreateChildIfNotExists(int userId)
        {
            if(users.ContainsKey(userId)) return;

            IActorRef newChildActorRef = Context.ActorOf(Props.Create(() => new UserActor(userId)), $"User{userId}");
            Console.WriteLine($"CoordinatorActor created new child UserActor for {userId} (Total Users: {users.Count})");
        }
    }
}

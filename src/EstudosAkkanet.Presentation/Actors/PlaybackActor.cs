using System;
using Akka.Actor;

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
            if(message is string)
                Console.WriteLine("Received movie title: " + message);
            else if (message is int)
                Console.WriteLine("Received user Id: " + message);
            else
                Unhandled(message);
        }
    }
}
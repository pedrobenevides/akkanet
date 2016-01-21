using System;
using Akka.Actor;
using EstudosAkkanet.Presentation.Messages;

namespace EstudosAkkanet.Presentation.Actors
{
    public class PlaybackActor : ReceiveActor
    {
        public PlaybackActor()
        {
            Console.WriteLine("Creating a Playback Actor");
            Context.ActorOf(Props.Create<UserCoordinatorActor>(), "UserCoordinator");
            Context.ActorOf(Props.Create<PlaybackStatisticsActor>(), "PlaybackStatistics");
        }
       
        protected override void PreStart()
        {
            Console.WriteLine("#[PreStart]# Playback actor PreStart");
        }

        protected override void PostStop()
        {
            Console.WriteLine("#[PostStop]# Playback actor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine($"#[PreRestart]# PlaybackActor PreRestart because: {reason}");
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            Console.WriteLine($"#[PostRestart]# PlaybackActor PostRestart because: {reason}");
            base.PostRestart(reason);
        }

    }
}
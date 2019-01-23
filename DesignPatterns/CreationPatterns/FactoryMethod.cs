using System;
using System.Collections.Generic;

namespace DesignPatterns.CreationPatterns
{
    /// <summary>
    /// FactoryMethod is to let the Subclasses to create the instances instead of creating them directly at the parent (base) class (here, the base class is SportTeam)
    /// </summary>
    public class FactoryMethod : IDesignPatternExample
    {
        public void Execute()
        {
            Console.WriteLine("FactoryMethod:");

            // Initialize the list of players for each team indirectly.
            // The subclasses (FootballTeam, DotaTeam) will handle the object initialization
            // The method which initializes the objects (here, CreateTeam()) is call the FACTORY METHOD
            SportTeam footballTeam = new FootballTeam();
            SportTeam dotaTeam = new DotaTeam();

            Console.WriteLine("Football Team players: ");
            foreach(var player in footballTeam.Players)
            {
                Console.WriteLine(" - " + player.GetType().ToString());
            }

            Console.WriteLine("Dota Team players: ");
            foreach (var player in dotaTeam.Players)
            {
                Console.WriteLine(" - " + player.GetType().ToString());
            }

            Console.ReadLine();
        }
    }

    public abstract class Player { }

    public class GoalkeeperPlayer : Player { }
    public class DefenderPlayer : Player { }
    public class MiddlefieldPlayer : Player { }
    public class OffensivePlayer : Player { }

    public class SupportPlayer : Player { }
    public class TankerPlayer : Player { }
    public class NukerPlayer : Player { }
    public class DamageDealerPlayer : Player { }

    public abstract class SportTeam
    {
        public SportTeam()
        {
            Players = CreateTeam();
        }
        public List<Player> Players { get; }

        // This is the important method, the ULTIMATE PURPOSE, for this Design Pattern, also can call this one the FACTORY METHOD
        public abstract List<Player> CreateTeam();
    }

    public class FootballTeam : SportTeam
    {
        public override List<Player> CreateTeam()
        {
            return new List<Player>
            {
                new GoalkeeperPlayer(),
                new DefenderPlayer(),
                new MiddlefieldPlayer(),
                new OffensivePlayer()
            };
        }
    }

    public class DotaTeam : SportTeam
    {
        public override List<Player> CreateTeam()
        {
            return new List<Player>
            {
                new SupportPlayer(),
                new TankerPlayer(),
                new NukerPlayer(),
                new DamageDealerPlayer()
            };
        }
    }
}

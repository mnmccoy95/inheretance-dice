using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootingDice
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            player1.Name = "Bob";

            Player player2 = new Player();
            player2.Name = "Sue";

            Player player3 = new Player();
            player3.Name = "Wilma";

            Player large = new LargeDicePlayer();
            large.Name = "Bigun Rollsalot";

            SmackTalkingPlayer jerk1 = new SmackTalkingPlayer("you suck");
            jerk1.Name = "Kyle";
            SmackTalkingPlayer jerk2 = new SmackTalkingPlayer("take this");
            jerk2.Name = "Chad";

            OneHigherPlayer player4 = new OneHigherPlayer();
            player4.Name = "Bee";

            HumanPlayer me = new HumanPlayer();
            me.Name = "Mori";

            CreativeSmackTalkingPlayer jerk3 = new CreativeSmackTalkingPlayer();
            jerk3.Name = "Logan";

            SoreLoserPlayer jerk4 = new SoreLoserPlayer();
            jerk4.Name = "Rich";

            UpperHalfPlayer upper = new UpperHalfPlayer();
            upper.Name = "Chai";

            SoreLoserUpperHalfPlayer upper2 = new SoreLoserUpperHalfPlayer();
            upper2.Name = "Mike";

            List<Player> players = new List<Player>() {
                player1, player2, player3, large, jerk1, jerk2, player4, me, jerk3, jerk4, upper, upper2
            };

            PlayMany(players);
        }

        static void PlayMany(List<Player> players)
        {
            Console.WriteLine();
            Console.WriteLine("Let's play a bunch of times, shall we?");

            // We "order" the players by a random number
            // This has the effect of shuffling them randomly
            Random randomNumberGenerator = new Random();
            List<Player> shuffledPlayers = players.OrderBy(p => randomNumberGenerator.Next()).ToList();

            // We are going to match players against each other
            // This means we need an even number of players
            int maxIndex = shuffledPlayers.Count;
            if (maxIndex % 2 != 0)
            {
                maxIndex = maxIndex - 1;
            }

            // Loop over the players 2 at a time
            for (int i = 0; i < maxIndex; i += 2)
            {
                Console.WriteLine("-------------------");

                // Make adjacent players play one another
                Player player1 = shuffledPlayers[i];
                Player player2 = shuffledPlayers[i + 1];
                if(player2.Name == "Bee" && (player1.Name == "Rich" | player1.Name == "Mike"))
                {
                    Console.WriteLine($"{player1.Name} ate their dice out of spite because they knew they'd lose to {player2.Name}.");
                }
                else if(player1.Name == "Bee" && (player2.Name == "Rich" | player2.Name == "Mike"))
                {
                    Console.WriteLine($"{player2.Name} ate their dice out of spite because they knew they'd lose to {player1.Name}.");
                }
                else if(player2.Name == "Bee" | player2.Name == "Rich" | player2.Name == "Mike")
                {
                    try
                    {
                        player2.Play(player1);
                    }
                    catch
                    {
                        Console.WriteLine($"The loser ate their dice.");
                    }
                }
                else
                {
                    try
                    {
                        player1.Play(player2);
                    }
                    catch
                    {
                        Console.WriteLine($"The loser ate their dice.");
                    }
                }
            }
        }
    }
}
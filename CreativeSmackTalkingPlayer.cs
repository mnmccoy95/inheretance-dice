using System;
using System.Collections.Generic;

namespace ShootingDice
{
    // A SmackTalkingPlayer who randomly selects a taunt from a list to say to the other player
    public class CreativeSmackTalkingPlayer : Player
    {
        List<string> Taunts = new List<string>
        {
            "git gud",
            "wombo combo",
            "that ain't falco",
            "way past cool"
        };
        public override int Roll()
        {
            static int Number() 
            {
                Random r = new Random();
                int genRand= r.Next(0,4);
                return genRand;
            }
            Console.WriteLine($"{Name} says '{Taunts[Number()]}!'");
            // Return a random number between 1 and DiceSize
            return new Random().Next(DiceSize) + 1;
        }
        
    }
}
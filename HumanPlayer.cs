using System;

namespace ShootingDice
{
    // TODO: Complete this class

    // A player the prompts the user to enter a number for a roll
    public class HumanPlayer : Player
    {
         public override int Roll()
        {
            Console.Write("Please input a number: ");
            int roll = Int32.Parse(Console.ReadLine());
            return roll;
        }
    }
}
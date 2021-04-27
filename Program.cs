using System;
using System.Collections.Generic;

namespace heist_2
{
  class Program
  {
    static void Main(string[] args)
    {
      // Part 4. Create a List<IRobber> and store it in a variable named rolodex
      List<IRobber> rolodex = new List<IRobber>
      {
        // For now pre-populate the list with 5 or 6 robbers (give it a mix of Hackers, Lock Specialists, and Muscle).
        new Hacker
        {
          Name = "Todd",
          SkillLevel = 50,
          PercentageCut = 5,
        },
        new Hacker
        {
          Name = "Patti",
          SkillLevel = 42,
          PercentageCut = 5,
        },
        new Muscle
        {
          Name = "Gabe",
          SkillLevel = 10,
          PercentageCut = 5,
        },
        new Muscle
        {
          Name = "Aaron",
          SkillLevel = 77,
          PercentageCut = 5,
        },
        new LockSpecialist
        {
          Name = "Jordan",
          SkillLevel = 20,
          PercentageCut = 5,
        },
        new LockSpecialist
        {
          Name = "Tommy",
          SkillLevel = 15,
          PercentageCut = 5,
        }
      };

      // When the program starts, print out the number of current operatives in the roladex.
      Console.WriteLine("");
    }
  }
}

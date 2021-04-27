using System;

namespace heist_2
{
  public class Hacker: IRobber // Step 3 Make a Hacker class using the Robber interface
  {
    string Name { get; set; }
    int SkillLevel { get; set; }
    int PercentageCut { get; set; }
    void PerformSkill(Bank foo)
    {
      // Take the Bank parameter and decrement its appropraite security score by the SkillLevel
      Console.WriteLine($"Hacker {Name} is hacking into the mainframe. Minus {SkillLevel} points from Gryffindor");
      foo.AlarmScore = foo.AlarmScore - SkillLevel;
      
      // If the appropriate security score has be reduced to 0 or below, print a message to the console
      if (foo.AlarmScore <= 0)
      {
        Console.WriteLine($"Hacker {Name} has disabled the alarm system.");
      }
      else
      {}
    }
  }
}
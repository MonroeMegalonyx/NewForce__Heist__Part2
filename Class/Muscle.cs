using System;

namespace heist_2
{
  public class Muscle: IRobber // Step 3. Make a Muscle class using the Robber interface
  {
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }
    // Added a property to identify their skill for Part 6
    public string Specialty { get; } = "Muscle";
    public void PerformSkill(Bank foo)
    {
      // Take the Bank parameter and decrement its appropraite security score by the SkillLevel
      Console.WriteLine($"Beefcake {Name} is throwing down with the security guard. Minus {SkillLevel} points from Slytherin");
      foo.SecurityGuardScore = foo.SecurityGuardScore - SkillLevel;
      
      // If the appropriate security score has be reduced to 0 or below, print a message to the console
      if (foo.SecurityGuardScore <= 0)
      {
        Console.WriteLine($"Beefcake {Name} has decommissioned the security guard.");
      }
      else
      {}
    }
  }
}
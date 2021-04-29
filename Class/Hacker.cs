// Class for a robber with Hacker properties to take on the alarm system
using System;

namespace heist_2
{
  public class Hacker: IRobber // Step 3. Make a Hacker class using the Robber interface
  {
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public double PercentageCut { get; set; }
    // Added a property to identify their skill for Part 6
    public string Specialty { get; } = "Hacker";
    // Added an ID property to match eligible picks for the heist in Part 6
    private string _guid { get; } = IdGenerator.GetNextId();

    public string GetId(){ return _guid; }
    
    public void PerformSkill(Bank foo)
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
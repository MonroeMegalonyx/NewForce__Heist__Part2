using System;

namespace heist_2
{
  public class LockSpecialist: IRobber // Step 3 Make a Hacker class using the Robber interface
  {
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }
    public void PerformSkill(Bank foo)
    {
      // Take the Bank parameter and decrement its appropraite security score by the SkillLevel
      Console.WriteLine($"Lockpicker {Name} is breaking into the vault. Minus {SkillLevel} points from Hufflepuff");
      foo.VaultScore = foo.VaultScore - SkillLevel;
      
      // If the appropriate security score has be reduced to 0 or below, print a message to the console
      if (foo.VaultScore <= 0)
      {
        Console.WriteLine($"Lockpicker {Name} has opened the vault.");
      }
      else
      {}
    }
  }
}
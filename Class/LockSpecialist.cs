// Class for a robber with Locl specialist properties to take on the vault
using System;

namespace heist_2
{
  public class LockSpecialist: IRobber // Step 3. Make a LockSpecoialist class using the Robber interface
  {
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public double PercentageCut { get; set; }
    // Added a property to identify their skill for Part 6
    public string Specialty { get; } = "Lock Specialist";
    // Added an ID property to match eligible picks for the heist in Part 6
    private string _guid { get; } = IdGenerator.GetNextId();

    public string GetId(){ return _guid; }

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
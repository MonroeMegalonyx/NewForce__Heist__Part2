// Interface for any "robber"
namespace heist_2
{
  public interface IRobber // Step 2. Create a Robber interface with the following properties
  {
    string Name { get; }
    int SkillLevel { get; }
    double PercentageCut { get; }
    // Added a property to identify their skill for Part 6
    public string Specialty { get; }
    // Added an ID property to match eligible picks for the heist in Part 6
    /*
      Q for Jordan: How do private classes work with interfaces? I don't know why this code works.
    */
    private string _guid { 
      get
      {
        return IdGenerator.GetNextId();
      }
    }
    public string GetId();

    void PerformSkill(Bank foo);
  }
}
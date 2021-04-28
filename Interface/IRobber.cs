namespace heist_2
{
  public interface IRobber // Step 2. Create a Robber interface with the following properties
  {
    string Name { get; }
    int SkillLevel { get; }
    int PercentageCut { get; }
    // Added a property to identify their skill for Part 6
    public string Specialty { get; }
    void PerformSkill(Bank foo);
  }
}
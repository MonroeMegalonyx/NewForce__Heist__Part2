namespace heist_2
{
  public interface IRobber // Step 2. Create a Robber interface with the following properties
  {
    string Name { get; }
    int SkillLevel { get; }
    int PercentageCut { get; }
    void PerformSkill(Bank foo);
  }
}
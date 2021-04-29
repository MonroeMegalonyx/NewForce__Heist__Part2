// Class for a bank, does not inherit any primary classes or interfaces
namespace heist_2
{
  public class Bank // Step 1. Create a Bank class with the following properties
  {
    public int CashOnHand { get; set; }
    public int AlarmScore { get; set; }
    public int VaultScore { get; set; }
    public int SecurityGuardScore { get; set; }

    // Calculated property that has no setter. It is readonly.
    public bool IsSecure
    {
      get
      {
        // If all the scores are less than or equal to 0, this should be false. If any of the scores are above 0, this should be true. Evaluate each individually instead of as a sum to account for possibility of negative integers on some properties.
        if (AlarmScore > 0 || VaultScore > 0 || SecurityGuardScore > 0)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }
  }
}
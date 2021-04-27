using System;

namespace heist_2
{
  class Program
  {
    static void Main(string[] args)
    {
      Bank b = new Bank
      {
        CashOnHand = -9,
        AlarmScore = 0,
        VaultScore = 0,
        SecurityGuardScore = 0,
      };

      Console.WriteLine($"{b.IsSecure}");
    }
  }
}

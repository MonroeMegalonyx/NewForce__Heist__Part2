using System;
using System.Collections.Generic;
using System.Linq;

namespace heist_2
{
  class Program
  {
    static void Main(string[] args)
    {
      // Print the message "Plan Your Second Heist!".
      Console.WriteLine("\n-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*" +
                        "\n-*-*-*-*-*-*HEIST 2: THE COMEBACK-*-*-*-*-*-*" +
                        "\n-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");

      // Part 4. Create a List<IRobber> and store it in a variable named rolodex. Then let user add new members to the rolodex
      List<IRobber> rolodex = new List<IRobber>
      {
        // For now pre-populate the list with 5 or 6 robbers (give it a mix of Hackers, Lock Specialists, and Muscle).
        new Hacker
        {
          Name = "Todd",
          SkillLevel = 50,
          PercentageCut = 5,
        },
        new Hacker
        {
          Name = "Patti",
          SkillLevel = 42,
          PercentageCut = 5,
        },
        new Muscle
        {
          Name = "Gabe",
          SkillLevel = 10,
          PercentageCut = 5,
        },
        new Muscle
        {
          Name = "Aaron",
          SkillLevel = 77,
          PercentageCut = 5,
        },
        new LockSpecialist
        {
          Name = "Jordan",
          SkillLevel = 20,
          PercentageCut = 5,
        },
        new LockSpecialist
        {
          Name = "Tommy",
          SkillLevel = 15,
          PercentageCut = 5,
        }
      };

      // When the program starts, print out the number of current operatives in the roladex.
      Console.WriteLine($"\nThere are {rolodex.Count} people we could call. Plus the Ghostbusters.");

      // Prompt the user to enter the name of a new possible crew member. This is beginning of method that will continue adding new members until given a blank name
      string userName = null;
      while (userName != "")
      {
        Console.WriteLine("\nDo you know another accomplice? (Enter a name now. Hit 'enter' key without any name to move on.)");
        userName = Console.ReadLine();
        // Terminate the while loop immediately if the user enters nothing
        if (userName == "")
        {
          break;
        }

        // Print out a list of possible specialties and have the user select which specialty this operative has.
        // I made a dictionary with all three specialities
        Dictionary<string, string> skillsSelect = new Dictionary<string, string>()
      {
        {"A","Hacker (Disables alarms)"},
        {"B","Muscle (Disarms guards)"},
        {"C","Lock Specialist (cracks vault)"}
      };
        Console.WriteLine("\nWhat specialty are they known for?" +
                          $"\na: {skillsSelect["A"]}" +
                          $"\nb: {skillsSelect["B"]}" +
                          $"\nc: {skillsSelect["C"]}");
        // Then have the user type just the letter of choice in list to save that specialty.
        string cki = Console.ReadKey(true).Key.ToString();
        string userSkill = null;
        //  Use error handling in case the user doesn't pick from the list.
        try
        {
          // Save just the name of the class of robber from the selected pick
          userSkill = skillsSelect[cki].Substring(0, skillsSelect[cki].IndexOf("(")).Replace(" ", string.Empty);
        }
        catch (KeyNotFoundException)
        {
          Console.WriteLine("\nYou didn't pick one of the three options. Try again.");
          // Give the user one more chance to pick from the list
          try
          {
            Console.WriteLine("\nWhat specialty are they known for?" +
                          $"\n{skillsSelect["A"]}" +
                          $"\n{skillsSelect["B"]}" +
                          $"\n{skillsSelect["C"]}");
            cki = Console.ReadKey(true).Key.ToString();
            // Save just the name of the class of robber from the selected pick
            userSkill = skillsSelect[cki].Substring(0, skillsSelect[cki].IndexOf("(")).Replace(" ", string.Empty);
          }
          catch (KeyNotFoundException)
          {
            Console.WriteLine("\nYou are trying to cause problems, good day sir.");
            Environment.Exit(0);
          }
        }

        // Prompt the user to enter the new member's skill level
        int userLevel = -1;
        // Keep asking for skill level if integer does not fall in required range
        while (userLevel < 1 || userLevel > 100)
        {
          Console.WriteLine($"\nWhat is {userName}'s skill level? (Enter an integer between 1-100)");
          // Make sure the skill level is an integer
          try
          {
            userLevel = Convert.ToInt32(Console.ReadLine());
          }
          catch (FormatException)
          {
            Console.WriteLine("Please enter only an integer value for skill level.");
            // Give second change to enter a correct number
            try
            {
              userLevel = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
              Console.WriteLine("Fine. Goodbye");
              Environment.Exit(0);
            }
          }
        }

        // Once all data has been gathered, add the new member to the rolodex. Use if statement to add different classes

        if (userSkill == "Hacker")
        {
          Hacker newMember = new Hacker
          {
            Name = userName,
            SkillLevel = userLevel,
          };
          // Add newly created member to rolodex
          rolodex.Add(newMember);
        }
        else if (userSkill == "Muscle")
        {
          Muscle newMember = new Muscle
          {
            Name = userName,
            SkillLevel = userLevel,
          };
          // Add newly created member to rolodex
          rolodex.Add(newMember);
        }
        else
        {
          LockSpecialist newMember = new LockSpecialist
          {

            Name = userName,
            SkillLevel = userLevel,
          };
          // Add newly created member to rolodex
          rolodex.Add(newMember);
        }
      }

      // Part 5. Create a bank object with random property values and report about the bank's details
      Bank targetBranch = new Bank
      {
        AlarmScore = new Random().Next(0, 100),
        VaultScore = new Random().Next(0, 100),
        SecurityGuardScore = new Random().Next(0, 100),
        CashOnHand = new Random().Next(50000, 1000000)
      };

      // Print a recon report on bank for the user listing most secure and least secure score by name
      // Save each bank score to easily compare
      int a = targetBranch.AlarmScore;
      int b = targetBranch.VaultScore;
      int c = targetBranch.SecurityGuardScore;
      // Find largest with a ternary comparison
      string mostSecureSystem = (a > b && a > c) ? "Alarm System" : (b > a && b > c) ? "Vault Lock" : (c > a && c > b) ? "Security Guard" : "Multiple systems are equally high security";
      string leastSecureSystem = (a < b && a < c) ? "Alarm System" : (b < a && b < c) ? "Vault Lock" : (c < a && c < b) ? "Security Guard" : "Multiple systems are equally low security";
      
      Console.WriteLine("\n-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*" +
                        "\n-*-*-*-*-*-*RECON REPORT READOUT-*-*-*-*-*-*");
      Console.WriteLine($"\nMost Secure: {mostSecureSystem}"+
                        $"\nLeast Secure: {leastSecureSystem}");
      
      // Part 6. Execute the heist
      // Print the entire rolodex with an index to select members
      Console.WriteLine("\n-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*" +
                        "\n-*-*-*-*-*-*ROLODEX REPORT READOUT-*-*-*-*-*");
      // Use for loop construction instead of foreach to easily print an index for user to select
      for (int i=0; i < rolodex.Count; i++)
      {
        Console.WriteLine($"\nEntry: {i+1}");
        Console.WriteLine($"Name:.......................{rolodex[i].Name}");
        Console.WriteLine($"Specialty:..................{rolodex[i].Specialty}");
        Console.WriteLine($"Skill (1-100):..............{rolodex[i].SkillLevel}");
        Console.WriteLine($"Percent of Cut:.............{rolodex[i].PercentageCut}");
      }

      // Create a new list for the actual crew and use the printed index to add members to the list
      List<IRobber> crew = new List<IRobber>{};
      Console.WriteLine($"\nWhich contact would you like to add to our team? (Enter the entry number value)");
      int selectedEntry = Convert.ToInt32(Console.ReadLine())-1;
      crew.Add(rolodex[selectedEntry]);
      
      // Continue adding eligible members until the user enters a blank value
      bool addContact = true;
      while (addContact == true)
      {  
        // Print out the remaining eligible rolodex entries after each selection. If they are already added or have to big of a cut don't list them. Still need to add screening for the percentage cut
        
        // Make a new list of remaining contacts and add an object from this list to the crew if selected. Check if entry already exists in the crew list. We are assuming unique names for an id here. Could add ID to the class properties later
        List<IRobber> remainingContacts = rolodex.Where(foo => !crew.Any(bar => bar.Name == foo.Name)).ToList();  
        // Print the eligible list, only if there are any contacts remaining tpo choose
        if (remainingContacts.Count != 0)
        {
          Console.WriteLine("\n-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*" +
                          "\n-*-*-*-*-*-*ROLODEX REPORT READOUT-*-*-*-*-*");
          // Use for loop construction instead of foreach to easily print an index for user to select
          for (int i=0; i < remainingContacts.Count; i++)
          {
            Console.WriteLine($"\nEntry: {i+1}");
            Console.WriteLine($"Name:.......................{remainingContacts[i].Name}");
            Console.WriteLine($"Specialty:..................{remainingContacts[i].Specialty}");
            Console.WriteLine($"Skill (1-100):..............{remainingContacts[i].SkillLevel}");
            Console.WriteLine($"Percent of Cut:.............{remainingContacts[i].PercentageCut}");
          }

          // Ask user to add a new member, or move on if blank
          Console.WriteLine($"\nWhich contact would you like to add to our growing team? (Enter the entry number value)");
          try
          {
            int index = Convert.ToInt32(Console.ReadLine());
            // If the user picked an index, add that contact to the existing crew list.
            crew.Add(remainingContacts[index-1]);
          }
          catch (FormatException)
          {
            addContact = false;
            break;
          }
          catch (ArgumentOutOfRangeException)
          {
            Console.WriteLine("You did not pick an entry in the list. Try again");
          }
        }
        else
        {
          addContact = false;
          break;
        }
      }

      // Have each crew member perform their skills on the bank
      foreach(IRobber accomplice in crew)
      {
        accomplice.PerformSkill(targetBranch);
      }

      // Evaluate bank's security after heist attempt and print result
      if (targetBranch.IsSecure)
      {
        Console.WriteLine("Your team failed the heist. Better luck next time");
      }
      else
      {
        // When successful, print out report listing the amount each person gets based on their percentage
        Console.WriteLine($"You did it! Your team made it out with {targetBranch.CashOnHand} dollars");
      }
    }
  }
}

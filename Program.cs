// Command line application to let user create characters for a bank heist and build a team roster to compete against a bank's security values
using System;
using System.Collections.Generic;
using System.Linq;

namespace heist_2
{
  class Program
  {
    static void Main(string[] args)
    {
      // Start the app by printing a welcome message.
      Console.WriteLine("\n-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$" +
                        "\n-$-$-$-$-$-$-$-$-$-HEIST 2: THE COMEBACK-$-$-$-$-$-$-$-$-$-$" +
                        "\n-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$");

      // Part 4. Create a List<IRobber>, store it in a variable named rolodex, and prepopulate with several characters. Then let user add new characters to the rolodex
      List<IRobber> rolodex = new List<IRobber>
      {
        // For now pre-populate the list with 5 or 6 robbers (give it a mix of Hackers, Lock Specialists, and Muscle).
        new Hacker
        {
          Name = "Todd",
          SkillLevel = 60,
          PercentageCut = 10,
        },
        new Hacker
        {
          Name = "Patti",
          SkillLevel = 45,
          PercentageCut = 15,
        },
        new Muscle
        {
          Name = "Gabe",
          SkillLevel = 25,
          PercentageCut = 25,
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
          SkillLevel = 85,
          PercentageCut = 45,
        },
        new LockSpecialist
        {
          Name = "Tommy",
          SkillLevel = 15,
          PercentageCut = 35,
        }
      };

      // When the program starts, print out the number of characters already in the roladex.
      Console.WriteLine($"\nThere are {rolodex.Count} people we could call. Plus the Ghostbusters.");

      // Prompt the user to enter the name of a new possible crew member. This is beginning of our method that will continue adding new members until given a blank name

      /*
        Q for Jordan: What is the best way to write a method that loops until the user exits. If the user enters a blank name, the other functions in the while loop still run once, the while loop doesn't terminate immediately. I added a hack that inserts a break if the userName is blank, forcing the while loop to end
      */
      string userName = null;
      while (userName != "")
      {
        Console.WriteLine("\nDo you know another accomplice? (Enter a name now. Hit the 'enter' key without any text to move to next step.)");
        userName = Console.ReadLine();
        // Hack - Terminate the while loop immediately if the user enters nothing
        if (userName == "")
        {
          break;
        }
        // Print out a list of possible specialties and have the user select which specialty this operative has.
        // I made a dictionary with all three specialities to accomplish this step. Key is a capital letter to match console key returned.
        Dictionary<string, string> skillsSelect = new Dictionary<string, string>()
        {
          {"A","Hacker (Disables alarms)"},
          {"B","Muscle (Disarms guards)"},
          {"C","Lock Specialist (Cracks vault)"}
        };
        // Print the list of options in the dictionary
        Console.WriteLine("\nWhat specialty are they known for?" +
                          $"\na: {skillsSelect["A"]}" +
                          $"\nb: {skillsSelect["B"]}" +
                          $"\nc: {skillsSelect["C"]}");
        // Then have the user type just the letter of choice in list to save that specialty. ReadKey only accepts the first character typed.
        string cki = Console.ReadKey(true).Key.ToString();
        string userSkill = null;
        // Use error handling in case the user doesn't pick from the list.
        /*
          Wrap in a while loop to make continuos attempts until valid result
        */
        try
        {
          // Save just the name for the class of robber from the dictionary value.
          userSkill = skillsSelect[cki].Substring(0, skillsSelect[cki].IndexOf("(")).Replace(" ", string.Empty);
        }
        catch (KeyNotFoundException) // User didn't type one of the 3 choices
        {
          Console.WriteLine("\nYou didn't pick one of the three options. Try again.");
          // Give the user one more chance to pick from the list
          try
          {
            Console.WriteLine("\nWhat specialty are they known for?" +
                          $"\na: {skillsSelect["A"]}" +
                          $"\nb: {skillsSelect["B"]}" +
                          $"\nc: {skillsSelect["C"]}");
            cki = Console.ReadKey(true).Key.ToString();
            // Save just the name of the class of robber from the selected pick
            userSkill = skillsSelect[cki].Substring(0, skillsSelect[cki].IndexOf("(")).Replace(" ", string.Empty);
          }
          catch (KeyNotFoundException) // User didn't type a valid choice again, exit the application this time.
          {
            Console.WriteLine("\nYou are trying to cause problems, good day sir.");
            Environment.Exit(0);
          }
        }

        // Prompt the user to enter the new member's skill level.
        int userLevel = 0;
        // Keep asking for skill level if integer does not fall in required range. This will rewrite the value until the user enters an interger between 1 and 100.
        /*
          Add a parameter that auto increments when the while loop runs and change the console writeline based on the value to change directions after multiple attempts. Or can move the first direction outside loop and then properly place the second directions in the catch handler.
        */
        while (userLevel < 1 || userLevel > 100)
        {
          Console.WriteLine($"\nWhat is {userName}'s skill level? (Enter an integer between 1-100)");
          // Make sure the skill level is an integer
          try
          {
            userLevel = Convert.ToInt32(Console.ReadLine());
          }
          catch (FormatException) // User did not enter an integer value
          {
            Console.WriteLine("Please enter only an integer value for skill level.");
            // Give second change to enter a correct number
            try
            {
              userLevel = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException) // User did not enter an integer again, exit the application this time.
            {
              Console.WriteLine("Fine. Goodbye");
              Environment.Exit(0);
            }
          }
        }

        // Prompt the user to enter the new member's percentage cut. This is the same method as for skill level. It was not asked for in the original instructions but added becuase percentage cut is used for eligibility at the end.
        double userCut = 0;
        // Keep asking for their cut if it does not fall in required range. This will rewrite the value until the user enters an interger between 1 and 100.
        while (userCut < 1 || userCut > 100)
        {
          Console.WriteLine($"\nWhat is {userName}'s percentage cut? (Enter an value between 1-100)");
          // Make sure the response is a number
          try
          {
            userCut = Convert.ToInt32(Console.ReadLine());
          }
          catch (FormatException) // User did not enter a number value
          {
            Console.WriteLine("Please enter only a numerical value for percentage cut.");
            // Give second change to enter a correct number
            try
            {
              userCut = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException) // User did not enter an integer again, exit the application this time.
            {
              Console.WriteLine("You're tough. Peace");
              Environment.Exit(0);
            }
          }
        }
        // FINALLY all the information for a new character has been saved. Once all data has been gathered, add the new member to the rolodex. Use an if statement to add different classes, I could not find a good way to dynamically write a Type using a saved string.
        if (userSkill == "Hacker")
        {
          Hacker newMember = new Hacker
          {
            Name = userName,
            SkillLevel = userLevel,
            PercentageCut = userCut,
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
            PercentageCut = userCut,
          };
          // Add newly created member to rolodex
          rolodex.Add(newMember);
        }
        else // If not a Hacker or Muscle, then it has to be a Lock specialist.
        {
          LockSpecialist newMember = new LockSpecialist
          {

            Name = userName,
            SkillLevel = userLevel,
            PercentageCut = userCut,
          };
          // Add newly created member to rolodex
          rolodex.Add(newMember);
        }
        // After the new character is successfully added, start over again and ask the user if they want to add any more people. If not, move on to picking a roster for the heist.
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
      // Find largest with a ternary comparison. If a tie, say that multiple systems match.
      string mostSecureSystem = (a > b && a > c) ? "Alarm System" : (b > a && b > c) ? "Vault Lock" : (c > a && c > b) ? "Security Guard" : "Multiple systems are equally high security";
      string leastSecureSystem = (a < b && a < c) ? "Alarm System" : (b < a && b < c) ? "Vault Lock" : (c < a && c < b) ? "Security Guard" : "Multiple systems are equally low security";
      // Print report
      Console.WriteLine("\n-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$" +
                        "\n-$-$-$-$-$-$-$-$-$-$-$RECON REPORT READOUT-$-$-$-$-$-$-$-$-$-$-$");
      Console.WriteLine($"\nMost Secure: {mostSecureSystem}" +
                        $"\nLeast Secure: {leastSecureSystem}");

      // Part 6. Execute the heist
      // Print the entire rolodex with an index to select members
      Console.WriteLine("\n-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$" +
                        "\n-$-$-$-$-$-$-$-$-$ROLODEX REPORT READOUT-$-$-$-$-$-$-$-$-$-$");
      // Use for loop construction instead of foreach to easily print an index for user to select
      for (int i = 0; i < rolodex.Count; i++)
      {
        Console.WriteLine($"\nEntry: {i + 1}");
        Console.WriteLine($"Name:.................................{rolodex[i].Name}");
        Console.WriteLine($"Specialty:............................{rolodex[i].Specialty}");
        Console.WriteLine($"Skill (1-100):........................{rolodex[i].SkillLevel}");
        Console.WriteLine($"Percent of Cut:.......................{rolodex[i].PercentageCut}");
      }

      // Create a new list for the actual crew and use the printed index to add members to the list
      List<IRobber> crew = new List<IRobber> { };
      // Console.WriteLine(rolodex[0].GetId());
      // Console.WriteLine(rolodex[1].GetId());
      // Console.WriteLine(rolodex[2].GetId());
      // Console.WriteLine(rolodex[3].GetId());
      // Console.WriteLine(rolodex[4].GetId());
      // Console.WriteLine(rolodex[5].GetId());
      Console.WriteLine($"\nWhich contact would you like to add to our team? (Enter the entry number value)");
      int selectedEntry = Convert.ToInt32(Console.ReadLine()) - 1;
      crew.Add(rolodex[selectedEntry]);
      //Console.WriteLine(crew[0].GetId());

      // Continue adding eligible members until the user enters a blank value
      bool addContact = true;
      while (addContact == true)
      {
        // Print out the remaining eligible rolodex entries after each selection. If they are already added or have too big of a cut don't list them.

        // Make a new placeholder list of remaining contacts and add an object from this list to the crew if selected. Check if entry already exists in the crew list. At first I assumed unique names, now using unique ID generated when object was created
        List<IRobber> unpickedRolodex = rolodex.Where(foo => !crew.Any(bar => bar.GetId() == foo.GetId())).ToList();
        // Take the placeholder and make a new list of only unpicked robbers that also have a small enough percentage (Their cut plus the current split is less than 100).
        List<IRobber> remainingContacts = new List<IRobber>() { };
        double crewPercent = crew.Sum(robber => robber.PercentageCut);
        foreach (IRobber r in unpickedRolodex)
        {
          if (crewPercent + r.PercentageCut <= 100)
          {
            remainingContacts.Add(r);
          }
        }
        // Print the eligible list, only if there are any contacts remaining tpo choose
        if (remainingContacts.Count != 0)
        {
          Console.WriteLine("\n-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$" +
                          "\n-$-$-$-$-$-$-$-$-$-$ROLODEX REPORT READOUT-$-$-$-$-$-$-$-$-$-$");
          // Use for loop construction instead of foreach to easily print an index for user to select
          for (int i = 0; i < remainingContacts.Count; i++)
          {
            Console.WriteLine($"\nEntry: {i + 1}");
            Console.WriteLine($"Name:.................................{remainingContacts[i].Name}");
            Console.WriteLine($"Specialty:............................{remainingContacts[i].Specialty}");
            Console.WriteLine($"Skill (1-100):........................{remainingContacts[i].SkillLevel}");
            Console.WriteLine($"Percent of Cut:.......................{remainingContacts[i].PercentageCut}");
          }

          // Ask user to add a new member, or move on if blank.
          Console.WriteLine($"\nWhich contact would you like to add to our growing team? (Enter the entry number value)");
          try
          {
            int index = Convert.ToInt32(Console.ReadLine());
            // If the user picked an index, add that contact to the existing crew list.
            crew.Add(remainingContacts[index - 1]);
          }
          catch (FormatException) // User did not enter an integer
          {
            addContact = false;
            break;
          }
          catch (ArgumentOutOfRangeException) // User entered a number not in the index
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

      // Have each crew member perform their skills on the bank.
      Console.WriteLine("\n-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$-$" +
                        "\n-$-$-$-$-$-$-$-$-$-$-HEIST IN PROGRESS-$-$-$-$-$-$-$-$-$-$-$\n");
      foreach (IRobber r in crew)
      {
        r.PerformSkill(targetBranch);
      }
      // Evaluate bank's security after heist attempt and print result.
      if (targetBranch.IsSecure)
      {
        Console.WriteLine("\nYour team failed the heist. Better luck next time");
      }
      else
      {
        // When successful, print out report listing the amount each person gets based on their percentage.
        Console.WriteLine($"\n$$$ You did it! Y'all made it out with ${targetBranch.CashOnHand} dollars.");
        foreach (IRobber r in crew)
        {
          Console.WriteLine($"{r.Name} demanded {r.PercentageCut}% and is paid ${Math.Round(targetBranch.CashOnHand * (r.PercentageCut / 100),0)}.");
        }
        if (crew.Sum(robber => robber.PercentageCut) == 100) // Crew takes 100% of the money.
        {
          Console.WriteLine($"That leaves you, the mastermind, with ${Math.Round(((100 - crew.Sum(robber => robber.PercentageCut)) / 100) * targetBranch.CashOnHand, 0)}. Guess you aren't such a mastermind.");
        }
        else // I make a profit.
        {
          Console.WriteLine($"That leaves you, the mastermind, with ${Math.Round(((100 - crew.Sum(robber => robber.PercentageCut)) / 100) * targetBranch.CashOnHand, 0)}. That's better than nothing!");
        }
      }
    }
  }
}

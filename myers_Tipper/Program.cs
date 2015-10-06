//Dawn Myers
//ITDEV 110 Downtown
//Assignment 4 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace VTipper
{
    class VTipper
    {
        private static string restaurantName = "asdf"; //Name of restaurant
        private static decimal subTotal = 0.0m; //Amount on bill received

        static void Main(string[] args)
        {
            string tipOption = "Z"; //used to select an option for tipping
            decimal tipPercent = 0.0m; //percent of tip, used in option C
            decimal tipAmount = 0.0m; //dollar amount of tip
            decimal finalBill = 0.0m; //amount of final bill
            string exitString = "asdf"; //used to quit application
            int numberOfPeople = 0; //number of people in party, used in option B
            
            ConsoleSetup(); //set up console title and window size
            Intro(); //instructions on how to use the application
			
			//continues to prompt user to select a tip option until they choose to exit
            while (exitString != "N" && exitString != "n") 
            {
                tipOption = Options(); //allows user to select tip option
				
				//returns restaurant name
                restaurantName = InScreen("Please enter the name of the restaurant >> ");
				
				//returns bill received, before tip
                subTotal = decimal.Parse(InScreen("Please enter the amount of the bill >> "));

                if (tipOption == "A" || tipOption == "a") //if user selects option A
                {
					//calculates tip dollar amount and final bill
                    OptionATipCalc(subTotal, ref tipAmount, ref finalBill);
					
					//prints details of bill, and prompts user to continue or exit
                    exitString = OptionATotalBill(restaurantName, subTotal, tipAmount, finalBill);
                }
                else if (tipOption == "B" || tipOption == "b") //if user selects option B
                {
					//calculates tip dollar amount, final bill, and returns number of people in party
                    numberOfPeople = OptionBTipCalc(subTotal, ref tipAmount, ref finalBill); 
					
					//prints details of bill, and prompts user to continue or exit
                    exitString = OptionBTotalBill(restaurantName, subTotal, numberOfPeople, tipAmount, finalBill);
                }
                else //if user selects option C
                {
					//calculates tip dollar amount, final bill, and returns the tip percent
                    tipPercent = OptionCTipCalc(subTotal, ref tipAmount, ref finalBill);
					
					//prints details of bill, and prompts user to continue or exit
                    exitString = OptionCTotalBill(restaurantName, subTotal, tipAmount, tipPercent, finalBill);
                }
            }
        }

        public static void ConsoleSetup()
        {
            Console.Title = "Tip calculator"; //window title
            Console.SetWindowSize(105, 25); //window size, makes things easier to read
        }

		//displays instructions on how to use the application
        public static void Intro()
        {
            Console.WriteLine("Welcome to the tip calculator!");
            Thread.Sleep(500);
            Console.WriteLine("In this application, you will be prompted to enter the restaurant's name, and the bill you received.");
            Thread.Sleep(500);
            Console.WriteLine("You will then be prompted to select an option for calculating your tip:");
            Thread.Sleep(500);
            Console.WriteLine("\tEnter the percentage of the bill to tip");
            Thread.Sleep(500);
            Console.WriteLine("\tCalculating tip if splitting the bill");
            Thread.Sleep(500);
            Console.WriteLine("\tFind tip percent and tip amount if you tell the waitress to \"keep the change\"");
            Thread.Sleep(500);
            Console.Write("Press any key view and select the options...");
            Console.ReadKey();
            Console.Clear();
        }

		//displays tip options, and prompts user to select one
        public static string Options()
        {
            string tipOptionOptions = "asdf";

            Console.WriteLine("Listed below are the options for calculating a tip:");
            Thread.Sleep(500);
            Console.WriteLine("\tOption A) Enter a percent to tip");
            Thread.Sleep(500);
            Console.WriteLine("\tOption B) Calculate tip and total if splitting with friends");
            Thread.Sleep(500);
            Console.WriteLine("\tOption C) Calculate percent and tip if rounding to nearest bill");
            Thread.Sleep(500);
            Console.Write("Please enter \"A\", \"B\", or \"C\" to select an option >> ");
            tipOptionOptions = Console.ReadLine();
            Console.Clear();
			
			//if-else chain just confirms what the user selected
            if (tipOptionOptions == "A" || tipOptionOptions == "a")
            {
                Console.WriteLine("You selected to enter a percent to tip.");
            }
            else if (tipOptionOptions == "B" || tipOptionOptions == "b")
            {
                Console.WriteLine("You selected to split the bill with friends.");
            }
            else if (tipOptionOptions == "C" || tipOptionOptions == "c")
            {
                Console.WriteLine("You selected to find the tip if rounding up.");
            }
            else
            {
                //This is ugly. If the user didn't select a valid option, prompts them again
                while (tipOptionOptions != "A" && tipOptionOptions != "a" && tipOptionOptions != "B" && tipOptionOptions != "b" && tipOptionOptions != "C" && tipOptionOptions != "c")
                {
                    Console.Write("Please enter a valid option of either \"A\", \"B\", or \"C\" >> ");
                    tipOptionOptions = Console.ReadLine();
                }
            }
            Thread.Sleep(500);
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            return tipOptionOptions;
        }

		//My ghetto work-around for returning two values from a method.
		//This passes in a prompt to enter either the restaurant name, or the bill subtotal
		//Used in: restaurantName = InScreen("Please enter the name of the restaurant >> ");
		//Used in: subTotal = decimal.Parse(InScreen("Please enter the amount of the bill >> "));
        public static string InScreen(string oneOrTheOther)
        {
            string nameOrSubTotal = "asdf";

            Console.Write(oneOrTheOther);
            nameOrSubTotal = Console.ReadLine();
            Thread.Sleep(500);
            return nameOrSubTotal;
        }

		//Option A: Enter a percent to tip
		//passes in the subtotal, prompts user to enter a percent to tip, then calculates
		//dollar amount of tip and final bill
        public static void OptionATipCalc(decimal subTotalTCA, ref decimal tipAmountTCA, ref decimal finalBillTCA)
        {
            decimal tipPercentEntryTCA = 0.0m;
            decimal tipPercentTCA = 0.0m;

            Console.Write("Please enter the percent of the bill that you'd like to tip >> ");
            tipPercentEntryTCA = decimal.Parse(Console.ReadLine());
            tipPercentTCA = tipPercentEntryTCA / 100; //makes a percent out of an int entry
            Thread.Sleep(500);
            tipAmountTCA = subTotalTCA * tipPercentTCA; //subtotal * percent = tip dollar amount
            finalBillTCA = subTotalTCA + tipAmountTCA; //subtotal + tip = final bill
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

		//Prints details of bill. Prompts user to exit, or calculate another tip
        public static string OptionATotalBill(string restaurantNameTBA, decimal subTotalTBA, decimal tipAmountTBA, decimal finalBillTBA)
        {
            string exitStringTBA = "asdf";
            DateTime timeOfVisit = DateTime.Now;
            string timeOfVisitFormat = "MMM ddd HH:mm"; //format the date to look nice

            Console.WriteLine("Here are the results for your visit on " + timeOfVisit.ToString(timeOfVisitFormat) + ":");
            Thread.Sleep(500);
            Console.WriteLine("\tRestaurant Name: " + restaurantNameTBA);
            Thread.Sleep(500);
            Console.WriteLine("\tBill subtotal: {0:C}", subTotalTBA);
            Thread.Sleep(500);
            Console.WriteLine("\tDollar amount of tip: {0:C}", tipAmountTBA);
            Thread.Sleep(500);
            Console.WriteLine("\tTotal bill: {0:C}", finalBillTBA);
            Thread.Sleep(500);
            Console.Write("If you'd like to calculate another tip, press \"Y\". Otherwise, press \"N\" to exit >> ");
            exitStringTBA = Console.ReadLine();
            Console.Clear();
            return exitStringTBA; //return application-exit string
        }

		//Option B: Calculate tip and total if splitting with friends
		//Allows user to enter percent of bill to tip, and number of people to split it with
		//calculates tip dollar amount and final bill, before splitting
		//returns number of people that are splitting the bill
        public static int OptionBTipCalc(decimal subTotalTCB, ref decimal tipAmountTCB, ref decimal finalBillTCB)
        {
            int numberOfPeople = 0;
            decimal tipPercentEntryTCB = 0.0m;
            decimal tipPercentTCB = 0.0m;

            Console.Write("Please enter the percent of the bill that you'd like to tip. >> ");
            tipPercentEntryTCB = decimal.Parse(Console.ReadLine());
            tipPercentTCB = tipPercentEntryTCB / 100; //makes a percent out of an int entry
            Thread.Sleep(500);
            Console.Write("Please enter the number of people you'd like to split the bill with: >> ");
            numberOfPeople = int.Parse(Console.ReadLine());
            tipAmountTCB = subTotalTCB * tipPercentTCB; //subtotal * percent = tip dollar amount
            finalBillTCB = subTotalTCB + tipAmountTCB; //subtotal + tip = final bill
            Thread.Sleep(500);
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            return numberOfPeople; //returns number of people for displaying final bill when split
        }

		//Prints details of bill, and shows how much each person will pay if splitting the bill
		//Prompts user to exit, or calculate another tip
        public static string OptionBTotalBill(string restaurantNameTBB, decimal subTotalTBB, int numberOfPeopleTBB, decimal tipAmountTBB, decimal finalBillTBB)
        {
            string exitStringTBB = "asdf";
            DateTime timeOfVisit = DateTime.Now;
            string timeOfVisitFormat = "MMM ddd HH:mm"; //format date to look nice

            Console.WriteLine("Here are the results for your visit on " + timeOfVisit.ToString(timeOfVisitFormat) + ":");
            Thread.Sleep(500);
            Console.WriteLine("\tRestaurant Name: " + restaurantNameTBB);
            Thread.Sleep(500);
            Console.WriteLine("\tBill subtotal: {0:C}", subTotalTBB);
            Thread.Sleep(500);
            Console.WriteLine("\tDollar amount of tip: {0:C}", tipAmountTBB);
            Thread.Sleep(500);
            Console.WriteLine("\tTotal bill: {0:C}", finalBillTBB);
            Thread.Sleep(500);
            Console.WriteLine("\tTotal bill split between " + numberOfPeopleTBB + " people: {0:C}", (finalBillTBB / numberOfPeopleTBB)); //finds the amount each person in party will pay
            Thread.Sleep(500);
            Console.Write("If you'd like to calculate another tip, press \"Y\". Otherwise, press \"N\" to exit >> ");
            exitStringTBB = Console.ReadLine();
            Console.Clear();
            return exitStringTBB; //return application-exit string
        }

		//Option C: Calculate percent and tip if rounding to nearest bill
		//Prompts user to enter the bill that they would like to give the waitress, "keep the change"
		//Shows user what the dollar amount of the tip would be, and what percentage of the bill that tip would be
		//Returns the percent of the tip to display in the final bill
        public static decimal OptionCTipCalc(decimal subTotalTCC, ref decimal tipAmountTCC, ref decimal finalBillTCC)
        {
            string tryAnotherBill = "asdf";
			
			//The type of bill that will be given to waitress - $5, $10, $20, $50, and so on
            int dollarBill = 0;
            decimal tipPercentTCC = 0.0m;
			
			//While loop allows user to try other bills
            while (tryAnotherBill != "N" && tryAnotherBill != "n")
            {
                Console.Clear();
                Console.Write("Please enter the bill you'd like to give to the waitress, greater than $" + subTotalTCC + " >> ");
                dollarBill = int.Parse(Console.ReadLine());
                tipAmountTCC = dollarBill - subTotalTCC; //calculates what the tip dollar amount would be
				
				//Makes sure user isn't coming up short on bill
                while (dollarBill < subTotalTCC)
                {
                    Console.Write("Please enter a bill that is greater than your subtotal >> ");
                    dollarBill = int.Parse(Console.ReadLine());
                }
                finalBillTCC = dollarBill;
				
				//This is the equivalent of "find x": (tip dollar amount / subtotal) = (x / 100)
				//Also rounds it to two decimal points
                tipPercentTCC = Math.Round(((tipAmountTCC / subTotalTCC) * 100), 2);
                Console.WriteLine("If you gave the waitress a " + dollarBill + " dollar bill, your tip would be {0:C}", tipAmountTCC);
                Thread.Sleep(500);
                Console.WriteLine("This would come out to a " + tipPercentTCC + " percent tip.");
                Thread.Sleep(500);
				
				//Allows user to try another bill, or continue to display details of bill
                Console.Write("If you'd like to see your tip with another bill, press \"Y\". Otherwise, press \"N\" to continue >> ");
                tryAnotherBill = Console.ReadLine();
            }
            Console.Clear();
            return tipPercentTCC; //returns tip percent
        }

		//displays details of bill. Prompts user to exit, or calculate another tip
        public static string OptionCTotalBill(string restaurantNameTBC, decimal subTotalTBC, decimal tipAmountTBC, decimal tipPercentTBC, decimal finalBillTBC)
        {
            string exitStringTBC = "asdf";
            DateTime timeOfVisit = DateTime.Now;
            string timeOfVisitFormat = "MMM ddd HH:mm";

            Console.WriteLine("Here are the results for your visit on " + timeOfVisit.ToString(timeOfVisitFormat) + ":");
            Thread.Sleep(500);
            Console.WriteLine("\tRestaurant Name: " + restaurantNameTBC);
            Thread.Sleep(500);
            Console.WriteLine("\tBill subtotal: {0:C}", subTotalTBC);
            Thread.Sleep(500);
            Console.WriteLine("\tDollar amount of tip: {0:C}", tipAmountTBC);
            Thread.Sleep(500);
            Console.WriteLine("\tPercent of bill being tipped: " + tipPercentTBC + "%");
            Thread.Sleep(500);
            Console.WriteLine("\tTotal bill: {0:C}", finalBillTBC);
            Thread.Sleep(500);
            Console.Write("If you'd like to calculate another tip, press \"Y\". Otherwise, press \"N\" to exit >> ");
            exitStringTBC = Console.ReadLine();
            Console.Clear();
            return exitStringTBC; //return application-exit string
        }
    }
}

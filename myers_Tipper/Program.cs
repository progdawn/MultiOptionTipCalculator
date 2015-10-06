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
        private static string restaurantName = "asdf";
        private static decimal subTotal = 0.0m;

        static void Main(string[] args)
        {
            string tipOption = "Z";
            decimal tipPercent = 0.0m;
            decimal tipAmount = 0.0m;
            decimal finalBill = 0.0m;
            string exitString = "asdf";
            int numberOfPeople = 0;
            
            ConsoleSetup();
            Intro();
            while (exitString != "N" && exitString != "n")
            {
                tipOption = Options();
                restaurantName = InScreen("Please enter the name of the restaurant >> ");
                subTotal = decimal.Parse(InScreen("Please enter the amount of the bill >> "));

                if (tipOption == "A" || tipOption == "a")
                {
                    OptionATipCalc(subTotal, ref tipAmount, ref finalBill);
                    exitString = OptionATotalBill(restaurantName, subTotal, tipAmount, finalBill);
                }
                else if (tipOption == "B" || tipOption == "b")
                {
                    numberOfPeople = OptionBTipCalc(subTotal, ref tipAmount, ref finalBill);
                    exitString = OptionBTotalBill(restaurantName, subTotal, numberOfPeople, tipAmount, finalBill);
                }
                else
                {
                    tipPercent = OptionCTipCalc(subTotal, ref tipAmount, ref finalBill);
                    exitString = OptionCTotalBill(restaurantName, subTotal, tipAmount, tipPercent, finalBill);
                }
            }
        }

        public static void ConsoleSetup()
        {
            Console.Title = "Tip calculator";
            Console.SetWindowSize(105, 25);
        }

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

        public static string Options()
        {
            string tipOptionOptions = "BACK";

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
                //This is horrendous. I'm sure there's a better way to do this. 
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

        public static string InScreen(string oneOrTheOther)
        {
            string nameOrSubTotal = "asdf";

            Console.Write(oneOrTheOther);
            nameOrSubTotal = Console.ReadLine();
            Thread.Sleep(500);
            return nameOrSubTotal;
        }

        public static void OptionATipCalc(decimal subTotalTCA, ref decimal tipAmountTCA, ref decimal finalBillTCA)
        {
            decimal tipPercentEntry = 0.0m;
            decimal tipPercentTipCalcA = 0.0m;

            Console.Write("Please enter the percent of the bill that you'd like to tip >> ");
            tipPercentEntry = decimal.Parse(Console.ReadLine());
            tipPercentTipCalcA = tipPercentEntry / 100;
            Thread.Sleep(500);
            tipAmountTCA = subTotalTCA * tipPercentTipCalcA;
            finalBillTCA = subTotalTCA + tipAmountTCA;
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static string OptionATotalBill(string restaurantNameTBA, decimal subTotalTBA, decimal tipAmountTBA, decimal finalBillTBA)
        {
            string exitStringTBA = "asdf";
            DateTime timeOfVisit = DateTime.Now;
            string timeOfVisitFormat = "MMM ddd HH:mm";

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
            Console.Write("If you'd like to calculate another tip, press \"Y\". Otherwise, press \"N\" >> ");
            exitStringTBA = Console.ReadLine();
            Console.Clear();
            return exitStringTBA;
        }

        public static int OptionBTipCalc(decimal subTotalTCB, ref decimal tipAmountTCB, ref decimal finalBillTCB)
        {
            //If there are multiple people in the party, provide individual total amounts
            int numberOfPeople = 0;
            decimal tipPercentEntryTCB = 0.0m;
            decimal tipPercentTCB = 0.0m;

            Console.Write("Please enter the percent of the bill that you'd like to tip. >> ");
            tipPercentEntryTCB = decimal.Parse(Console.ReadLine());
            tipPercentTCB = tipPercentEntryTCB / 100;
            Thread.Sleep(500);
            Console.Write("Please enter the number of people you'd like to split the bill with: >> ");
            numberOfPeople = int.Parse(Console.ReadLine());
            tipAmountTCB = (subTotalTCB * tipPercentTCB);
            finalBillTCB = (subTotalTCB + tipAmountTCB); ;
            Thread.Sleep(500);
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            return numberOfPeople;
        }

        public static string OptionBTotalBill(string restaurantNameTBB, decimal subTotalTBB, int numberOfPeopleTBB, decimal tipAmountTBB, decimal finalBillTBB)
        {
            string exitStringTBB = "asdf";
            DateTime timeOfVisit = DateTime.Now;
            string timeOfVisitFormat = "MMM ddd HH:mm";

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
            Console.WriteLine("\tTotal bill split between " + numberOfPeopleTBB + " people: {0:C}", (finalBillTBB / numberOfPeopleTBB));
            Thread.Sleep(500);
            Console.Write("If you'd like to calculate another tip, press \"Y\". Otherwise, press \"N\" >> ");
            exitStringTBB = Console.ReadLine();
            Console.Clear();
            return exitStringTBB;
        }

        public static decimal OptionCTipCalc(decimal subTotalTCC, ref decimal tipAmountTCC, ref decimal finalBillTCC)
        {
            string tryAnotherBill = "asdf";
            int dollarBill = 0;
            decimal tipPercentTCC = 0.0m;

            while (tryAnotherBill != "N" && tryAnotherBill != "n")
            {
                Console.Clear();
                Console.Write("Please enter the bill you'd like to give to the waitress, greater than $" + subTotalTCC + " >> ");
                dollarBill = int.Parse(Console.ReadLine());
                tipAmountTCC = dollarBill - subTotalTCC;
                while (dollarBill < subTotalTCC)
                {
                    Console.Write("Please enter a bill that is greater than your subtotal >> ");
                    dollarBill = int.Parse(Console.ReadLine());
                }
                finalBillTCC = dollarBill;
                tipPercentTCC = Math.Round(((tipAmountTCC / subTotalTCC) * 100), 2);
                Console.WriteLine("If you gave the waitress a " + dollarBill + " dollar bill, your tip would be {0:C}", tipAmountTCC);
                Thread.Sleep(500);
                Console.WriteLine("This would come out to a " + tipPercentTCC + " percent tip.");
                Thread.Sleep(500);
                Console.Write("If you'd like to see your tip with another bill, press \"Y\". Otherwise, press \"N\" >> ");
                tryAnotherBill = Console.ReadLine();
            }
            Console.Clear();
            return tipPercentTCC;
        }

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
            Console.Write("If you'd like to calculate another tip, press \"Y\". Otherwise, press \"N\" >> ");
            exitStringTBC = Console.ReadLine();
            Console.Clear();
            return exitStringTBC;
        }
    }
}

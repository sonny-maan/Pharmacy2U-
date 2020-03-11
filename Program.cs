using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using NUnit.Framework;

namespace Pharmacy2U_Tech_Test
{
    class Program
{
    static void displayMenu() { //Drawing main menu
    Console.WriteLine("\n1.  GBP To USD");
    Console.WriteLine("2.  GBP To AUD");
    Console.WriteLine("3.  GBP To EUR");
    Console.WriteLine("\n4.  USD To GBP");
    Console.WriteLine("5.  USD To AUD");
    Console.WriteLine("6.  USD To EUR");
    Console.WriteLine("\n7.  AUD To GBP");
    Console.WriteLine("8.  AUD To USD");
    Console.WriteLine("9.  AUD To EUR");
    Console.WriteLine("\n10. EUR To GBP");
    Console.WriteLine("11. EUR To USD");
    Console.WriteLine("12. EUR To AUD");
    Console.WriteLine("\n13. View Previous Conversions");
    Console.WriteLine("\n14. Exit");
    Console.Write("\nSelect Option =>    ");
    }
    static void Main(string[] args) {
    double[] arrayConversionRates = new double[12]; //Declare array to hold conversion rates
    double GBP = 0;

    //Conversion rate constant values
    const double GBP_TO_USD = 1.30464;
    const double GBP_TO_AUD = 1.96529;
    const double GBP_TO_EUR = 1.15400;
    const double USD_TO_GBP = 0.762499;
    const double USD_TO_AUD = 1.51823;
    const double USD_TO_EUR = 0.873643;
    const double AUD_TO_GBP = 0.502240;
    const double AUD_TO_USD = 0.658642;
    const double AUD_TO_EUR = 0.575488;
    const double EUR_TO_GBP = 0.872728;
    const double EUR_TO_USD = 1.14442;
    const double EUR_TO_AUD = 1.73754;

    arrayConversionRates[0] = GBP_TO_USD;
    arrayConversionRates[1] = GBP_TO_AUD;
    arrayConversionRates[2] = GBP_TO_EUR;
    arrayConversionRates[3] = USD_TO_GBP;
    arrayConversionRates[4] = USD_TO_AUD;
    arrayConversionRates[5] = USD_TO_EUR;
    arrayConversionRates[6] = AUD_TO_GBP;
    arrayConversionRates[7] = AUD_TO_USD;
    arrayConversionRates[8] = AUD_TO_EUR;
    arrayConversionRates[9] = EUR_TO_GBP;
    arrayConversionRates[10] = EUR_TO_USD;
    arrayConversionRates[11] = EUR_TO_AUD;

    double USD = 0;
    double AUD = 0;
    double EUR = 0;
    double ConversionResult = 0;
    int userOption = 0;
    bool flag = false;
    bool d = false;

    
    do {
    flag = false;
    string value = "";
    displayMenu(); //Loads user options to console
    userOption = Convert.ToInt32(Console.ReadLine());
    
    while (userOption < 1 || userOption > 14) {
      Console.Write("\nInvalid Option! Choose correct one:   "); //User can only enter menu options
      userOption = Convert.ToInt32(Console.ReadLine());
     }
 
         if (userOption <= 3) //Validation on GBP conversions (no negatives, only 2 Decimal Places)
     {

      flag = false;
      while (flag == false) {
       Console.Write("\nEnter GBP Amount:  ");
       value = Console.ReadLine();

       if (Convert.ToDouble(value) < 0) {
        Console.WriteLine("No Negatives Allowed.");
        flag = false;
       } else {
        d = false;
        foreach(char ch in value) {
         if (ch == '.') {
          d = true;
         }
        }
        if (d == true) {
         int len = value.Substring(value.IndexOf(".")).Length;
         if (len > 3)
          Console.WriteLine("\nOnly to two decimal places please.");
         else
          flag = true;
        } else {
         flag = true;
        }

       }
      }
      GBP = Convert.ToDouble(value);
       } else if (userOption <= 6) //Validation on USD conversions (no negatives, only 2 Decimal Places)
     {
      flag = false;
      while (flag == false) {
       Console.Write("\nEnter USD Amount:  ");
       value = Console.ReadLine();

       if (Convert.ToDouble(value) < 0) {
        Console.WriteLine("No Negatives Allowed.");
        flag = false;
       } else {
        d = false;
        foreach(char ch in value) {
         if (ch == '.') {
          d = true;
         }
        }
        if (d == true) {
         int len = value.Substring(value.IndexOf(".")).Length;
         if (len > 3)
          Console.WriteLine("\nOnly to two decimal places please.");
         else
          flag = true;
        } else {
         flag = true;
        }

       }
      }
      USD = Convert.ToDouble(value);
     } 
     else if (userOption <= 9) //Validation on AUD conversions (no negatives, only 2 Decimal Places)
     {
      flag = false;
      while (flag == false) {
       Console.Write("\nEnter AUD Amount:  ");
       value = Console.ReadLine();

       if (Convert.ToDouble(value) < 0) {
        Console.WriteLine("No Negatives Allowed.");
        flag = false;
       } else {
        d = false;
        foreach(char ch in value) {
         if (ch == '.') {
          d = true;
         }
        }
        if (d == true) {
         int len = value.Substring(value.IndexOf(".")).Length;
         if (len > 3)
          Console.WriteLine("\nOnly to two decimal places please.");
         else
          flag = true;
        } else {
         flag = true;
        }

       }
      }
      AUD = Convert.ToDouble(value);
     } 
     else if (userOption <= 12) //Validation on EUR conversions (no negatives, only 2 Decimal Places)
     {
      flag = false;
      while (flag == false) {
       Console.Write("\nEnter EUR Amount:  ");
       value = Console.ReadLine();

       if (Convert.ToDouble(value) < 0) {
        Console.WriteLine("No Negatives Allowed.");
        flag = false;
       } else {
        d = false;
        foreach(char ch in value) {
         if (ch == '.') {
          d = true;
         }
        }
        if (d == true) {
         int len = value.Substring(value.IndexOf(".")).Length;
         if (len > 3)
          Console.WriteLine("\nOnly to two decimal places please.");
         else
          flag = true;
        } else {
         flag = true;
        }

       }
      }
      EUR = Convert.ToDouble(value);
     } 

     if (userOption == 1) {
      USD = GBP * arrayConversionRates[0];// Multiplying user input by GBP to USD rate
      Console.WriteLine("\n\n************************");
      string conversionmessage = GBP + " GBP = " + USD.ToString("F") + " USD"; //Making conversion message so it can be added to database
      Console.WriteLine(conversionmessage); //Printing message for user
      Console.WriteLine("************************");
     }
    else if (userOption == 2) {
      AUD = GBP * arrayConversionRates[1];// Multiplying user input by GBP to AUD rate
      Console.WriteLine("\n\n************************");
      string conversionmessage = GBP + " GBP = " + AUD.ToString("F") + " AUD";//Making conversion message so it can be added to database
      Console.WriteLine(conversionmessage);
      Console.WriteLine("************************");
    }
        else if (userOption == 3) {
      EUR = GBP * arrayConversionRates[2];// Multiplying user input by GBP to EUR rate
      Console.WriteLine("\n\n************************");
      string conversionmessage = GBP + " GBP = " + EUR.ToString("F") + " EUR";//Making conversion message so it can be added to database
      Console.WriteLine(conversionmessage);
      Console.WriteLine("************************");
        }

    else if (userOption == 4) {
      ConversionResult = USD * arrayConversionRates[3]; //Multiplying user input by to GBP rate
      Console.WriteLine("\n\n************************");
      string conversionmessage = USD + " USD = " + ConversionResult.ToString("F") + " GBP";//Making conversion message so it can be added to database
      Console.WriteLine(conversionmessage);
      Console.WriteLine("************************");
    }
       else if (userOption == 5) {
      ConversionResult = USD * arrayConversionRates[4]; //Multiplying user input by USD to AUD rate
      Console.WriteLine("\n\n************************");
      string conversionmessage = USD + " USD = " + ConversionResult.ToString("F") + " AUD";//Making conversion message so it can be added to database
      Console.WriteLine(conversionmessage);
      Console.WriteLine("************************");
       }
           else if (userOption == 6) {
      ConversionResult = USD * arrayConversionRates[5]; //Multiplying user input by USD to EUR rate
      Console.WriteLine("\n\n************************");
      string conversionmessage = USD + " USD = " + ConversionResult.ToString("F") + " EUR";
      Console.WriteLine(conversionmessage);
      Console.WriteLine("************************");
           }

    else if (userOption == 7) {
      ConversionResult = AUD * arrayConversionRates[6];//Multiplying user input by AUD to GBP rate
      Console.WriteLine("\n\n************************");
      string conversionmessage = AUD + " AUD = " + ConversionResult.ToString("F") + " GBP";
      Console.WriteLine(conversionmessage);
      Console.WriteLine("************************");
    }

    else if (userOption == 8) {
      ConversionResult = AUD * arrayConversionRates[7];//Multiplying user input by AUD to USD rate
      Console.WriteLine("\n\n************************");
      string conversionmessage = AUD + " AUD = " + ConversionResult.ToString("F") + " USD";
      Console.WriteLine(conversionmessage);
      Console.WriteLine("************************");
    }

    else if (userOption == 9) {
      ConversionResult = AUD * arrayConversionRates[8];//Multiplying user input by AUD to EUR rate
      Console.WriteLine("\n\n************************");
      string conversionmessage = AUD + " AUD = " + ConversionResult.ToString("F") + " EUR";
      Console.WriteLine(conversionmessage);
      Console.WriteLine("************************");
    }
    else if (userOption == 10) {
      ConversionResult = EUR * arrayConversionRates[9];//Multiplying user input by EUR to GBP rate
      Console.WriteLine("\n\n************************");
      string conversionmessage = EUR + " EUR = " + ConversionResult.ToString("F") + " GBP";
      Console.WriteLine(conversionmessage);
      Console.WriteLine("************************");
    }
       else if (userOption == 11) {
      ConversionResult = EUR * arrayConversionRates[10];//Multiplying user input by EUR to USD rate
      Console.WriteLine("\n\n************************");
      string conversionmessage = EUR + " EUR = " + ConversionResult.ToString("F") + " USD";
      Console.WriteLine(conversionmessage);
      Console.WriteLine("************************");
       }
    else if (userOption == 12) {
      ConversionResult = EUR * arrayConversionRates[11];//Multiplying user input by EUR to AUD rate
      Console.WriteLine("\n\n************************");
      string conversionmessage = EUR + " EUR = " + ConversionResult.ToString("F") + " AUD";
      Console.WriteLine(conversionmessage);
      Console.WriteLine("************************");
    }

    
    while (userOption != 14);

    Console.WriteLine("\n\n*****GOOD BYE*****\n\n");
    }


}

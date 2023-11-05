using System;
using System.Collections.Generic;
using System.Linq;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getNum(int pin) { return cardNum; }
    public int getPin() { return pin; }

    public string getFirstName() { return firstName; }

    public string getLastName() { return lastName; }

    public double getBalance() { return balance; }

    public void setNum(string newCardNum) { cardNum = newCardNum; }

    public void setPin(int newPin) { pin = newPin; }

    public void setFirstName(string newFirstName) { firstName = newFirstName; }

    public void setLastName(string newLastName) { lastName = newLastName; }

    public void setBalance(double newBalance) { balance = newBalance; }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose one from one of the following options..");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double deposit = 0;
            try
            {
                deposit = double.Parse(Console.ReadLine());
                currentUser.setBalance(currentUser.getBalance() + deposit);
                Console.WriteLine("You have deposited: $" + deposit);
                Console.WriteLine("Your new balance is: $" + currentUser.getBalance());
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a valid amount.");
            }
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawal = 0;
            try
            {
                withdrawal = double.Parse(Console.ReadLine());

                if (currentUser.getBalance() < withdrawal)
                {
                    Console.WriteLine("Insufficient balance.");
                }
                else
                {
                    currentUser.setBalance(currentUser.getBalance() - withdrawal);
                    Console.WriteLine("You have withdrawn: $" + withdrawal);
                    Console.WriteLine("Your current balance is :" + currentUser.getBalance());
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a valid amount.");
            }
        }

        void showBalance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: $" + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("123123123123", 1111, "Niklas", "Sjödin", 750.00));
        cardHolders.Add(new cardHolder("6666", 1111, "Linda", "Ohlsson", 1750.00));

        Console.WriteLine("Welcome to myATM!");
        Console.WriteLine("Please enter your debit card: ");
        string debitCardNum = "";
        cardHolder currentUser = null;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again.");
            }
        }

        Console.WriteLine("Please enter your PIN: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect pin. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect pin. Please try again.");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
                if (option >= 1 && option <= 4)
                {
                    // Valid option (1-4)
                    if (option == 1)
                    {
                        deposit(currentUser);
                    }
                    else if (option == 2)
                    {
                        withdraw(currentUser);
                    }
                    else if (option == 3)
                    {
                        showBalance(currentUser);
                    }
                    else if (option == 4)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Please select a valid option (1-4).");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a valid option (1-4).");
            }
        }
        while (option != 4);
        Console.WriteLine("Thank you. Have a nice day.");
    }
}
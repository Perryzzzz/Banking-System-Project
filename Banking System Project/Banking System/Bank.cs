using System;


public class Bank {
    private string name;
    private double currency;
    private string id;
    private CreditCard? card;
    private string password;
    private static List<Bank> bankAccounts = new List<Bank>();

    public Bank(string name, string id) {
        this.name = name;
        this.id = id;
        Console.Write("Enter A Custom And Strong Password For Your Bank Account: ");
        this.password = Console.ReadLine() ?? "";
        this.currency = 0;
        Console.WriteLine("Bank Account Created Successfully");
        bankAccounts.Add(this);
        //creating card is optional
    }

    //log-in
    public Bank(string name, string id, string password) {
        bool found = false;
        foreach(Bank bankAcc in bankAccounts) {
            if(bankAcc.GetName().Equals(name) && bankAcc.GetId().Equals(id) && bankAcc.GetPassword().Equals(password)) {
                this.name = name;
                this.id = id;
                this.password = password;
                this.currency = bankAcc.GetCurrency();
                found = true;
                return;
            }
        }
        if(!found) {
            Console.Write("This Bank Account Doesn't Exist, Would You Like To Open A New Bank Account With The Details You Entered? (y/n) ");
            char decision = char.Parse(Console.ReadLine() ?? "");
            while(true) {
                if(char.ToLower(decision) != 'y' && char.ToLower(decision) != 'n') {
                    Console.Write("Invalid Choice, Only 'Y' Or 'N' ");
                    decision = char.Parse(Console.ReadLine() ?? "");
                }
                else if(char.ToLower(decision) == 'n'){
                    Console.WriteLine("No Problem");
                    return;
                }
                else {
                    Console.WriteLine("Created Bank Account With Your Details! ");
                    this.name = name;
                    this.id = id;
                    this.password = password;
                    this.currency = 0;
                    bankAccounts.Add(this);
                    return;
                }
            }
        }
    }

//log-in with an already existing bank account
    public Bank(Bank b) {
        if(bankAccounts.Contains(b)) {
            foreach(Bank bankAcc in bankAccounts) {
                if(bankAcc.GetName().Equals(b.name) && bankAcc.GetId().Equals(b.id) && bankAcc.GetPassword().Equals(b.password)) {
                    this.name = b.name;
                    this.id = b.id;
                    this.currency = bankAcc.GetCurrency();
                }
            }
        }
        else {
            Console.Write("This Bank Account Doesn't Exist, Would You Like To Open A New Bank Account With The Details You Entered? (y/n) ");
            char decision = char.Parse(Console.ReadLine() ?? "");
            while(true) {
                if(char.ToLower(decision) != 'y' && char.ToLower(decision) != 'n') {
                    Console.Write("Invalid Choice, Only 'Y' Or 'N' ");
                    decision = char.Parse(Console.ReadLine() ?? "");
                }
                else if(char.ToLower(decision) == 'n'){
                    Console.WriteLine("No Problem");
                    return;
                }
                else {
                    Console.WriteLine("Created Bank Account With Your Details! ");
                    this.name = b.name;
                    this.id = b.id;
                    this.password = b.password;
                    this.currency = 0;
                    bankAccounts.Add(this);
                    return;    
                }
            }
        }
    }
    //get the card type
    public void CreateCreditCard() {
        Console.WriteLine("Please Choose A Card Type: ");
        Console.WriteLine("1 - Visa");
        Console.WriteLine("2 - MasterCard");
        Console.WriteLine("3 - American Express");
        Console.Write("Your Choice: ");
        int typeOfCard;
        typeOfCard = int.Parse(Console.ReadLine() ?? "");
        while(true) {
            if(typeOfCard != 1 && typeOfCard != 2 && typeOfCard != 3) {
                Console.Write("Invalid Choice, Enter Only 1, 2 Or 3 ");
                typeOfCard = int.Parse(Console.ReadLine() ?? "");
            }
            else {
                this.card = new CreditCard(this, typeOfCard);
                Console.WriteLine($"Credit Card Created Succesfuly With The Card Number: {this.card.GetCardNumber()}, CVV: {this.card.GetCvv()}, And Expiry Date: {this.card.GetExpiryDate().ToString()} ");
                return;
            }
        }
    }
    public string GetName() {
        return this.name;
    }
    public string GetId() {
        return this.id;
    }
    public void AddToCurrency(double money) {
        this.currency += money;
    }
    public void RemoveFromCurrency(double money) {
        this.currency -= money;
    }
    public double GetCurrency() {
        return this.currency;
    }
    public string GetPassword() {
        return this.password;
    }
    public CreditCard GetCreditCard() {
        return this.card;
    }
}
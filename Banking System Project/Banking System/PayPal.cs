using System;
using System.Collections.Concurrent;
using System.Threading.Tasks.Dataflow;


public class PayPal {
    private string email;
    private string password;
    private string username;
    private double currency;
    private static List<string> usernames = new List<string>();
    private static List<PayPal> accounts = new List<PayPal>();

    //without a bank account
    public PayPal(string email, string password, string username) {

        string newEmail = email, newUsername = username;
        bool checkEmail = true, checkUsername = true;

        //Just for now
        this.email = "";
        this.username = "";
        this.currency = 0;
        this.password = password;
        
        // Checking possible exceptions with user input, such as invalid email, or an already existing username
        if(!email.Contains('@')) {
            while(checkEmail) {
                Console.Write("Email Is Invalid, '@' Is Missing, Enter A New One: ");
                newEmail = Console.ReadLine() ?? ""; // Checks if null or not
                //the TryParse method usually covers the checking, but since string doesn't
                //have the TryParse method, then we use this checking
                if(newEmail.Contains('@')) {
                    this.email = newEmail;
                    checkEmail = false;
                }
            }
        }
        else {
            this.email = email;
        }
        if(usernames.Contains(newUsername))  {
            while(checkUsername) {
                Console.Write("Username Is UnAvailable, Enter A New One: ");
                newUsername = Console.ReadLine() ?? "";

                if(usernames.Contains(newUsername)) {
                    this.username = newUsername;
                    checkUsername = false;
                }
            } 
        }
        else {
            this.username = username;
        }
        accounts.Add(this);
    }
    public PayPal(PayPal p) {
        this.email = p.email;
        this.password = p.password;
        this.username = p.username;
    }
    public void SendMoney(double money) {
        double afterSending = this.currency - money;
        if(afterSending <= 0) {
            Console.WriteLine("You Don't Have Enough Money In Your PayPal Account");
            return;
        }
        this.currency -= money;
    }
    public void GetMoney(double money) {
        this.currency += money;
    }
    public string GetEmail() {
        return this.email;
    }
    public double GetCurrency() {
        return this.currency;
    }
    public string GetUserName() {
        return this.username;
    }
    public static List<PayPal> GetAccounts() {
        return accounts;
    }
}          
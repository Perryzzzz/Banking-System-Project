using System;


public class PayPalPayment : Payment, IPaymentMethod {
    private PayPal acc;

    //auto assosiated account
    public PayPalPayment(PayPal account) {
        this.acc = new PayPal(account);
        this.ProcessPayment();
    }
    public PayPalPayment(string email, string password, string username) {
        this.acc = new PayPal(email, password, username);
        if(this.Validate()) {
            this.ProcessPayment();
        }
        else {
            Console.WriteLine("This PayPal Account Doesn't Exist");
        }
    }
    public override void ProcessPayment() {
        Console.Write("Confirm Or Deny The Payment With Y/N ");
        char.TryParse(Console.ReadLine(), out char confirmation);
        switch(char.ToLower(confirmation)) {
            case 'y':
                Console.WriteLine("Payment Processed!");
                this.acc.SendMoney(IPaymentMethod.price);
                Console.WriteLine($"Payment's Transaction ID Is {this.GetTransactionId()}");
                break;
            case 'n':
                Console.WriteLine("Return Any Time, GoodBye!");
                break;
        }
    }
    public bool Validate() {
        return PayPal.GetAccounts().Contains(this.acc);
    }
    public string GetTransactionId() {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new Random();
        char[] result = new char[10];
        
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = chars[random.Next(chars.Length)];
        }
        
        return new string(result);
    }
    public override string GetDetails()
    {
        return $"PayPal's Account Username: {this.acc.GetUserName()}, Email: {this.acc.GetEmail()}";
    }
}


public class CreditCardPayment : Payment, IPaymentMethod {
    private CreditCard card;

    //swiping card on magnetic slider
    public CreditCardPayment(CreditCard card) {
        this.card = new CreditCard(card);
        this.ProcessPayment();
    }
    //manually
    public CreditCardPayment(string cardNumber, int cvv, Date expiryDate) {
        this.card = new CreditCard(cardNumber, cvv, expiryDate);
        this.ProcessPayment();    
    }
    public override void ProcessPayment() {
        Console.Write("Confirm Or Deny The Payment With Y/N ");
        char.TryParse(Console.ReadLine(), out char confirmation);
        switch(char.ToLower(confirmation)) {
            case 'y':
                if(this.Validate()) {
                    Console.WriteLine("Payment Processed!");
                    this.card.SendMoney(IPaymentMethod.price);
                    Console.WriteLine($"Payment's Transaction ID Is {this.GetTransactionId()}");
                 }    
                break;
            case 'n':
                Console.WriteLine("Return Any Time, GoodBye!");
                break;
        }
    }
    public bool Validate() {
        return this.card.GetExpiryDate().GetDay() > 0 && this.card.GetExpiryDate().GetDay() < 31 &&
         this.card.GetExpiryDate().GetMonth() >= 1 && this.card.GetExpiryDate().GetMonth() <= 12 &&
          this.card.GetCvv() > 0 &&
           this.card.GetCvv() < 1000 && 
           this.card.GetBankAccount().GetId()[0] != '-' && this.card.GetBankAccount().GetId().Length == 9;
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
        return $"Card Holder's Name: {this.card.GetBankAccount().GetName()}, Card Number: {this.card.GetCardNumber()}, Card's CVV: {this.card.GetCvv()}";
    }
}
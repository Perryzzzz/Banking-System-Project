using System;


public class CreditCard {
    private string cardNumber;
    private int cvv;
    private Bank bankAcc;
    private Date expiryDate;
    private static List<CreditCard> cards = new List<CreditCard>();
    
    public CreditCard(Bank b, int typeOfCard) {
        Random rand = new Random();
        this.bankAcc = new Bank(b);
        this.cardNumber = GenRandomCreditCardNumber(typeOfCard);
        this.cvv = rand.Next(100, 1000);
        this.expiryDate = new Date(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year+5);
        cards.Add(this);
    }
    public CreditCard(CreditCard c) {
        this.bankAcc = new Bank(c.bankAcc);
        this.cardNumber = c.cardNumber;
        this.cvv = c.cvv;
        this.expiryDate = new Date(c.expiryDate);
        cards.Add(this);
    }

    //find card
    public CreditCard(string cardNumber, int cvv, Date expiryDate) {
        bool found = false;
        foreach(CreditCard card in cards) {
            if(card.GetCardNumber().Equals(cardNumber) && card.GetCvv() == cvv && card.GetExpiryDate().Equals(expiryDate)) {
                Console.WriteLine("Card Have Been Found");
                this.cardNumber = cardNumber;
                this.cvv = cvv;
                this.expiryDate = new Date(expiryDate);
                this.bankAcc = new Bank(card.GetBankAccount());
            }
        }
        if(!found) {
            Console.Write("This Credit Card Doesn't Exist");
        }
    }

    public string GetCardNumber() {
        return this.cardNumber;
    }
    public Date GetExpiryDate() {
        Date returnedExpiry = new Date(this.expiryDate);
        return returnedExpiry;
    }
    public int GetCvv() {
        return this.cvv;
    }
    public Bank GetBankAccount() {
        return this.bankAcc;
    }
    
    //generates random credit card number with the type of card, the prefix is different for each company
    public string GenRandomCreditCardNumber(int typeOfCard)
    {
        Random rand = new Random();
        string prefix = "";

        switch (typeOfCard)
        {
            case 0: // Visa
                prefix = "4";
                break;
            case 1: // MasterCard
                prefix = rand.Next(51, 56).ToString();
                break;
            case 2: // American Express
                prefix = rand.Next(34, 37).ToString();
                break;
        }

        for (int i = prefix.Length; i < 16; i++)
        {
            if(i % 4 == 0) {
                prefix += "-";
            }
            prefix += rand.Next(0, 10).ToString();
        }

        return prefix;
    }

    public void GetMoney(double money) {
        this.bankAcc.AddToCurrency(money);
    }
    public void SendMoney(double money) {
        double afterSending = this.bankAcc.GetCurrency() - money;
        if(afterSending <= 0) {
            Console.WriteLine("You Don't Have Enough Money In The Associated Bank Account");
            return;
        }
        this.bankAcc.RemoveFromCurrency(money);
    }
    public string GetDetails()
    {
        return $"Card Holder's Name: {this.GetBankAccount().GetName()}, Card Number: {this.cardNumber}, Card's CVV: {this.cvv}";
    }
}
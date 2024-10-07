using System;

public interface IPaymentMethod {
    public static readonly double price = 250; //change manually, the store owner can custom it manually via code
    public bool Validate();
    public string GetTransactionId();
}
using System;

public class Date {

    private int day;
    private int month;
    private int year;

    public Date(int day, int month, int year) {
        this.day = day;
        this.month = month;
        this.year = year;
    }
    public Date(Date d) {
        this.day = d.day;
        this.month = d.month;
        this.year = d.year;
    }
    public override string ToString() {
        return $"{this.day}/{this.month}/{this.year}";
    }
    public int GetDay() {
        return this.day;
    }
    public int GetMonth() {
        return this.month;
    }
    public int GetYear() {
        return this.year;
    }
    public override bool Equals(object? obj)
    {
        Date d;
        if(obj is Date) {
            d = (Date) obj;   
        }
        else {
            return false;
        }
        return d.GetDay() == this.day && d.GetMonth() == this.month && d.GetYear() == this.year;
    }
}
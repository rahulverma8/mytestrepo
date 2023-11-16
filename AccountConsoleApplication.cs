
using AccountApp22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAppMyName;

public class Program
{
    static void Main(string[] args)
    {
        Message m = new Message();
        Account[] acc = new Account[5] {
            new SavingAccount("Priyansh", 67000),
            new CurrentAccount("Rahul", 7000),
            new SavingAccount("Manoj", 97000),
            new CurrentAccount("Priyansh", 61000),
            new SavingAccount("Punam", 191000)
        };
        for (int i = 0; i < acc.Length; i++)
        {
            acc[i].wdevent += m.sms;
            acc[i].wdevent += m.email;
        }

        acc[0].withdraw(500);
        Console.WriteLine(acc[0]);
        Console.WriteLine("/////////////////////////");
        acc[1].Deposit(500);
        Console.WriteLine(acc[1]);
        Console.WriteLine("/////////////////////////");
        acc[2].withdraw(500);
        Console.WriteLine(acc[2]);
        Console.WriteLine("/////////////////////////");
        acc[3].Deposit(500);
        Console.WriteLine(acc[3]);
        Console.WriteLine("/////////////////////////");
        acc[4].withdraw(500);
        Console.WriteLine(acc[4]);
        Console.WriteLine("/////////////////////////");
    }
}
/////////////////////////////////////////

public delegate void wd(string name, double balance, double amt);
public abstract class Account
{
    int id;
    string name;
    double balance;
    static int count_id;
    public static int count_obj;
    public event wd wdevent;
    static Account()
    {
        Console.WriteLine("BANK  OF  SMVITA");
    }
    public Account(string name, double balance)
    {
        count_obj++;
        id = count_id++;
        Name = name;
        Balance = balance;

        try
        {
            if (name.Length < 2 || name.Length > 15)
                throw new MyException("Invalid length of name");
            if (count_obj > 5)
                throw new MyException("Cannot create more than 5 objects");
        }
        catch (Exception e) { Console.WriteLine(e); }
    }

    int Id { get { return id; } }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public double Balance { get { return balance; } set { balance = value; } }

    public abstract void withdraw(double amt);
    public void Deposit(double amt)
    {
        Balance += amt;
    }
    public override string ToString()
    {
        return $"{id} {name} {balance}";
    }
    public void OnWithdraw(string name, double balance, double amt)
    {
        if (wdevent != null)
            wdevent(name, balance, amt);
    }

}
////////////////////////////////////

public class SavingAccount : Account
{
    const double minbal = 1000;

    public SavingAccount(string name, double balance) : base(name, balance)
    {

    }
    public override void withdraw(double amt)
    {
        try
        {
            if (Balance - amt < minbal)
            {
                throw new MyException("Min amount should be 1000");
            }
            else Balance -= amt;
            OnWithdraw(Name, Balance, amt);
        }
        catch { }

    }
    public static double Payinterest(Account a)
    {
        try
        {
            if (a == null)
                throw new Exception("No such account exists");
            else
                a.Balance += a.Balance * 0.9;
        }
        catch { }
        return a.Balance;
    }
}
////////////////////////////////////////

public class CurrentAccount : Account
{
    public CurrentAccount(string name, double balance) : base(name, balance) { }
    public override void withdraw(double amt)
    {
        Balance -= amt;
        OnWithdraw(Name, Balance, amt);
    }
}
//////////////////////////////////////
public class Message
{
    public void sms(string name, double balance, double amt)
    {
        Console.WriteLine($"SMS : {name} {balance} {amt}");
    }
    public void email(string name, double balance, double amt)
    {
        Console.WriteLine("EMAIL : {0} {1} {2}", name, balance, amt);
    }
}
///////////////////////////////////
public class MyException : ApplicationException
{
    public MyException(string msg) : base(msg)
    {
    }
}

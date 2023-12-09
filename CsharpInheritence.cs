using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

 namespace Dcoder
 {
   public class account{
     String name;
     int id;
     int balance;
     public account(String name,int id,int balance){
       this.name=name;
       this.id=id;
       this.balance=balance;
     }
     public void deposit(int amt){
       balance += amt;
     }
     public void withdraw(int amt){
       balance -= amt;
     }
     public void disp(){
       Console.WriteLine(name+" "+balance);
     }
   }
   public class Program
   {
     public static void Main(string[] args)
     {
       account a1= new account("Peter",16,1000);
       account a2= new account("Stephen",34,23000);
       a1.disp();
       a1.deposit(3000);
       
       a1.disp();
       a2.disp();
       a2.withdraw(1300);
       a2.disp();
     }
   }
 }

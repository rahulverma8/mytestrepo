using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

 namespace Dcoder
 {
    public class employee{
       static int id;
       String name;
       int salary;
       int netSalary;
       static int TDS;
       
       public employee(String name,int salary){
         if(id<3){
           id++;
           Console.WriteLine("MyCompany"+id);
         }
         else
           throw new Exception("No more employees allowed");
         Name=name;
         Salary=salary;
       }
       public String Name{
         get{return name;}
         set{name=value;}
       }
       public int Salary{
         get{
           return salary;
         }
         set{
           if(value>50000)
            throw new Exception("Salary not allowed more than 50000");
           else
            salary=value;
         }
       }
       public int deductTDS(){
          netSalary=salary-salary/10;
          return salary/10;
       }
       
     }
   public class Program
   {
     public static void Main(string[] args)
     {
       employee e1=new employee("Peter",40000);
        employee e2=new employee("Steve",29000);
         employee e3=new employee("Lovely",66900);
     }
   }
 }

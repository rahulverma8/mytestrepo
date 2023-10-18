import java.util.*;

class MyException extends Exception{
    MyException(String s){
        super(s);
    }
}
class ExceptionDemo
{  
    static int num;
    static void exfun1() throws MyException{
          Scanner sc = new Scanner(System.in);
          num = sc.nextInt();
          if(num < 18){
              throw new MyException("Under 18's not allowed");
          }
        else{
            System.out.println("You'r 18+ Welcome");
        }
    }
  public static void main(String args[])
  {   
       try{
            exfun1();
          }
      catch(MyException e){
          e.printStackTrace();
      }   

  }
}

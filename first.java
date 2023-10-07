package RahulPack;
import java.lang.Thread;
import java.lang.Runnable;
import java.lang.Object;

class Thread1 extends Thread{
    public void run(){
        for(char i='A';i<='Z';i++){
            System.out.print(i);
        }
        System.out.println();
    }
}

public class Demo
{  
  public static void main(String args[])
  {  
    Thread1 th1 = new Thread1();
    Thread1 th2 = new Thread1();
      th1.start();
      th2.start();
  }
}

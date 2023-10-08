import java.lang.Thread;
import java.lang.Runnable;
import java.lang.Object;
class MyThread implements Runnable{
    synchronized public void run(){
        for(int i=1;i<=10;i++)
            System.out.println(i);
    }
}
class Four
{  
  public static void main(String args[])
  {  
    MyThread m = new MyThread();
      Thread t1 = new Thread(m);
      Thread t2 = new Thread(m);
      
      t1.start();
      t2.start();
  }
}

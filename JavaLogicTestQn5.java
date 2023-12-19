import java.util.*;
import static java.lang.System.out;

class OddEven
{  
  public static void main(String args[])
  {  
      int loopsize = 6;
      int num = 1;
      for(int i=1;i<=3;i++){
          for(int j=0;j<i-1;j++)
              out.print(" ");
          for(int j=1;j<=loopsize&&loopsize>3;j++){
              if(j==1||j==loopsize)
                  out.print(i);
              else out.print(" ");
          }
          loopsize -= 2;
          if(i==3)out.print(3);
          out.println();
          }
      ////////////////////////// SECOND PART
 loopsize=4;
      num=4;
      for(int i=2;i>=1;i--){
          for(int j=0;j<i-1;j++)
              out.print(" ");
          for(int j=1;j<=loopsize&&loopsize<=6;j++){
              if(j==1||j==loopsize)
                  out.print(num);
              else out.print(" ");
          }
          loopsize += 2;
          num++;
          if(i==3)out.println(3);
          out.println();
          }
      }
 }
      
  

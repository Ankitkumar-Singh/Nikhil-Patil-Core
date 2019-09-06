using System;

class Operations
{
    public static double DoOperation(string op)
    {
        double result = double.NaN;
        int num,i;

        // Use a switch statement to do the math.
        switch (op)
        {
            case "a":
                int fact = 1;
                Console.WriteLine("Enter the number");
                num = int.Parse(Console.ReadLine());
                for (i = 1; i<=num; i++) {
                    fact = fact * i;
                }
                Console.WriteLine("Factorial of number " + num + " is " + fact + "\n");
                break;

            case "b":
                int r,sum=0,temp;      
                Console.Write("Enter the Number = ");      
                num= int.Parse(Console.ReadLine());     
                temp=num;      
                while(num>0) {      
                    r=num%10;      
                    sum=sum+(r*r*r);      
                    num=num/10;      
                }      
                if(temp==sum)      
                    Console.Write("Armstrong Number.\n");      
                else      
                    Console.Write("Not Armstrong Number.\n");      
                break;

            case "c":     
                int[] a = new int[10];     
                Console.Write("Enter the number to convert: ");    
                num= int.Parse(Console.ReadLine());     
                for(i=0; num>0; i++) {
                    a[i]=num%2;      
                    num= num/2;    
                }
                Console.Write("Binary of the given number= ");      
                for(i=i-1 ;i>=0 ;i--) {
                    Console.Write(a[i]); 
                }                 
                break;

            // Return text for an incorrect option entry.
            default:
                Console.Write("Wrong.... Please select again.\n"); 
                break;
        }
        return result;
    }
}
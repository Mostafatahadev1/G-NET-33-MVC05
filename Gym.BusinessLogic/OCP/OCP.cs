
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BusinessLogic.OCP
{
    /*
   // Open Closed Principle (OCP) states that software entities (classes, modules, functions, etc.) should be open for extension but closed for modification. This means 
        that the behavior of a module can be extended without modifying its source code.

   OCP : Means Open for extension  but closed for Modification

 // DIP : High Level Moduales should not depend on low level modules, 
//both should depend on abstractions. 
//Abstractions should not depend on details, details should depend on abstractions.

// OrderService => High Level Module

// Instapay => Low Level Module (Abstraction)




    public class OrderService  
    {


        Instapay instapay = new Instapay();
        public void MakeOrder()
            {

            // order logic
            Instapay.Pay();
        }

    }

    public class Instapay()
    {

        public void Pay()
        {
            // Pay With InstaPay
        }
        
    }
}
*/

}

/*
public class OrderService
{
    Ipayment Instapay();

    public void MakeOrder()
    {
        // Order Logic
        Instapay.Pay();
    }
}
public interface Ipayment
{
    public void Pay();
}


public class InstaPay : Ipayment
{
    public void Pay() 
    {
        Console.WriteLine("Pay With InstaPay "); 
    }
}
*/

// Dependence Injection : Recieve Objects 
    // 1- Constractores
    // 2- Mathods  


// مين اللي بيستقبل object 

// IOC Container  : Send Objects to Dependance Injection 
// Inversion Of Control Contianer 


using System;

namespace DesignPatterns.CreationPatterns
{
    /// <summary>
    /// Abstract Factory is to create instances of a derived classes without having to mention it in the execution code
    /// Here in this example, execution class is PostalShipment. It is able to create the instances of DomesticShippingOrigin, DomesticShippingDestination, InternationalShippingOrigin and InternationalShippingDestination
    /// without having to know about these classes.
    /// PostalShipment can still execute delivery for different type of Shipping type (Domestic and International) without having to directly initialize origin/destination objects from those classes.
    /// 
    /// Key OOP characteristic: Inheritance, Polymorphyism
    /// </summary>
    public class AbstractFactory : IDesignPatternExample
    {
        public void Execute()
        {
            Console.WriteLine("AbstractFactory:");

            var domesticCourier = new DomesticCourier();
            var domesticShipment = new PostalShipment(domesticCourier);
            domesticShipment.Deliver();

            var internationalCourier = new InternaltionalCourier();
            var internationalShipment = new PostalShipment(internationalCourier);
            internationalShipment.Deliver();

            Console.ReadLine();
        }
    }


    public class PostalShipment
    {
        private ShippingOrigin _origin;
        private ShippingDestination _destination;

        public PostalShipment(Courier courier)
        {
            // this is the ULTIMATE PURPOSE of this Design Pattern
            // here is to get the instances of Origin and Destination, but no need to know the concrete class of them to initialize directly.
            _origin = courier.GetOrigin();
            _destination = courier.GetDestination();
        }

        public void Deliver()
        {
            Console.WriteLine("Deliver from: " + _origin.GetType().ToString() + " to " + _destination.GetType().ToString());
        }
    }

    // Abstract Factory
    public abstract class Courier
    {
        public abstract ShippingOrigin GetOrigin();
        public abstract ShippingDestination GetDestination();
    }

    // Concrete Factory type A
    public class DomesticCourier : Courier
    {
        public override ShippingOrigin GetOrigin()
        {
            return new DomesticShippingOrigin();
        }

        public override ShippingDestination GetDestination()
        {
            return new DomesticShippingDestination();
        }
    }

    // Concrete Factory type B
    public class InternaltionalCourier : Courier
    {
        public override ShippingOrigin GetOrigin()
        {
            return new InternationalShippingOrigin();
        }

        public override ShippingDestination GetDestination()
        {
            return new InternationalShippingDestination();
        }
    }

    // Abstract Product A
    public abstract class ShippingOrigin { }
    // Abstract Product B
    public abstract class ShippingDestination { }

    // Concrete Product A1
    public class DomesticShippingOrigin : ShippingOrigin { }
    // Concrete Product A2
    public class DomesticShippingDestination : ShippingDestination { }

    // Concrete Product B1
    public class InternationalShippingOrigin : ShippingOrigin { }
    // Concrete Product B2
    public class InternationalShippingDestination : ShippingDestination { }
}

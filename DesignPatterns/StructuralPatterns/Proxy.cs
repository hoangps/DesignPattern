using System;

namespace DesignPatterns.StructuralPatterns
{
    public class ProxyPattern : IDesignPatternExample
    {
        public void Execute()
        {
            Console.WriteLine("Proxy");

            // proxy here is to act as the ActualSubject. 
            // It will itself call the ActualSubject instead of letting the client call the ActualSubject from here.
            var proxy = new Proxy();
            proxy.Request();

            Console.ReadLine();
        }
    }



    public abstract class Subject
    {
        public virtual void Request()
        {
            Console.WriteLine("Abstract subject is called.");
        }
    }

    public class Proxy : Subject
    {
        ActualSubject _actualSubject;

        public override void Request()
        {
            if (_actualSubject == null)
                _actualSubject = new ActualSubject();

            _actualSubject.Request();
        }
    }

    public class ActualSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Actual subject is called.");
        }
    }
}

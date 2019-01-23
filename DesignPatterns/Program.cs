using DesignPatterns.BehaviorPatterns;
using DesignPatterns.CreationPatterns;
using DesignPatterns.StructuralPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creational
            // + AbstractFactory: Creates an instance of several families of classes
            IDesignPatternExample abstractFactory = new AbstractFactory();
            abstractFactory.Execute();

            // + FactoryMethod: Creates an instance of several derived classes
            IDesignPatternExample factoryMethod = new FactoryMethod();
            factoryMethod.Execute();

            // + Singleton: A class of which only a single instance can exist
            IDesignPatternExample singleton = new Singleton();
            singleton.Execute();



            // Structural
            // + Facade : To bunch many interfaces of a subsystem into a single interface to use instead of calling individually.
            // + Adapter: To change the interface of class/library A to the expectations of client B. The typical implementation is a wrapper class or set of classes. 
            //            The purpose is not to facilitate future interface changes, but current interface incompatibilities.

            // + Composite: To use a class to represent all other classes, used in tree/hierachical structure. This kind of violates one of the OOP Code clean Principles (SOLID)
            IDesignPatternExample composite = new Composite();
            composite.Execute();

            // + Proxy: Provide a surrogate or placeholder for another object to control access to it.
            IDesignPatternExample proxy = new ProxyPattern();
            proxy.Execute();

            // + Decorator: 


            // Behavior
            // + Iterator: Sequentially access the elements of a collection
            IDesignPatternExample iterator = new IteratorPattern();
            iterator.Execute();

            // + Observer: A way of notifying change to a number of classes
            IDesignPatternExample observer = new Observer();
            observer.Execute();
        }
    }
}

using System;

namespace DesignPatterns.CreationPatterns
{
    /// <summary>
    /// To make sure only give out one instance of a class at a time.
    /// Here, even the application tries to create many instances of the Authorizer class, but all of them are them same one. Thus, the consistency.
    /// </summary>
    public class Singleton : IDesignPatternExample
    {
        public void Execute()
        {
            Console.WriteLine("Singleton:");

            // create 4 variables of the Authorizer
            // they should be the same
            var authorizer1 = Authorizer.GetAuthorizer();
            var authorizer2 = Authorizer.GetAuthorizer();
            var authorizer3 = Authorizer.GetAuthorizer();
            var authorizer4 = Authorizer.GetAuthorizer();

            var identical = authorizer1 == authorizer2 && authorizer2 == authorizer3 && authorizer3 == authorizer4;

            Console.WriteLine("All variables are the same? " + identical);
            Console.ReadLine();
        }
    }

    public class Authorizer
    {
        // this is the instance of the class. it has to be a static variable to make sure it is the same in any instance.
        private static Authorizer _authorizer;
        private static object padlock = new object(); // this can

        public static Authorizer GetAuthorizer()
        {
            // check if the instance is created and available. 
            // only create a new instance if there is no instance was created
            if(_authorizer == null)
            {
                // to support multi-threading, so that one thread to be processed at a time
                // reason: if it is multi-thread, it is possible that more than one thread will receive the same value after the check above, carry over here. If not locked, each passed thread will request to have a new instance, thus the padlock!
                // lock the thread to wait until the initialization to be finished.
                // it has to be under the first check because it should not always lock to process threads 1 by 1 everytime
                lock (padlock)
                {
                    // the second check here to make sure when the initialization is finished, the waiting process in next thread at the padlock above will come here, it has to be checked again 
                    // if it is the 2nd thread, the instance is supposed to be available to be pickup already. no need to create another one.
                    if (_authorizer == null)
                    {
                        _authorizer = new Authorizer(); // actually initialize a new instance here. this line is supposed to be hit once per application life time or until the instance is reset or destroyed.
                    }
                }
            }

            return _authorizer; // return the initialized object
        }
    }
}

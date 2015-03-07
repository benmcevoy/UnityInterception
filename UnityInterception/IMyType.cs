using System;

namespace UnityInterception
{
    public interface IMyType
    {
        void Dosomething();
    }

    public interface IMyType1
    {
        void Dosomething();
    }

    public interface IMyType2
    {
        void Dosomething();
    }

    public class MyType1 : IMyType1
    {

        [Log]
        public void Dosomething()
        {
            Console.WriteLine("IMyType1 is doing shit");
        }
    }



    public class MyType2 : IMyType2
    {
        [Log]
        public void Dosomething()
        {
            Console.WriteLine("IMyType2 is doing shit");
        }
    }

    public class MyType : IMyType
    {

        [Log]
        public void Dosomething()
        {
            Console.WriteLine("IMyType is doing shit");
        }
    }
}

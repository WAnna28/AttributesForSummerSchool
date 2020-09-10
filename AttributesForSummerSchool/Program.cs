using AttributesLibForSummerSchool;
using System;
using System.Diagnostics;

namespace AttributesForSummerSchool
{
    class Program
    {
        // Example2
        [Serializable]
        public class SampleClass
        {
            // Objects of this type can be serialized.
        }

        // Example3
        [Serializable]
        [Flags]
        public enum ForTest1 { }

        [Serializable, Flags]
        public enum ForTest2 { }

        [SerializableAttribute, FlagsAttribute]
        public enum ForTest3 { }

        [Serializable]
        [FlagsAttribute()]
        public enum ForTest4 { }

        // Example4
        [Conditional("DEBUG"), Conditional("JustForTest")]
        void TraceMethod()
        {
            // ...
        }

        static void Main(string[] args)
        {
            //Example 1: using GetType to obtain type information.
            //double count = 42.5;
            //Type type = count.GetType();
            //Console.WriteLine(type);

            //Example 9: conceptually equivalent
            //Author anonymousAuthorObject = new Author("Anna Hakobyan");
            //anonymousAuthorObject.version = 1.1;

            // Example 11:
            PrintAuthorInfo(typeof(UseOurCustomAttribute));
            PrintAuthorInfo(typeof(UseOurMultipleCustomAttribute));
            PrintAuthorInfo(typeof(NoCustomAttribute));

            Console.ReadLine();
        }        

        // Example 10
        private static void PrintAuthorInfo(Type t)
        {
            Console.WriteLine("Author information for {0}", t);

            // Using reflection.  
            Attribute[] attrs = Attribute.GetCustomAttributes(t);  // Reflection.  

            // Displaying output.  
            foreach (Attribute attr in attrs)
            {
                if (attr is AuthorAttribute)
                {
                    AuthorAttribute a = (AuthorAttribute)attr;
                    Console.WriteLine("   {0}, version {1:f}", a.GetName(), a.version);
                }
            }
        }
    }

    // Example 5: Attribute parameters
    [AttributeUsage(AttributeTargets.Class)]
    public class SummerAttribute : Attribute
    {
        public SummerAttribute(string name) { } // Positional parameter

        public int Info1 { get; set; } // Named parameter

        public Type Info2 { get; set; } // Named parameter
    }

    [Summer("Just For Test", Info1 = 1234, Info2 = typeof(float))]
    public class ParametersClass1 { }

    [Summer("Just For Test", Info2 = typeof(int), Info1 = 1988)]
    public class ParametersClass2 { }

    // Example 7
    [Author("Anna Hakobyan", version = 1.1)]
    public enum UseOurCustomAttribute
    {

    }

    // Example 8
    [Author("Anna Hakobyan For Summer School", version = 1.1)]
    [Author("Anna Hakobyan For Winter School", version = 1.4)]
    public class UseOurMultipleCustomAttribute
    {

    }

    public class NoCustomAttribute
    {

    }
}
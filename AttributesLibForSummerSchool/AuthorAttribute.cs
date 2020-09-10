using System;

namespace AttributesLibForSummerSchool
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum,
                    AllowMultiple = true) // multiuse attribute 
    ]
    public class AuthorAttribute : Attribute
    {
        private string name;
        public double version;

        public AuthorAttribute(string name)
        {
            this.name = name;
            version = 1.0;
        }

        public string GetName()
        {
            return name;
        }

    }

    // Attribute - Code Snippet
}
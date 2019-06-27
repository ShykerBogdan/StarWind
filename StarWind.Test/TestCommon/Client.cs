using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestCommon
{
    public class Client
    {
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
            }
        }
        public int Id { get; set; }
        public uint INN { get; set; }
        public string Name { get; set; }
        public string Prof { get; set; }
        public int Stage { get; set; }
    }
}

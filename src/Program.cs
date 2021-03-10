using System;

namespace wave_processor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RawDataProcessor data = new RawDataProcessor();
            data.getData();
        }
    }
}

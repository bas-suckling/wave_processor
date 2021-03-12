using System;

namespace wave_processor
{
    class Program
    {
        static void Main(string[] args)
        {
            RawDataParser data = new RawDataParser();
            data.getData();
        }
    }
}

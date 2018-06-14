using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleLibrary;

namespace ExampleApp
{
    class Program
    {
        public static void Main( string[] args )
        {
            Console.WriteLine( "Initializing measurement data.." );

            var example = new ExampleFunctions();

            var measurements =
                new int[,]
                {
                    { 0, 115, 5, 15, 0, 5},
                    { 80, 210, 0, 5, 5, 0},
                    { 45, 60, 145, 175, 95, 25},
                    { 95, 5, 250, 250, 115, 5},
                    { 170, 230, 245, 185, 165, 145 },
                    { 145, 220, 140, 160, 250, 250 },
                };

            var threshold = 200;

            Console.WriteLine( "Processing measurements.. " );
            var centers = example.ProcessMeasurements( measurements, threshold );

            Console.WriteLine( "\nThe following centers of mass were identified: " );
            foreach( var center in centers )
                Console.WriteLine( $"[ {center.X}, {center.Y} ]" );

            Console.WriteLine( "\n[  Press any key to exit  ]" );
            Console.ReadKey();
        }
    }
}
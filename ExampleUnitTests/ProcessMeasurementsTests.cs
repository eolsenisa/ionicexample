using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExampleLibrary;

namespace ExampleUnitTests
{
    [TestClass]
    public class ProcessMeasurementsTests : ExampleTestsBase
    {
        #region Methods(protected)

        protected int[,] GetProvidedMeasurements()
        {
            var measurements =
                new int[,]
                {
                    { 0,   115, 5,   15,  0,   5   },
                    { 80,  210, 0,   5,   5,   0   },
                    { 45,  60,  145, 175, 95,  25  },
                    { 95,  5,   250, 250, 115, 5   },
                    { 170, 230, 245, 185, 165, 145 },
                    { 145, 220, 140, 160, 250, 250 },
                };

            return measurements;
        }

        protected int[,] GetRotatedMeasurements()
        {
            var measurements =
                new int[,]
                {
                    { 5,   0,   25,  5,   145, 250 },
                    { 0,   5,   95,  115, 165, 250 },
                    { 15,  5,   175, 250, 185, 160 },
                    { 5,   0,   145, 250, 245, 140 },
                    { 115, 210, 60,  5,   230, 220 },
                    { 0,   80,  45,  95,  170, 145 },
                };

            return measurements;
        }

        protected int[,] GetFlippedMeasurements()
        {
            var measurements =
                new int[,]
                {
                    { 0,   80,  45,  95,  170, 145 },
                    { 115, 210, 60,  5,   230, 220 },
                    { 5,   0,   145, 250, 245, 140 },
                    { 15,  5,   175, 250, 185, 160 },
                    { 0,   5,   95,  115, 165, 250 },
                    { 5,   0,   25,  5,   145, 250 },
                };

            return measurements;
        }

        #endregion

        #region Methods(public)

        [TestMethod]
        public void AllOverThresholdReturnsCenterPoint()
        {
            var measurements =
               new int[,]
               {
                   { 100, 100, 100, 100, 100, 100},
                   { 100, 100, 100, 100, 100, 100},
                   { 100, 100, 100, 100, 100, 100},
                   { 100, 100, 100, 100, 100, 100},
                   { 100, 100, 100, 100, 100, 100},
                   { 100, 100, 100, 100, 100, 100}
               };

            var threshold = 1;
            var expected = new List<Point>()
                {
                    new Point(3, 3)
                };

            var output = example.ProcessMeasurements( measurements, threshold );
            AssertCollectionsMatch( expected, output );
        }

        [TestMethod]
        public void AllUnderThresholdReturnsNone()
        {
            var measurements = GetProvidedMeasurements();
            var threshold = 400;
            var expected = new List<Point>();

            var output = example.ProcessMeasurements( measurements, threshold );
            AssertCollectionsMatch( expected, output );
        }

        [TestMethod]
        public void FlippedExampleReturnsCorrectly()
        {
            var measurements = GetFlippedMeasurements();
            var threshold = 200;
            var expected = new List<Point>()
                {
                    new Point( 1, 1 ),
                    new Point( 2, 4 ),
                    new Point( 5, 5 )
                };

            var output = example.ProcessMeasurements( measurements, threshold );
            AssertCollectionsMatch( expected, output );
        }

        [TestMethod]
        public void NoValuesReturnsNoPoints()
        {
            var threshold = 1;
            var measurements = new int[ 0, 0 ];
            var expected = new List<Point>();
            var output = example.ProcessMeasurements( measurements, threshold );
            AssertCollectionsMatch( expected, output );
        }

        [TestMethod]
        public void ProvidedExampleReturnsCorrectly()
        {
            var measurements = GetProvidedMeasurements();
            var threshold = 200;
            var expected = new List<Point>()
                {
                    new Point( 1, 1 ),
                    new Point( 4, 2 ),
                    new Point( 5, 5 )
                };

            var output = example.ProcessMeasurements( measurements, threshold );
            AssertCollectionsMatch( expected, output );
        }

        [TestMethod]
        public void ProvidedPairReturnsCorrecly()
        {
            var measurements =
                new int[,]
                {
                    { 0,   115, 5,   15,  0,   5   },
                    { 80,  0,   0,   5,   5,   0   },
                    { 45,  60,  145, 175, 95,  25  },
                    { 95,  5,   0,   0,   115, 5   },
                    { 170, 0,   0,   185, 165, 145 },
                    { 145, 0,   140, 160, 250, 250 },
                };

            var threshold = 200;
            var expected = new List<Point>() { new Point( 5, 5 ) };
            var output = example.ProcessMeasurements( measurements, threshold );
            AssertCollectionsMatch( expected, output );
        }

        [TestMethod]
        public void ProvidedPointReturnsCorrectly()
        {
            var measurements =
                new int[,]
                {
                    { 0,   115, 5,   15,  0,   5   },
                    { 80,  210, 0,   5,   5,   0   },
                    { 45,  60,  145, 175, 95,  25  },
                    { 95,  5,   0,   0,   115, 5   },
                    { 170, 0,   0,   185, 165, 145 },
                    { 145, 0,   140, 160, 0,   0   },
                };

            var threshold = 200;
            var expected = new List<Point>() { new Point( 1, 1 ) };
            var output = example.ProcessMeasurements( measurements, threshold );
            AssertCollectionsMatch( expected, output );
        }

        [TestMethod]
        public void ProvidedWReturnsCorrectly()
        {
            var measurements =
                new int[,]
                {
                    { 0,   115, 5,   15,  0,   5   },
                    { 80,  0,   0,   5,   5,   0   },
                    { 45,  60,  145, 175, 95,  25  },
                    { 95,  5,   250, 250, 115, 5   },
                    { 170, 230, 245, 185, 165, 145 },
                    { 145, 220, 140, 160, 0,   0   },
                };

            var threshold = 200;
            var expected = new List<Point>() { new Point( 4, 2 ) };
            var output = example.ProcessMeasurements( measurements, threshold );
            AssertCollectionsMatch( expected, output );
        }


        [TestMethod]
        public void RotatedExampleReturnsCorrectly()
        {
            var measurements = GetRotatedMeasurements();
            var threshold = 200;
            var expected = new List<Point>()
                {
                    new Point( 4, 1 ),
                    new Point( 3, 4 ),
                    new Point( 1, 5 )
                };

            var output = example.ProcessMeasurements( measurements, threshold );
            AssertCollectionsMatch( expected, output );
        }

        #endregion
    }
}

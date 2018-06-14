using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExampleLibrary;

namespace ExampleUnitTests
{
    [TestClass]
    public class GetPointsOverThresholdTests : ExampleTestsBase
    {
        #region Methods (protected)

        protected int[,] CreateMeasurementArray( int xmax, int ymax, int value )
        {
            var measurements = new int[ xmax, ymax ];
            for( var x = 0; x < xmax; x++ )
                for( var y = 0; y < ymax; y++ )
                    measurements[ x, y ] = value;

            return measurements;
        }

        protected void DebugMeasurements( int[,] measurements )
        {
            StringBuilder sb = new StringBuilder();
            var xmax = GetXMax( measurements );
            var ymax = GetYMax( measurements );
            for( var x = 0; x < xmax; x++ )
            {
                for( var y = 0; y < ymax; y++ )
                    sb.Append( measurements[ x, y ] );
                sb.AppendLine();
            }

            var output = sb.ToString();
            Debug.WriteLine( output );
        }

        protected HashSet<MeasurementPoint> GenerateRandomPointsSet( ref int[,] measurements, int threshold )
        {
            var random = CreateRNG();
            var xsize = GetXMax( measurements );
            var ysize = GetYMax( measurements );

            var expected = new HashSet<MeasurementPoint>();
            for( var x = 0; x < xsize; x++ )
                for( var y = 0; y < ysize; y++ )
                {
                    var value = random.Next( Int32.MaxValue );
                    measurements[ x, y ] = value;
                    if( value > threshold )
                        expected.Add( new MeasurementPoint( x, y, value ) );
                }

            return expected;
        }

        protected HashSet<MeasurementPoint> GetRandomClusterSet( out int[,] measurements, int threshold )
        {
            var random = CreateRNG();
            var value = threshold + 1;
            var expected = new HashSet<MeasurementPoint>();

            measurements = CreateMeasurementArray( 3, 3, 0 );
            measurements[ 1, 1 ] = value;
            expected.Add( new MeasurementPoint( 1, 1, value ) );

            var target = random.Next( 3, 10 );
            while( expected.Count < target )
            {
                var x = random.Next( 0, 3 );
                var y = random.Next( 0, 3 );
                var candidate = new MeasurementPoint( x, y, value );
                if( expected.Contains( candidate ) )
                    continue;

                measurements[ x, y ] = value;
                expected.Add( candidate );
            }

            return expected;
        }

        protected List<MeasurementPoint> GetSimpleAscendingDiagonalSet( out int[,] measurements )
        {
            measurements = new int[ 3, 3 ]
                {
                    { 2, 0, 0 },
                    { 0, 2, 0 },
                    { 0, 0, 2 }
                };

            var expected = new List<MeasurementPoint>()
                {
                    new MeasurementPoint( 0, 0, 2 ),
                    new MeasurementPoint( 1, 1, 2 ),
                    new MeasurementPoint( 2, 2, 2 )
                };

            return expected;
        }

        protected List<MeasurementPoint> GetSimpleDescendingDiagonalSet( out int[,] measurements )
        {
            measurements = new int[ 3, 3 ]
                {
                    { 0, 0, 2 },
                    { 0, 2, 0 },
                    { 2, 0, 0 }
                };

            var expected = new List<MeasurementPoint>()
                {
                    new MeasurementPoint( 0, 2, 2 ),
                    new MeasurementPoint( 1, 1, 2 ),
                    new MeasurementPoint( 2, 0, 2 )
                };

            return expected;
        }

        protected List<MeasurementPoint> GetSimpleXSet( out int[,] measurements )
        {
            measurements =
                new int[ 3, 3 ]
                    {
                        { 0, 0, 0 },
                        { 2, 2, 2 },
                        { 0, 0, 0 }
                    };

            var expected = new List<MeasurementPoint>()
                {
                    new MeasurementPoint( 1, 0, 2 ),
                    new MeasurementPoint( 1, 1, 2 ),
                    new MeasurementPoint( 1, 2, 2 )
                };

            return expected;
        }

        protected List<MeasurementPoint> GetSimpleYSet( out int[,] measurements )
        {
            measurements = new int[ 3, 3 ]
                {
                    { 0, 2, 0 },
                    { 0, 2, 0 },
                    { 0, 2, 0 }
                };

            var expected = new List<MeasurementPoint>()
                {
                    new MeasurementPoint( 0, 1, 2 ),
                    new MeasurementPoint( 1, 1, 2 ),
                    new MeasurementPoint( 2, 1, 2 )
                };

            return expected;
        }

        protected int GetXMax( int[,] measurements )
            => measurements.GetLength( 0 );

        protected int GetYMax( int[,] measurements )
            => measurements.GetLength( 1 );

        #endregion

        #region Methods (public)

        [TestMethod]
        public void AllValuesUnderThresholdReturnsNone()
        {
            for( int i = 0; i < maxTestSize; i++ )
            {
                var size = i;
                var threshold = 1;
                var measurements = CreateMeasurementArray( size, size, 0 );
                var output = example.GetPointsAboveThreshold( measurements, threshold );
                Assert.IsTrue( output.Count == 0 );
            }
        }

        [TestMethod]
        public void AllValuesOverThresholdReturnsAll()
        {
            for( int i = 0; i < maxTestSize; i++ )
            {
                var size = i;
                var threshold = 1;
                var measurements = CreateMeasurementArray( size, size, 2 );
                var output = example.GetPointsAboveThreshold( measurements, threshold );
                var expectedSize = size * size;
                Assert.IsTrue( output.Count == expectedSize );
            }
        }

        [TestMethod]
        public void EmptyArrayReturnsEmptyList()
        {
            for( int i = 0; i < maxTestSize; i++ )
            {
                var measurements = CreateMeasurementArray( 0, 0, 0 );
                var threshold = 0;
                var output = example.GetPointsAboveThreshold( measurements, threshold );
                Assert.IsTrue( output.Count == 0 );
            }
        }

        [TestMethod]
        public void ProvidedExampleReturnsCorrectly()
        {
            var threshold = 200;

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

            var expected = new List<MeasurementPoint>()
                {
                    new MeasurementPoint( 1, 1, 210 ),
                    new MeasurementPoint( 3, 2, 250 ),
                    new MeasurementPoint( 3, 3, 250 ),
                    new MeasurementPoint( 4, 1, 230 ),
                    new MeasurementPoint( 4, 2, 245 ),
                    new MeasurementPoint( 5, 1, 220 ),
                    new MeasurementPoint( 5, 4, 250 ),
                    new MeasurementPoint( 5, 5, 250 ),
                };

            var output = example.GetPointsAboveThreshold( measurements, threshold );
            AssertCollectionsMatch( expected, output );
        }

        [TestMethod]
        public void RandomClusterSetsReturnCorrectly()
        {
            for( var i = 0; i < 100; i++ )
            {
                var threshold = 1;
                int[,] measurements;
                var expected = GetRandomClusterSet( out measurements, threshold );
                var output = example.GetPointsAboveThreshold( measurements, threshold );
                AssertCollectionsMatch( expected, output );
            }
        }

        [TestMethod]
        public void RandomPointsSetReturnsCorrectly()
        {
            var random = CreateRNG();

            for( var i = 0; i < maxTestSize; i++ )
            {
                var maxTests = maxTestSize * maxTestSize;
                for( var j = 0; j < maxTests; j++ )
                {
                    var threshold = random.Next( Int32.MaxValue );
                    var measurements = new int[ i, i ];
                    var expected = GenerateRandomPointsSet( ref measurements, threshold );

                    var output = example.GetPointsAboveThreshold( measurements, threshold );
                    AssertCollectionsMatch( expected, output );
                }
            }
        }

        [TestMethod]
        public void SimpleAscendingDiagonalSetReturnsCorrectly()
        {
            var threshold = 1;
            int[,] measurements;
            var expected = GetSimpleAscendingDiagonalSet( out measurements );
            var output = example.GetPointsAboveThreshold( measurements, threshold );
            AssertCollectionsMatch( expected, output );
        }

        [TestMethod]
        public void SimpleDescendingDiagonalSetReturnsCorrectly()
        {
            var threshold = 1;
            int[,] measurements;
            var expected = GetSimpleDescendingDiagonalSet( out measurements );
            var output = example.GetPointsAboveThreshold( measurements, threshold );
            AssertCollectionsMatch( expected, output );
        }

        [TestMethod]
        public void SimpleXSetReturnsCorrectly()
        {
            var threshold = 1;
            int[,] measurements;
            var expected = GetSimpleXSet( out measurements );
            var output = example.GetPointsAboveThreshold( measurements, threshold );
            AssertCollectionsMatch( expected, output );
        }

        [TestMethod]
        public void SimpleYSetReturnsCorrectly()
        {
            var threshold = 1;
            int[,] measurements;
            var expected = GetSimpleYSet( out measurements );
            var output = example.GetPointsAboveThreshold( measurements, threshold );
            AssertCollectionsMatch( expected, output );
        }

        #endregion
    }
}
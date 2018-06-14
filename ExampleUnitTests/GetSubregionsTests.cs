using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExampleLibrary;

namespace ExampleUnitTests
{
    [TestClass]
    public class GetSubregionsTests : ExampleTestsBase
    {
        [TestMethod]
        public void ProvidedExampleReturnsCorrectly()
        {
            var p1 = new MeasurementPoint( 1, 1, 210 );
            var p2 = new MeasurementPoint( 3, 2, 250 );
            var p3 = new MeasurementPoint( 3, 3, 250 );
            var p4 = new MeasurementPoint( 4, 1, 230 );
            var p5 = new MeasurementPoint( 4, 2, 245 );
            var p6 = new MeasurementPoint( 5, 1, 220 );
            var p7 = new MeasurementPoint( 5, 4, 250 );
            var p8 = new MeasurementPoint( 5, 5, 250 );

            p2.AdjacentPoints.Add( p3 );
            p2.AdjacentPoints.Add( p4 );
            p2.AdjacentPoints.Add( p5 );
            p2.AdjacentPoints.Add( p6 );

            p3.AdjacentPoints.Add( p2 );
            p3.AdjacentPoints.Add( p4 );
            p3.AdjacentPoints.Add( p5 );
            p3.AdjacentPoints.Add( p6 );

            p4.AdjacentPoints.Add( p2 );
            p4.AdjacentPoints.Add( p3 );
            p4.AdjacentPoints.Add( p5 );
            p4.AdjacentPoints.Add( p6 );

            p5.AdjacentPoints.Add( p2 );
            p5.AdjacentPoints.Add( p3 );
            p5.AdjacentPoints.Add( p4 );
            p5.AdjacentPoints.Add( p6 );

            p6.AdjacentPoints.Add( p2 );
            p6.AdjacentPoints.Add( p3 );
            p6.AdjacentPoints.Add( p4 );
            p6.AdjacentPoints.Add( p5 );

            p7.AdjacentPoints.Add( p8 );
            p8.AdjacentPoints.Add( p7 );

            var points = new List<MeasurementPoint>() { p1, p2, p3, p4, p5, p6, p7, p8 };

            var expected = new List<HashSet<MeasurementPoint>>()
                {
                    new HashSet<MeasurementPoint>() { p1 },
                    new HashSet<MeasurementPoint>() { p2, p3, p4, p5, p6 },
                    new HashSet<MeasurementPoint>() { p7, p8 }
                };

            var output = example.GetSubregions( points );

            Assert.IsTrue( expected.Count == output.Count );
            for( int i = 0; i < output.Count; i++ )
            {
                AssertCollectionsMatch( expected[ i ], output[ i ] );
            }
        }

        [TestMethod]
        public void NoAdjacentPointsSetReturnsCorrectly()
        {
            var p1 = new MeasurementPoint( 0, 0, 100 );
            var p2 = new MeasurementPoint( 2, 2, 100 );
            var p3 = new MeasurementPoint( 4, 4, 100 );

            var points = new List<MeasurementPoint>() { p1, p2, p3 };

            var expected = new List<HashSet<MeasurementPoint>>()
                {
                    new HashSet<MeasurementPoint>() { p1 },
                    new HashSet<MeasurementPoint>() { p2 },
                    new HashSet<MeasurementPoint>() { p3 }
                };

            var output = example.GetSubregions( points );

            Assert.IsTrue( expected.Count == output.Count );
            for( int i = 0; i < output.Count; i++ )
            {
                AssertCollectionsMatch( expected[ i ], output[ i ] );
            }
        }

        [TestMethod]
        public void SingleAscendingDiagonalSetReturnsCorrectly()
        {
            var p1 = new MeasurementPoint( 0, 0, 100 );
            var p2 = new MeasurementPoint( 1, 1, 100 );
            var p3 = new MeasurementPoint( 2, 2, 100 );
            var p4 = new MeasurementPoint( 4, 4, 100 );

            p1.AdjacentPoints.Add( p2 );
            p1.AdjacentPoints.Add( p3 );

            p2.AdjacentPoints.Add( p1 );
            p2.AdjacentPoints.Add( p3 );

            p3.AdjacentPoints.Add( p1 );
            p3.AdjacentPoints.Add( p2 );

            var points = new List<MeasurementPoint>() { p1, p2, p3, p4 };

            var expected = new List<HashSet<MeasurementPoint>>()
                {
                    new HashSet<MeasurementPoint>() { p1, p2, p3 },
                    new HashSet<MeasurementPoint>() { p4 }
                };

            var output = example.GetSubregions( points );

            Assert.IsTrue( expected.Count == output.Count );
            for( int i = 0; i < output.Count; i++ )
            {
                AssertCollectionsMatch( expected[ i ], output[ i ] );
            }
        }

        [TestMethod]
        public void SingleDescendingDiagonalSetReturnsCorrectly()
        {
            var p1 = new MeasurementPoint( 0, 2, 100 );
            var p2 = new MeasurementPoint( 1, 1, 100 );
            var p3 = new MeasurementPoint( 2, 0, 100 );
            var p4 = new MeasurementPoint( 4, 4, 100 );

            p1.AdjacentPoints.Add( p2 );
            p1.AdjacentPoints.Add( p3 );

            p2.AdjacentPoints.Add( p1 );
            p2.AdjacentPoints.Add( p3 );

            p3.AdjacentPoints.Add( p1 );
            p3.AdjacentPoints.Add( p2 );

            var points = new List<MeasurementPoint>() { p1, p2, p3, p4 };

            var expected = new List<HashSet<MeasurementPoint>>()
                {
                    new HashSet<MeasurementPoint>() { p1, p2, p3 },
                    new HashSet<MeasurementPoint>() { p4 }
                };

            var output = example.GetSubregions( points );

            Assert.IsTrue( expected.Count == output.Count );
            for( int i = 0; i < output.Count; i++ )
            {
                AssertCollectionsMatch( expected[ i ], output[ i ] );
            }
        }

        [TestMethod]
        public void SingleXSetReturnsCorrectly()
        {
            var p1 = new MeasurementPoint( 0, 0, 100 );
            var p2 = new MeasurementPoint( 0, 1, 100 );
            var p3 = new MeasurementPoint( 0, 2, 100 );
            var p4 = new MeasurementPoint( 4, 4, 100 );

            p1.AdjacentPoints.Add( p2 );
            p1.AdjacentPoints.Add( p3 );

            p2.AdjacentPoints.Add( p1 );
            p2.AdjacentPoints.Add( p3 );

            p3.AdjacentPoints.Add( p1 );
            p3.AdjacentPoints.Add( p2 );

            var points = new List<MeasurementPoint>() { p1, p2, p3, p4 };

            var expected = new List<HashSet<MeasurementPoint>>()
                {
                    new HashSet<MeasurementPoint>() { p1, p2, p3 },
                    new HashSet<MeasurementPoint>() { p4 }
                };

            var output = example.GetSubregions( points );

            Assert.IsTrue( expected.Count == output.Count );
            for( int i = 0; i < output.Count; i++ )
            {
                AssertCollectionsMatch( expected[ i ], output[ i ] );
            }
        }

        [TestMethod]
        public void SingleYSetReturnsCorrectly()
        {
            var p1 = new MeasurementPoint( 0, 0, 100 );
            var p2 = new MeasurementPoint( 1, 0, 100 );
            var p3 = new MeasurementPoint( 2, 0, 100 );
            var p4 = new MeasurementPoint( 4, 4, 100 );

            p1.AdjacentPoints.Add( p2 );
            p1.AdjacentPoints.Add( p3 );

            p2.AdjacentPoints.Add( p1 );
            p2.AdjacentPoints.Add( p3 );

            p3.AdjacentPoints.Add( p1 );
            p3.AdjacentPoints.Add( p2 );

            var points = new List<MeasurementPoint>() { p1, p2, p3, p4 };

            var expected = new List<HashSet<MeasurementPoint>>()
                {
                    new HashSet<MeasurementPoint>() { p1, p2, p3 },
                    new HashSet<MeasurementPoint>() { p4 }
                };

            var output = example.GetSubregions( points );

            Assert.IsTrue( expected.Count == output.Count );
            for( int i = 0; i < output.Count; i++ )
            {
                AssertCollectionsMatch( expected[ i ], output[ i ] );
            }
        }

        [TestMethod]
        public void SingleWSetReturnsCorrectly()
        {
            var p1 = new MeasurementPoint( 0, 2, 100 );
            var p2 = new MeasurementPoint( 0, 1, 100 );
            var p3 = new MeasurementPoint( 1, 1, 100 );
            var p4 = new MeasurementPoint( 1, 0, 100 );
            var p5 = new MeasurementPoint( 2, 0, 100 );
            var p6 = new MeasurementPoint( 4, 4, 100 );

            p1.AdjacentPoints.Add( p2 );

            p2.AdjacentPoints.Add( p1 );
            p2.AdjacentPoints.Add( p3 );

            p3.AdjacentPoints.Add( p2 );
            p3.AdjacentPoints.Add( p4 );

            p4.AdjacentPoints.Add( p3 );
            p4.AdjacentPoints.Add( p5 );

            p5.AdjacentPoints.Add( p4 );

            var points = new List<MeasurementPoint>() { p1, p2, p3, p4, p5, p6 };

            var expected = new List<HashSet<MeasurementPoint>>()
                {
                    new HashSet<MeasurementPoint>() { p1, p2, p3, p4, p5 },
                    new HashSet<MeasurementPoint>() { p6 }
                };

            var output = example.GetSubregions( points );

            Assert.IsTrue( expected.Count == output.Count );
            for( int i = 0; i < output.Count; i++ )
            {
                AssertCollectionsMatch( expected[ i ], output[ i ] );
            }
        }
    }
}

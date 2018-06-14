using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExampleLibrary;

namespace ExampleUnitTests
{
    [TestClass]
    public class GetCenterOfMassTests : ExampleTestsBase
    {
        [TestMethod]
        public void ProvidedPairReturnsCorrectly()
        {
            var p7 = new MeasurementPoint( 5, 4, 250 );
            var p8 = new MeasurementPoint( 5, 5, 250 );

            var subregion = new HashSet<MeasurementPoint>() { p7, p8 };
            var expected = new Point( 5, 5 );
            var output = example.GetCenterOfMass( subregion );

            Assert.IsTrue( expected.Equals( output ) );
        }

        [TestMethod]
        public void ProvidedPointReturnsCorrectly()
        {
            var p1 = new MeasurementPoint( 1, 1, 210 );

            var subregion = new HashSet<MeasurementPoint>() { p1 };
            var output = example.GetCenterOfMass( subregion );
            var expected = new Point( 1, 1 );

            Assert.IsTrue( expected.Equals( output ) );
        }

        [TestMethod]
        public void ProvidedWReturnsCorrectly()
        {
            var p2 = new MeasurementPoint( 3, 2, 250 );
            var p3 = new MeasurementPoint( 3, 3, 250 );
            var p4 = new MeasurementPoint( 4, 1, 230 );
            var p5 = new MeasurementPoint( 4, 2, 245 );
            var p6 = new MeasurementPoint( 5, 1, 220 );

            var subregion = new HashSet<MeasurementPoint>() { p2, p3, p4, p5, p6 };
            var expected = new Point( 4, 2 );
            var output = example.GetCenterOfMass( subregion );

            Assert.IsTrue( expected.Equals( output ) );
        }

        [TestMethod]
        public void UniformXSetReturnsCorrectly()
        {
            var p1 = new MeasurementPoint( 0, 0, 1 );
            var p2 = new MeasurementPoint( 1, 0, 1 );
            var p3 = new MeasurementPoint( 2, 0, 1 );
            var p4 = new MeasurementPoint( 3, 0, 1 );
            var p5 = new MeasurementPoint( 4, 0, 1 );

            var subregion = new HashSet<MeasurementPoint>() { p1, p2, p3, p4, p5 };
            var expected = new Point( 2, 0 );
            var output = example.GetCenterOfMass( subregion );

            Assert.IsTrue( expected.Equals( output ) );
        }

        [TestMethod]
        public void NonuniformXSetReturnsCorrectly()
        {
            var p1 = new MeasurementPoint( 0, 0, 4 );
            var p2 = new MeasurementPoint( 1, 0, 1 );
            var p3 = new MeasurementPoint( 2, 0, 1 );
            var p4 = new MeasurementPoint( 3, 0, 1 );
            var p5 = new MeasurementPoint( 4, 0, 1 );

            var subregion = new HashSet<MeasurementPoint>() { p1, p2, p3, p4, p5 };
            var expected = new Point( 1, 0 );
            var output = example.GetCenterOfMass( subregion );

            Assert.IsTrue( expected.Equals( output ) );
        }

        [TestMethod]
        public void UniformYSetReturnsCorrectly()
        {
            var p1 = new MeasurementPoint( 0, 0, 1 );
            var p2 = new MeasurementPoint( 0, 1, 1 );
            var p3 = new MeasurementPoint( 0, 2, 1 );
            var p4 = new MeasurementPoint( 0, 3, 1 );
            var p5 = new MeasurementPoint( 0, 4, 1 );

            var subregion = new HashSet<MeasurementPoint>() { p1, p2, p3, p4, p5 };
            var expected = new Point( 0, 2 );
            var output = example.GetCenterOfMass( subregion );

            Assert.IsTrue( expected.Equals( output ) );
        }

        [TestMethod]
        public void NonuniformYSetReturnsCorrectly()
        {
            var p1 = new MeasurementPoint( 0, 0, 4 );
            var p2 = new MeasurementPoint( 0, 1, 1 );
            var p3 = new MeasurementPoint( 0, 2, 1 );
            var p4 = new MeasurementPoint( 0, 3, 1 );
            var p5 = new MeasurementPoint( 0, 4, 1 );

            var subregion = new HashSet<MeasurementPoint>() { p1, p2, p3, p4, p5 };
            var expected = new Point( 0, 1 );
            var output = example.GetCenterOfMass( subregion );

            Assert.IsTrue( expected.Equals( output ) );
        }

        [TestMethod]
        public void UniformCombinedSetReturnsCorrectly()
        {
            var p1 = new MeasurementPoint( 2, 0, 1 );
            var p2 = new MeasurementPoint( 2, 1, 1 );
            var p3 = new MeasurementPoint( 2, 2, 1 );
            var p4 = new MeasurementPoint( 2, 3, 1 );
            var p5 = new MeasurementPoint( 2, 4, 1 );
            var p6 = new MeasurementPoint( 0, 2, 1 );
            var p7 = new MeasurementPoint( 1, 2, 1 );
            var p8 = new MeasurementPoint( 2, 2, 1 );
            var p9 = new MeasurementPoint( 3, 2, 1 );
            var p10 = new MeasurementPoint( 4, 2, 1 );

            var subregion = new HashSet<MeasurementPoint>() { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
            var expected = new Point( 2, 2 );
            var output = example.GetCenterOfMass( subregion );

            Assert.IsTrue( expected.Equals( output ) );
        }

        [TestMethod]
        public void NonuniformCombinedSetReturnsCorrectly()
        {
            var p1 = new MeasurementPoint( 2, 0, 1 );
            var p2 = new MeasurementPoint( 2, 1, 1 );
            var p3 = new MeasurementPoint( 2, 2, 1 );
            var p4 = new MeasurementPoint( 2, 3, 1 );
            var p5 = new MeasurementPoint( 2, 4, 4 );
            var p6 = new MeasurementPoint( 0, 2, 1 );
            var p7 = new MeasurementPoint( 1, 2, 1 );
            var p8 = new MeasurementPoint( 2, 2, 1 );
            var p9 = new MeasurementPoint( 3, 2, 1 );
            var p10 = new MeasurementPoint( 4, 2, 4 );

            var subregion = new HashSet<MeasurementPoint>() { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
            var expected = new Point( 3, 3 );
            var output = example.GetCenterOfMass( subregion );

            Assert.IsTrue( expected.Equals( output ) );
        }
    }
}

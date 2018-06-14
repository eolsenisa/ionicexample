using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExampleLibrary;

namespace ExampleUnitTests
{
    [TestClass]
    public class PointTests
    {
        protected Point GetPointA
            => new Point( 0, 0 );

        protected Point GetPointB
            => new Point( 0, 0 );

        protected Point GetPointC
            => new Point( 1, 1 );

        [TestMethod]
        public void EqualsIsTrueIfObjectsMatch()
        {
            var a = GetPointA;
            var b = GetPointB;
            Assert.IsTrue( a.Equals( b ) );
        }

        [TestMethod]
        public void EqualsIsFalseIfObjectsDiffer()
        {
            var a = GetPointA;
            var c = GetPointC;
            Assert.IsFalse( a.Equals( c ) );
        }

        [TestMethod]
        public void EqualObjectsProduceSameHashCode()
        {
            var a = GetPointA;
            var b = GetPointB;
            var aHash = a.GetHashCode();
            var bHash = b.GetHashCode();
            Assert.IsTrue( aHash.Equals( bHash ) );
        }

        [TestMethod]
        public void UnequalObjectsProduceDifferentHashCodes()
        {
            var a = GetPointA;
            var c = GetPointC;
            var aHash = a.GetHashCode();
            var cHash = c.GetHashCode();
            Assert.IsFalse( aHash.Equals( cHash ) );
        }
    }
}

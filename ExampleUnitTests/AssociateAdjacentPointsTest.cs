using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExampleLibrary;

namespace ExampleUnitTests
{
    [TestClass]
    public class AssociateAdjacentPointsTests : ExampleTestsBase
    {
        #region Methods (protected)

        protected HashSet<MeasurementPoint> GetBottomEdgeSet( out List<MeasurementPoint> points )
        {
            var p1 = new MeasurementPoint( 2, 1, 2 );
            var p2 = new MeasurementPoint( 1, 0, 2 );
            var p3 = new MeasurementPoint( 1, 1, 2 );
            var p4 = new MeasurementPoint( 1, 2, 2 );
            var p5 = new MeasurementPoint( 2, 0, 2 );
            var p6 = new MeasurementPoint( 2, 2, 2 );

            points = new List<MeasurementPoint>() { p1, p2, p3, p4, p5, p6 };
            var expected = new HashSet<MeasurementPoint>() { p2, p3, p4, p5, p6 };
            return expected;
        }

        protected HashSet<MeasurementPoint> GetBottomLeftSet( out List<MeasurementPoint> points )
        {
            var p1 = new MeasurementPoint( 2, 0, 2 );
            var p2 = new MeasurementPoint( 1, 0, 2 );
            var p3 = new MeasurementPoint( 1, 1, 2 );
            var p4 = new MeasurementPoint( 2, 1, 2 );

            points = new List<MeasurementPoint>() { p1, p2, p3, p4 };
            var expected = new HashSet<MeasurementPoint>() { p2, p3, p4 };
            return expected;

        }

        protected HashSet<MeasurementPoint> GetBottomRightSet( out List<MeasurementPoint> points )
        {
            var p1 = new MeasurementPoint( 2, 2, 2 );
            var p2 = new MeasurementPoint( 1, 1, 2 );
            var p3 = new MeasurementPoint( 1, 2, 2 );
            var p4 = new MeasurementPoint( 2, 1, 2 );

            points = new List<MeasurementPoint>() { p1, p2, p3, p4 };
            var expected = new HashSet<MeasurementPoint>() { p2, p3, p4 };
            return expected;
        }

        protected HashSet<MeasurementPoint> GetCenterAloneSet( out List<MeasurementPoint> points )
        {
            var p1 = new MeasurementPoint( 1, 1, 2 );

            points = new List<MeasurementPoint>() { p1 };
            var expected = new HashSet<MeasurementPoint>();
            return expected;
        }

        protected HashSet<MeasurementPoint> GetCenterSurroundSet( out List<MeasurementPoint> points )
        {
            var p1 = new MeasurementPoint( 1, 1, 2 );
            var p2 = new MeasurementPoint( 0, 0, 2 );
            var p3 = new MeasurementPoint( 0, 1, 2 );
            var p4 = new MeasurementPoint( 0, 2, 2 );
            var p5 = new MeasurementPoint( 1, 0, 2 );
            var p6 = new MeasurementPoint( 1, 2, 2 );
            var p7 = new MeasurementPoint( 2, 0, 2 );
            var p8 = new MeasurementPoint( 2, 1, 2 );
            var p9 = new MeasurementPoint( 2, 2, 2 );

            points = new List<MeasurementPoint>() { p1, p2, p3, p4, p5, p6, p7, p8, p9 };
            var expected = new HashSet<MeasurementPoint>() { p2, p3, p4, p5, p6, p7, p8, p9 };
            return expected;
        }

        protected HashSet<MeasurementPoint> GetCenterPlusSet( out List<MeasurementPoint> points )
        {
            var p1 = new MeasurementPoint( 1, 1, 2 );
            var p2 = new MeasurementPoint( 0, 1, 2 );
            var p3 = new MeasurementPoint( 1, 0, 2 );
            var p4 = new MeasurementPoint( 1, 2, 2 );
            var p5 = new MeasurementPoint( 2, 1, 2 );

            points = new List<MeasurementPoint>() { p1, p2, p3, p4, p5 };
            var expected = new HashSet<MeasurementPoint>() { p2, p3, p4, p5 };
            return expected;
        }

        protected HashSet<MeasurementPoint> GetCenterDiagonalsSet( out List<MeasurementPoint> points )
        {
            var p1 = new MeasurementPoint( 1, 1, 2 );
            var p2 = new MeasurementPoint( 0, 0, 2 );
            var p3 = new MeasurementPoint( 0, 2, 2 );
            var p4 = new MeasurementPoint( 2, 0, 2 );
            var p5 = new MeasurementPoint( 2, 2, 2 );

            points = new List<MeasurementPoint>() { p1, p2, p3, p4, p5 };
            var expected = new HashSet<MeasurementPoint>() { p2, p3, p4, p5 };
            return expected;
        }

        protected HashSet<MeasurementPoint> GetLeftEdgeSet( out List<MeasurementPoint> points )
        {
            var p1 = new MeasurementPoint( 1, 0, 2 );
            var p2 = new MeasurementPoint( 0, 0, 2 );
            var p3 = new MeasurementPoint( 0, 1, 2 );
            var p4 = new MeasurementPoint( 1, 1, 2 );
            var p5 = new MeasurementPoint( 2, 0, 2 );
            var p6 = new MeasurementPoint( 2, 1, 2 );

            points = new List<MeasurementPoint>() { p1, p2, p3, p4, p5, p6 };
            var expected = new HashSet<MeasurementPoint>() { p2, p3, p4, p5, p6 };
            return expected;
        }

        protected HashSet<MeasurementPoint> GetRightEdgeSet( out List<MeasurementPoint> points )
        {
            var p1 = new MeasurementPoint( 1, 2, 2 );
            var p2 = new MeasurementPoint( 0, 1, 2 );
            var p3 = new MeasurementPoint( 0, 2, 2 );
            var p4 = new MeasurementPoint( 1, 1, 2 );
            var p5 = new MeasurementPoint( 2, 1, 2 );
            var p6 = new MeasurementPoint( 2, 2, 2 );

            points = new List<MeasurementPoint>() { p1, p2, p3, p4, p5, p6 };
            var expected = new HashSet<MeasurementPoint>() { p2, p3, p4, p5, p6 };
            return expected;
        }

        protected HashSet<MeasurementPoint> GetSinglePointSet( int x, int y, out List<MeasurementPoint> points )
        {
            var p1 = new MeasurementPoint( 1, 1, 2 );
            var p2 = new MeasurementPoint( x, y, 2 );

            points = new List<MeasurementPoint>() { p1, p2 };
            var expected = new HashSet<MeasurementPoint>() { p2 };
            expected.Remove( p1 );
            return expected;
        }

        protected HashSet<MeasurementPoint> GetTopEdgeSet( out List<MeasurementPoint> points )
        {
            var p1 = new MeasurementPoint( 2, 1, 2 );
            var p2 = new MeasurementPoint( 1, 0, 2 );
            var p3 = new MeasurementPoint( 1, 1, 2 );
            var p4 = new MeasurementPoint( 1, 2, 2 );
            var p5 = new MeasurementPoint( 2, 0, 2 );
            var p6 = new MeasurementPoint( 2, 2, 2 );

            points = new List<MeasurementPoint>() { p1, p2, p3, p4, p5, p6 };
            var expected = new HashSet<MeasurementPoint>() { p2, p3, p4, p5, p6 };
            return expected;
        }

        protected HashSet<MeasurementPoint> GetTopLeftSet( out List<MeasurementPoint> points )
        {
            var p1 = new MeasurementPoint( 0, 0, 2 );
            var p2 = new MeasurementPoint( 0, 1, 2 );
            var p3 = new MeasurementPoint( 1, 0, 2 );
            var p4 = new MeasurementPoint( 1, 1, 2 );

            points = new List<MeasurementPoint>() { p1, p2, p3, p4 };
            var expected = new HashSet<MeasurementPoint>() { p2, p3, p4 };
            return expected;
        }

        public HashSet<MeasurementPoint> GetTopRightSet( out List<MeasurementPoint> points )
        {
            var p1 = new MeasurementPoint( 0, 2, 2 );
            var p2 = new MeasurementPoint( 0, 1, 2 );
            var p3 = new MeasurementPoint( 1, 1, 2 );
            var p4 = new MeasurementPoint( 1, 2, 2 );

            points = new List<MeasurementPoint>() { p1, p2, p3, p4 };
            var expected = new HashSet<MeasurementPoint>() { p2, p3, p4 };
            return expected;
        }

        #endregion

        #region Methods (public)

        [TestMethod]
        public void BottomEdgeSetReturnsCorrectly()
        {
            var points = new List<MeasurementPoint>();
            var expected = GetBottomEdgeSet( out points );
            example.AssociateAdjacentPoints( points );
            var targetPoint = points[ 0 ];
            AssertCollectionsMatch( expected, targetPoint.AdjacentPoints );
        }

        [TestMethod]
        public void BottomLeftSetReturnsCorrectly()
        {
            var points = new List<MeasurementPoint>();
            var expected = GetBottomLeftSet( out points );
            example.AssociateAdjacentPoints( points );
            var targetPoint = points[ 0 ];
            AssertCollectionsMatch( expected, targetPoint.AdjacentPoints );
        }

        [TestMethod]
        public void BottomRightSetReturnsCorrectly()
        {
            var points = new List<MeasurementPoint>();
            var expected = GetBottomRightSet( out points );
            example.AssociateAdjacentPoints( points );
            var targetPoint = points[ 0 ];
            AssertCollectionsMatch( expected, targetPoint.AdjacentPoints );
        }

        [TestMethod]
        public void LeftEdgeSetReturnsCorrectly()
        {
            var points = new List<MeasurementPoint>();
            var expected = GetLeftEdgeSet( out points );
            example.AssociateAdjacentPoints( points );
            var targetPoint = points[ 0 ];
            AssertCollectionsMatch( expected, targetPoint.AdjacentPoints );
        }

        [TestMethod]
        public void CenterAloneSetReturnsCorrectly()
        {
            var points = new List<MeasurementPoint>();
            var expected = GetCenterAloneSet( out points );
            example.AssociateAdjacentPoints( points );
            var targetPoint = points[ 0 ];
            AssertCollectionsMatch( expected, targetPoint.AdjacentPoints );
        }

        [TestMethod]
        public void CenterSurroundSetReturnsCorrectly()
        {
            var points = new List<MeasurementPoint>();
            var expected = GetCenterSurroundSet( out points );
            example.AssociateAdjacentPoints( points );
            var targetPoint = points[ 0 ];
            AssertCollectionsMatch( expected, targetPoint.AdjacentPoints );
        }

        [TestMethod]
        public void CenterPlusSetReturnsCorrectly()
        {
            var points = new List<MeasurementPoint>();
            var expected = GetCenterPlusSet( out points );
            example.AssociateAdjacentPoints( points );
            var targetPoint = points[ 0 ];
            AssertCollectionsMatch( expected, targetPoint.AdjacentPoints );
        }

        [TestMethod]
        public void CenterDiagonalsSetReturnsCorrectly()
        {
            var points = new List<MeasurementPoint>();
            var expected = GetCenterDiagonalsSet( out points );
            example.AssociateAdjacentPoints( points );
            var targetPoint = points[ 0 ];
            AssertCollectionsMatch( expected, targetPoint.AdjacentPoints );
        }

        [TestMethod]
        public void RandomSinglePointsReturnCorrectly()
        {
            for( var x = 0; x < 3; x++ )
                for( var y = 0; y < 3; y++ )
                {
                    var points = new List<MeasurementPoint>();
                    var expected = GetSinglePointSet( x, y, out points );
                    example.AssociateAdjacentPoints( points );
                    var targetPoint = points[ 0 ];
                    AssertCollectionsMatch( expected, targetPoint.AdjacentPoints );

                    expected.Clear();

                    if( !points[ 0 ].Equals( points[ 1 ] ) )
                        expected.Add( points[ 0 ] );

                    targetPoint = points[ 1 ];
                    AssertCollectionsMatch( expected, targetPoint.AdjacentPoints );
                }
        }

        [TestMethod]
        public void RightEdgeSetReturnsCorrectly()
        {
            var points = new List<MeasurementPoint>();
            var expected = GetRightEdgeSet( out points );
            example.AssociateAdjacentPoints( points );
            var targetPoint = points[ 0 ];
            AssertCollectionsMatch( expected, targetPoint.AdjacentPoints );
        }

        [TestMethod]
        public void TopEdgeSetReturnsCorrectly()
        {
            var points = new List<MeasurementPoint>();
            var expected = GetTopEdgeSet( out points );
            example.AssociateAdjacentPoints( points );
            var targetPoint = points[ 0 ];
            AssertCollectionsMatch( expected, targetPoint.AdjacentPoints );
        }

        [TestMethod]
        public void TopLeftSetReturnsCorrectly()
        {
            var points = new List<MeasurementPoint>();
            var expected = GetTopLeftSet( out points );
            example.AssociateAdjacentPoints( points );
            var targetPoint = points[ 0 ];
            AssertCollectionsMatch( expected, targetPoint.AdjacentPoints );
        }

        [TestMethod]
        public void TopRightSetReturnsCorrectly()
        {
            var points = new List<MeasurementPoint>();
            var expected = GetTopRightSet( out points );
            example.AssociateAdjacentPoints( points );
            var targetPoint = points[ 0 ];
            AssertCollectionsMatch( expected, targetPoint.AdjacentPoints );
        }

        #endregion
    }
}

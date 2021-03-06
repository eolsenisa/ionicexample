﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExampleLibrary
{
    /*
     *  Assumptions:
     *    Exception handling is not required for this example
     *    Int32 is sufficient to contain measurement and dimensional values
     *    Measurements and Threshold cannot be negative
     *    X and Y values cannot be negative
     *    2D array means a uniform array int[,] and not a jagged array int[][]
     *    Array dimensions should be interpreted as [x,y] and not [y,x] 
     *    Array is square like the example
     *    When calculating the center of mass:
     *      Values < 0.5 should be rounded down to the previous integer
     *      Values >= 0.5 should be rounded up to the next integer
     */

    public class ExampleFunctions
    {
        #region Methods (protected)

        protected int RoundWeightedPosition( double pos )
        {
            var rem = pos % 1d;
            if( rem > 0d )
                if( rem < 0.5d )
                    pos -= rem;
                else
                    pos += ( 1d - rem );

            return (int) pos;
        }

        #endregion

        #region Methods (public)

        public IList<MeasurementPoint> AssociateAdjacentPoints( IList<MeasurementPoint> points )
        {
            //-- Step through all points to determine adjacency to each other
            for( var i = 0; i < points.Count; i++ )
            {
                var current = points[ i ];
                for( var j = i + 1; j < points.Count; j++ )
                {
                    var candidate = points[ j ];

                    //-- Skip duplicate entries
                    if( candidate.X == current.X && candidate.Y == current.Y )
                        continue;

                    //-- Skip non-adjacent candidates
                    if( candidate.X < current.X - 1 )
                        continue;

                    if( candidate.X > current.X + 1 )
                        continue;

                    if( candidate.Y < current.Y - 1 )
                        continue;

                    if( candidate.Y > current.Y + 1 )
                        continue;

                    //-- Associate points as adjacent
                    current.AdjacentPoints.Add( candidate );
                    candidate.AdjacentPoints.Add( current );
                }
            }

            return points;
        }

        public Point GetCenterOfMass( HashSet<MeasurementPoint> subregion )
        {
            //-- Calculate total weight
            double totalWeight = 0d;
            foreach( var point in subregion )
                totalWeight += (double) point.Value;

            //-- Calculation weighted positions
            var weightedXtotal = 0d;
            var weightedYtotal = 0d;
            foreach( var point in subregion )
            {
                var fValue = (double) point.Value;
                var fWeight = fValue / totalWeight;
                //-- Shift positions by 1 so we can weight X=0 and Y=0 properly
                var fX = (double) point.X + 1d;
                var fY = (double) point.Y + 1d;
                weightedXtotal += fX * fWeight;
                weightedYtotal += fY * fWeight;
            }

            //-- Unshift calculated position by 1 to compensate for shift during calc
            weightedXtotal--;
            weightedYtotal--;

            //-- Round weighted positions
            var x = RoundWeightedPosition( weightedXtotal );
            var y = RoundWeightedPosition( weightedYtotal );

            //-- Return point
            var center = new Point( x, y );
            return center;
        }

        public IList<Point> GetCentersOfMass( IList<HashSet<MeasurementPoint>> subregions )
        {
            var centers = new List<Point>();
            foreach( var subregion in subregions )
            {
                var center = GetCenterOfMass( subregion );
                centers.Add( center );
            }
            return centers;
        }

        public IList<MeasurementPoint> GetPointsAboveThreshold( int[,] measurementArray, int threshold )
        {
            var xmax = measurementArray.GetLength( 0 );
            var ymax = measurementArray.GetLength( 1 );

            var measurementPoints = new List<MeasurementPoint>();

            for( var x = 0; x < xmax; x++ )
                for( var y = 0; y < ymax; y++ )
                {
                    var value = measurementArray[ x, y ];
                    if( value > threshold )
                    {
                        var point = new MeasurementPoint( x, y, value );
                        measurementPoints.Add( point );
                    }
                }

            return measurementPoints;
        }

        public IList<HashSet<MeasurementPoint>> GetSubregions( IList<MeasurementPoint> points )
        {
            //-- Walk adjacent points to build subregions
            var subregions = new List<HashSet<MeasurementPoint>>();
            var candidates = new HashSet<MeasurementPoint>( points );

            Action<HashSet<MeasurementPoint>, MeasurementPoint> processAdjacent = null;
            processAdjacent =
                ( subregion, target ) =>
                {
                    subregion.Add( target );
                    foreach( var adjacent in target.AdjacentPoints )
                        if( !subregion.Contains( adjacent ) )
                            processAdjacent( subregion, adjacent );
                    candidates.Remove( target );
                };

            while( candidates.Count > 0 )
            {
                var subregion = new HashSet<MeasurementPoint>();
                var target = candidates.First();
                processAdjacent( subregion, target );
                subregions.Add( subregion );
            }

            return subregions;
        }

        public IList<Point> ProcessMeasurements( int[,] measurements, int threshold )
        {
            //-- Process points of interest 
            var points = GetPointsAboveThreshold( measurements, threshold );

            //-- Associate points of interest
            points = AssociateAdjacentPoints( points );

            //-- Congeal subregions
            var subregions = GetSubregions( points );

            //-- Calculate centers of mass
            var centers = GetCentersOfMass( subregions );
            return centers;
        }

        #endregion
    }
}

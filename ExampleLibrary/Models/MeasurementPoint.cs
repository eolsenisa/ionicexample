using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleLibrary
{
    public class MeasurementPoint : Point
    {
        public int Value { get; set; }
        public ISet<MeasurementPoint> AdjacentPoints { get; set; }

        public MeasurementPoint( int x, int y, int value )
            : base( x, y )
        {
            this.Value = value;
            this.AdjacentPoints = new HashSet<MeasurementPoint>();
        }

        public bool Equals( MeasurementPoint point )
        {
            if( !base.Equals( point ) )
                return false;

            if( !this.Value.Equals( point.Value ) )
                return false;

            return true;
        }

        public override bool Equals( object obj )
        {
            if( obj == null )
                return false;

            if( ReferenceEquals( this, obj ) )
                return true;

            var cast = obj as MeasurementPoint;
            if( cast == null )
                return false;

            return this.Equals( cast );
        }

        public override int GetHashCode()
        {
            var hashCode = -538802891;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            return hashCode;
        }
    }
}

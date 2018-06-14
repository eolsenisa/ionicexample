using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleLibrary
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point( int x, int y )
        {
            this.X = x;
            this.Y = y;
        }

        public bool Equals( Point point )
        {
            if( !this.X.Equals( point.X ) )
                return false;

            if( !this.Y.Equals( point.Y ) )
                return false;

            return true;
        }

        public override bool Equals( object obj )
        {
            if( obj == null )
                return false;

            if( ReferenceEquals( this, obj ) )
                return true;

            var cast = obj as Point;
            if( cast == null )
                return false;

            return this.Equals( cast );
        }

        public override int GetHashCode()
        {
            var hashCode = -538802891;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}

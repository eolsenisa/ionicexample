using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExampleLibrary;

namespace ExampleUnitTests
{
    public abstract class ExampleTestsBase
    {
        protected ExampleFunctions example = new ExampleFunctions();

        protected int maxTestSize = 6;

        protected void AssertCollectionsMatch<T>( ICollection<T> col1, ICollection<T> col2 )
        {
            Assert.IsTrue( col1.Count == col2.Count );

            var hashCol1 = new HashSet<T>( col1 );
            foreach( var item in col2 )
                Assert.IsTrue( hashCol1.Contains( item ) );
        }

        protected Random CreateRNG()
            => new Random( DateTime.Now.Millisecond );
    }
}

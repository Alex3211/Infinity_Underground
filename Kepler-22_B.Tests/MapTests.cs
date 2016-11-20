using Kepler_22_B.API;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.Tests
{
    [TestFixture]
    class MapTests
    {
        /// <summary>
        /// Tests the nunit.
        /// </summary>
        [Test]
        public void TestNunit()
        {
            Assert.That(true);
        }

        /// <summary>
        /// Tests if the player can go on the left.
        /// </summary>
        [Test]
        public void TestIfCreateWorldCreateWorld()
        {
            World world = new World();

            Assert.That(world, Is.EqualTo(new World()));
        }

    }
}

using NUnit.Framework;
using System;
using InfinityUnderground.API.Characteres;
using InfinityUnderground.Characteres;

namespace InfinityUnderground.Tests
{
    [TestFixture]
    public class CTPlayerTests
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
        public void TestIfThePlayerCanGoOnTheLeft()
        {
            CTPlayer sut = new CTPlayer(new API.World());

            int _initialPositionX = sut.PositionX;

            sut.Deplacement((int)Direction.Left);

            Assert.That(sut.PositionX, Is.EqualTo(_initialPositionX - sut.GetCharacterType.MoveSpeed));
        }

        /// <summary>
        /// Tests if the player can go down.
        /// </summary>
        [Test]
        public void TestIfThePlayerCanGoDown()
        {
            CTPlayer sut = new CTPlayer(new API.World());

            int _initialPositionY = sut.PositionY;

            sut.Deplacement((int)Direction.Bottom);

            Assert.That(sut.PositionY, Is.EqualTo(_initialPositionY + sut.GetCharacterType.MoveSpeed));
        }

        /// <summary>
        /// Tests if the player can on the right.
        /// </summary>
        [Test]
        public void TestIfThePlayerCanOnTheRight()
        {
            CTPlayer sut = new CTPlayer(new API.World());

            int _initialPositionX = sut.PositionX;

            sut.Deplacement((int)Direction.Right);

            Assert.That(sut.PositionX, Is.EqualTo(_initialPositionX + sut.GetCharacterType.MoveSpeed));
        }

        /// <summary>
        /// Tests if the player can go top.
        /// </summary>
        [Test]
        public void TestIfThePlayerCanGoUp()
        {
            CTPlayer sut = new CTPlayer(new API.World());

            int _intialPositionY = sut.PositionY;

            sut.Deplacement((int)Direction.Up);

            Assert.That(sut.PositionY, Is.EqualTo(_intialPositionY - sut.GetCharacterType.MoveSpeed));
        }

        /// <summary>
        /// Inserts the position in constructor.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        [TestCase(1, 10)]
        [TestCase(50, 12)]
        [TestCase(500, 2)]
        public void InsertPositionInConstructor(int x, int y)
        {
            CTPlayer sut = new CTPlayer(x, y);

            Assert.That(sut.PositionX, Is.EqualTo(x));
            Assert.That(sut.PositionY, Is.EqualTo(y));

        }

        /// <summary>
        /// Attributes the new name to the new character.
        /// </summary>
        [Test]
        public void AttributeNewNameToTheNewCharacter()
        {
            CTPlayer sut = new CTPlayer(new API.World());

            Assert.That(sut.Name, Is.Not.Null);
        }


        [TestCase(-1, 12)]
        [TestCase(-1, -2)]
        [TestCase(0, -20)]
        public void InsertNegativePositionX(int x, int y)
        {
            Assert.Throws<ArgumentOutOfRangeException>( () => new CTPlayer(x, y));
        }



    }
}

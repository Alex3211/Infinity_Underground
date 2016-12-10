using InfinityUnderground.API;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUnderground.Tests
{
    [TestFixture]
    class AttackTest
    {

        [Test]
        public void TestConvertionDoubleToInt()
        {
            double _doubleNumbre = 14.25;


            int _intNumber = (int)(_doubleNumbre * 100);


            Assert.That(_intNumber, Is.EqualTo(1425));
        }

        [TestCase(100.00, true)]
        [TestCase(00.00, false)]
        public void CriticalChangeShouldReturnTrueAndFalse(double criticalChance, bool result)
        {
            World sut = new World();

            Assert.That(sut.Players[0].GetCharacterType.GetAttacks.IsCritical(criticalChance), Is.EqualTo(result));
        }

        [TestCase(10, 20, 12)]
        [TestCase(1203, 45, 1744)]
        [TestCase(55, 79, 98)]
        [TestCase(565, 40, 791)]
        public void CriticalDamage(int damage, int pourcentToAdd, int result)
        {
            World sut = new World();

            Assert.That(sut.Players[0].GetCharacterType.GetAttacks.CriticalDamage(damage, pourcentToAdd), Is.EqualTo(result));
        }

        [TestCase(360, 40, 216)]
        [TestCase(360, 5.25, 341)]
        [TestCase(1024, 8.00, 942)]
        [TestCase(10, 40, 6)]
        public void ReduceTheDamageWithTheArmor(int damage, double pourcentToReduce, int result)
        {
            World sut = new World();

            Assert.That(sut.Players[0].GetCharacterType.GetAttacks.ReduceDamageWithArmor(damage, pourcentToReduce), Is.EqualTo(result));
        }

    }
}

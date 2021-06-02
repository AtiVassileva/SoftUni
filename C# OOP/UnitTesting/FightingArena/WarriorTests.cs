using System;
using NUnit.Framework;

namespace Tests
{
    using FightingArena;
    public class WarriorTests
    {
        private const string DefenderName = "Shogun";
        private const string DefaultName = "Hector";
        private const int DefaultDamage = 88;
        private const int DefaultHp = 100;

        private Warrior defaultWarrior;

        [SetUp]
        public void Setup()
        {
            this.defaultWarrior = new Warrior
                (DefaultName, DefaultDamage, DefaultHp);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            var warrior = new Warrior(DefaultName, DefaultDamage, DefaultHp);

            var actualName = warrior.Name;
            var actualDamage = warrior.Damage;
            var actualHP = warrior.HP;

            Assert.AreEqual(DefaultName, actualName);
            Assert.AreEqual(DefaultDamage, actualDamage);
            Assert.AreEqual(DefaultHp, actualHP);
        }

        [Test]
        public void NameShouldThrowExceptionWhenNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var warrior = new Warrior(null, DefaultDamage, DefaultHp);
            });
        }

        [Test]
        public void NameShouldThrowExceptionWhenEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var warrior = new Warrior(string.Empty, DefaultDamage, DefaultHp);
            });
        }

        [Test]
        public void NameShouldThrowExceptionWhenWhitespace()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var warrior = new Warrior("      ", DefaultDamage, DefaultHp);
            });
        }

        [Test]
        public void DamageShouldThrowExceptionWhenZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var warrior = new Warrior(DefaultName, 0, DefaultHp);
            });
        }

        [Test]
        public void DamageShouldThrowExceptionWhenNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var warrior = new Warrior(DefaultName, -23, DefaultHp);
            });
        }

        [Test]
        public void HpShouldThrowExceptionWhenNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var warrior = new Warrior(DefaultName, DefaultDamage, -50);
            });
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void AttackerWithHpLowerThanOrEqual30ShouldThrowException(int attackerHP)
        {
            var attackerName = DefaultName;
            var attackerDamage = 10;

            var defenderName = DefenderName;
            var defenderDamage = 10;
            var defenderHP = 40;

            var attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            var defender = new Warrior(defenderName, defenderDamage, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        [TestCase(15)]
        [TestCase(30)]
        public void DefenderWithHpLowerThanOrEqual30ShouldThrowException(int defenderHp)
        {

            var defenderName = DefenderName;
            var defenderDamage = 10;

            var attacker = new Warrior(DefaultName, DefaultDamage, DefaultHp);
            var defender = new Warrior(defenderName, defenderDamage, defenderHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void WeakerAttackerStrongerDefenderShouldThrowException()
        {
            var defenderName = "Shogun";
            var defenderDamage = 800;
            var defenderHP = 400;

            var attacker = new Warrior(DefaultName, defenderDamage, DefaultHp);
            var defender = new Warrior(defenderName, defenderDamage, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void AttackerDefenderHpShouldBeDecreasedBySuccessfulAttack()
        {
            var defenderName = DefenderName;
            var defenderDamage = 10;
            var defenderHP = 50;

            var attacker = new Warrior(DefaultName, DefaultDamage, DefaultHp);
            var defender = new Warrior(defenderName, defenderDamage, defenderHP);

            var expectedAttackerHP = DefaultHp - defenderDamage;
            var expectedDefenderHP = defenderHP - DefaultDamage;

            if (expectedDefenderHP < 0)
            {
                expectedDefenderHP = 0;
            }

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]
        public void StrongerAttackerShouldKillWeakerDefender()
        {
            var defenderName = DefenderName;
            var defenderDamage = 10;
            var defenderHP = 40;

            var attacker = new Warrior(DefaultName, DefaultDamage, DefaultHp);
            var defender = new Warrior(defenderName, defenderDamage, defenderHP);

            var expectedDefenderHP = 0;
            var expectedAttackerHP = DefaultHp - defender.Damage;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
    }
}
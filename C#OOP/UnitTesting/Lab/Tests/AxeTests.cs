using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int AttackPoints = 10;
    private Dummy _dummy;

    [SetUp]
    public void SetDummy()
    {
        this._dummy = new Dummy(100, 300);
    }

    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        //Arrange
        var axe = new Axe(AttackPoints, 10);

        //Act
        axe.Attack(this._dummy);

        //Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(9),
            "Axe Durability doesn't change after attack.");

    }
    [Test]
    public void AxeShouldThrowExceptionIfAttackIsMadeWithBrokenWeapon()
    {
        var axe = new Axe(AttackPoints, 0);

        Assert.That(() => axe.Attack(this._dummy),
            Throws.InvalidOperationException.
                With.Message.EqualTo("Axe is broken."));

    }
}
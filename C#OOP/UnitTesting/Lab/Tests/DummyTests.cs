using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private const int Experience = 200;
    private const int AttackPoints = 30;
    private const int DeadDummyHealth = 0;
    private const int AliveDummyHealth = 100;

    private Dummy _deadDummy;
    private Dummy _aliveDummy;

    [SetUp]
    public void CreateDeadDummy()
    {
        this._deadDummy = new Dummy(DeadDummyHealth, Experience);
        this._aliveDummy = new Dummy(AliveDummyHealth, Experience);
    }
    [Test]
    public void DummyShouldLoseHealthIfAttacked()
    {
        this._aliveDummy.TakeAttack(AttackPoints);
        Assert.That(this._aliveDummy.Health, Is.EqualTo(70));
    }

    [Test]
    public void DeadDummyShouldThrowException()
    {
        Assert.That(() => this._deadDummy.TakeAttack(AttackPoints),
            Throws.InvalidOperationException.
                With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyShouldGiveXp()
    {
        var experience = this._deadDummy.GiveExperience();

        Assert.That(experience, Is.EqualTo(Experience));
    }

    [Test]
    public void AliveDummyShouldNotGiveXp()
    {
        Assert.That(() => this._aliveDummy.GiveExperience(),
            Throws.InvalidOperationException.
            With.Message.EqualTo("Target is not dead."));
    }
}
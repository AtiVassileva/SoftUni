using Moq;
using NUnit.Framework;

public class HeroTests
{
    [Test]
    public void HeroShouldGainExperienceWhenTargetDies()
    {
        const int experience = 200;

        //Arrange
        var fakeWeapon = Mock.Of<IWeapon>();
        var fakeTarget = new Mock<ITarget>();

        fakeTarget.Setup(t => t.Health).Returns(0);
        fakeTarget.Setup(t => t.IsDead()).Returns(true);
        fakeTarget.Setup(t => t.GiveExperience()).Returns(experience);

        var hero = new Hero("Superman", fakeWeapon);

        //Act
        hero.Attack(fakeTarget.Object);

        //Assert
        Assert.That(hero.Experience, Is.EqualTo(experience));
    }
}
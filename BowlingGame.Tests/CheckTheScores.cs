namespace BowlingGame.Tests;
using FluentAssertions;

public class TestTheScores
{
    private BowlingScores _bowlingScores;

    [SetUp]
    public void Setup()
    {
        _bowlingScores = new BowlingScores();
    }

    [Test]
    public void Simple_Addition_Of_Integers() 
    {
        char[] simpleScore = { '1', '2' };        
        _bowlingScores.CalculateScores(simpleScore).Should().Be(3);
    }

    [Test]
    public void Simple_Addition_Of_With_Dash()
    {
        char[] scoreWithDash = { '1', '2', '-' };
        _bowlingScores.CalculateScores(scoreWithDash).Should().Be(3);
    }
}
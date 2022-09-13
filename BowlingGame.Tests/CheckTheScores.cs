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
    public void Test1() //simple addition of scores
    {
        char[] score = { '1', '2' };        
        _bowlingScores.CalculateScores(score).Should().Be(3);
    }
}
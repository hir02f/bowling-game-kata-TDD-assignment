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
    public void Simple_Addition_Of_Integers_With_Dash()
    {
        char[] scoreWithDash = { '1', '2', '-' };
        _bowlingScores.CalculateScores(scoreWithDash).Should().Be(3);
    }

    [Test]
    public void Adding_With_Ending_With_A_Spare()
    {
        char[] scoreWithSpare = { '1', '2', '/' };
        _bowlingScores.CalculateScores(scoreWithSpare).Should().Be(13);
    }

    [Test]
    public void Adding_With_A_Spare()
    {
        char[] testFrames = { '1', '/', '2' };
        _bowlingScores.CalculateScores(testFrames).Should().Be(13);
    }

    [Test]
    public void Adding_With_Strike_With_Two_Frames_Left() 
    {
         char[] testFrames = { 'X', '1', '2' };
        _bowlingScores.CalculateScores(testFrames).Should().Be(16);

        char[] testFrames2 = { 'X', 'X', '4', '2' };
        _bowlingScores.CalculateScores(testFrames2).Should().Be(46);
    }

    /* [Test]
     public void Adding_With_Ending_A_Strike() //fails - need to check that index is valid
     {
         char[] scoreWithDash = { '1', '2', 'X' };
         _bowlingScores.CalculateScores(scoreWithDash).Should().Be(13);
     }*/
}
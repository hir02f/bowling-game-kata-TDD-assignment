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

     [Test]
     public void Adding_With_Ending_A_Strike_Or_Spare() // To make sure don't calculated beyond the last one
     {
         char[] testFrame1 = { '1', '2', 'X' };
         _bowlingScores.CalculateScores(testFrame1).Should().Be(13);
     
        char[] testFrame2 = { '1', '2', '/' };
         _bowlingScores.CalculateScores(testFrame2).Should().Be(13);
    }

    [Test]
    public void Adding_Ten_Frames_No_Spares_Or_Strikes()
    {
        char[] testFrames = { '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-' };
        _bowlingScores.CalculateScores(testFrames).Should().Be(90);
    }

    [Test]
    public void Adding_Twelve_Frames_With_Spares_And_Or_Strikes()
    {
        //char[] testFrames = { '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/' };
        //_bowlingScores.CalculateScores(testFrames).Should().Be(150);
    }

    [Test]
    public void Adding_Twelve_Frames_With_All_Strikes()
    {
        //char[] testFrames = { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X' };
        //_bowlingScores.CalculateScores(testFrames).Should().Be(300);
    }
}
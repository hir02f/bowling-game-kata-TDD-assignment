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
        char[] testFrames = { '1', '2' };
        _bowlingScores.CalculateScores(testFrames).Should().Be(3);
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
    public void Adding_With_A_Spare() // Not coded for this
    {
        //char[] testFrames = { '1', '/', '2' };
        //_bowlingScores.CalculateScores(testFrames).Should().Be(14);
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

        //char[] testFrame3 = { '2', '/', '1', '-' };
        //_bowlingScores.CalculateScores(testFrame3).Should().Be(12);
    }
    
    [Test]
    public void Adding_Ten_Frames_No_Spares_Or_Strikes()
    {
        char[] testFrames = { '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-' };
        _bowlingScores.CalculateScores(testFrames).Should().Be(90);
    }
    
    [Test]
    public void Adding_Ten_Frames_With_Spares_With_Bonus()
    {
        char[] testFrames = { '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5' };
        _bowlingScores.CalculateScores(testFrames).Should().Be(150);

        char[] maxAllSpares = { '9', '/', '9', '/', '9', '/', '9', '/', '9', '/', '9', '/', '9', '/', '9', '/', '9', '/', '9', '/', '9' };
        _bowlingScores.CalculateScores(maxAllSpares).Should().Be(190);

        //char[] maxAllSpares2 = { '1', '/', '9', '/', '9', '/', '9', '/', '9', '/', '9', '/', '9', '/', '9', '/', '9', '/', '9', '/', '9' };
        //_bowlingScores.CalculateScores(maxAllSpares2).Should().Be(190);

    }

    [Test]
    public void Maximum_Score_All_Strikes()
    {
        char[] testFrames = { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X' };
        _bowlingScores.CalculateScores(testFrames).Should().Be(300);
    }

    [Test]
    public void Adding_Game_With_Bonus()
    {
       // char[] testFrames = { 'X', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '/', '1' };
       // _bowlingScores.CalculateScores(testFrames).Should().Be(300);
    }
}
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Project1;
using Project1.UserInterfaces;

namespace Project1.Tests;

public class Project1Tests
{
    [Theory]
    [InlineData("c",3)]
    [InlineData("r",5)]
    [InlineData("v",6)]
    [InlineData("x",7)]
    [InlineData("n",1)]
    [InlineData("uparrow",1)]
    [InlineData("e",2)]
    [InlineData("rightarrow",2)]
    [InlineData("s",4)]
    [InlineData("downarrow",4)]
    [InlineData("w",8)]
    [InlineData("leftarrow",8)]
    [InlineData("h",11)]
    public void UserInputHandler_ExpectedInput_ReturnsExpectedOutput_WhenOutOfCombat(string inputString, int expectedOutput)
    {
        int result = WelcomeToTheGame.UserInputHandler(inputString,false);

        Assert.Equal(expectedOutput,result);

    }

    [Theory]
    [InlineData("a",9)]
    [InlineData("f",10)]
    [InlineData("h",11)]
    public void UserInputHandler_ExpectedInput_ReturnsExpectedOutput_WhenInCombat(string inputString, int expectedOutput)
    {
        int result = WelcomeToTheGame.UserInputHandler(inputString,true);

        Assert.Equal(expectedOutput,result);

    }

    [Theory]
    [InlineData("",0)]
    [InlineData(" ",0)]
    [InlineData("j",0)]
    [InlineData("q",0)]
    [InlineData("6",0)]
    [InlineData("u",0)]
    [InlineData(",",0)]
    [InlineData("}",0)]
    [InlineData("5",0)]
    public void UserInputHandler_UnExpectedInput_ReturnsExpectedOutput_WhenOutOfCombat(string inputString, int expectedOutput)
    {
        int result = WelcomeToTheGame.UserInputHandler(inputString,false);

        Assert.Equal(expectedOutput,result);

    }

    [Theory]
    [InlineData("",0)]
    [InlineData(" ",0)]
    [InlineData("j",0)]
    [InlineData("q",0)]
    [InlineData("6",0)]
    [InlineData("u",0)]
    [InlineData(",",0)]
    [InlineData("}",0)]
    [InlineData("5",0)]
    public void UserInputHandler_UnExpectedInput_ReturnsExpectedOutput_WhenInCombat(string inputString, int expectedOutput)
    {
        int result = WelcomeToTheGame.UserInputHandler(inputString,true);

        Assert.Equal(expectedOutput,result);

    }   
}
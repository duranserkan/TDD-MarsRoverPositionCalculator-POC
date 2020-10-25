using MarsRoverPositionCalculator.Models;
using Shouldly;
using Xunit;

namespace MarsRoverPositionCalculator.Test.UnitTests
{
	public class RoverControlSignalTests
	{
		[Theory]
		[InlineData('L', RoverControlSignal.Left)]
		[InlineData('R', RoverControlSignal.Right)]
		[InlineData('M', RoverControlSignal.Move)]
		public void RoverControlSignal_Should_Be_Created_From_Letter(char controlLetter,
			RoverControlSignal expectedControlSignal)
		{
			var roverControlSignal = controlLetter.RoverControlSignalFromControlLetter();
			roverControlSignal.ShouldBe(expectedControlSignal);
		}
	}
}
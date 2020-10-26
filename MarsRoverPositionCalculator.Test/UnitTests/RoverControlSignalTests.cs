using MarsRoverPositionCalculator.Models;
using Shouldly;
using Xunit;

namespace MarsRoverPositionCalculator.Test.UnitTests
{
	public class RoverControlSignalTests
	{
		/// <summary>
		///     A rover's movement is controlled by control signal which is represented by a letter
		///     1. Control signal L is send for 90 degrees rover spin to left without moving from its current spot
		///     2. Control signal R is send for 90 degrees rover spin to right without moving from its current spot
		///     3. Control signal M is send for move rover forward one grid point, and maintain the same heading
		/// </summary>
		/// <param name="controlLetter"></param>
		/// <param name="expectedControlSignal"></param>
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
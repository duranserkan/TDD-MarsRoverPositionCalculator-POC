using MarsRoverPositionCalculator.Models;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace MarsRoverPositionCalculator.Test.UnitTests
{
	public class RoverMovementCalculatorInputTests
	{
		/// <summary>
		///4. The first line of movement calculator input is the upper-right coordinates of the plateau in format of "{x} {y}"
		///5. The rest of the input is information pertaining to the rovers that have been deployed.Each rover has two lines of input. 
		///   1. The first line gives the rover's position in position format
		///   2. The second line is a series of instructions telling the rover how to explore the plateau in format of "{C1}{C2}{C3}""
		/// </summary>
		[Theory]
		[MemberData(nameof(GetRoverMovementCalculatorInput))]
		public void RoverMovementCalculatorInput_Should_Be_Created_From_Input_Format(
			string inputFormat,
			Position upRightCoordinateOfPlateau,
			RoverPosition firstRoverPosition,
			RoverControlSignal[] firstRoverControlSignal)
		{
			var input = RoverMovementCalculatorInput.CreateFromInputFormat(inputFormat);
			input.UpRightCoordinateOfPlateau.X.ShouldBe(upRightCoordinateOfPlateau.X);
			input.UpRightCoordinateOfPlateau.Y.ShouldBe(upRightCoordinateOfPlateau.Y);
			
			var positionAndSignal = input.RoverPositionAndControlSignals.First();
			positionAndSignal.RoverPosition.Heading.ShouldBe(firstRoverPosition.Heading);
			positionAndSignal.RoverPosition.X.ShouldBe(firstRoverPosition.X);
			positionAndSignal.RoverPosition.Y.ShouldBe(firstRoverPosition.Y);

			positionAndSignal.RoverControlSignals.ShouldBe(firstRoverControlSignal);
		}

		public static IEnumerable<object[]> GetRoverMovementCalculatorInput()
		{
			var inputFormat =
@"5 5
1 2 N
LML";
			var upRightCoordinateOfPlateau = new Position(5, 5);
			var firstRoverPositon = new RoverPosition(1, 2, CardinalCompassPoint.North);
			var firstRoverControlSignals = new[]
				{RoverControlSignal.Left, RoverControlSignal.Move, RoverControlSignal.Left};
			yield return new object[]
			{
				inputFormat,
				upRightCoordinateOfPlateau,
				firstRoverPositon,
				firstRoverControlSignals
			};
		}
	}
}

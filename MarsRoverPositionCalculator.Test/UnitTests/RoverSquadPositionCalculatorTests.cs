using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace MarsRoverPositionCalculator.Test.UnitTests
{
	public class RoverSquadPositionCalculatorTests
	{
		[Theory]
		[MemberData(nameof(GetRoverSquadPositionCalculatorInput))]
		public void RoverSquadPositionCalculatorOutput_Should_Be_calculated_From_Input(string input,
			string expectedOutput)
		{
			var calculator = new RoverSquadPositionCalculator();
			var actualOutput = calculator.CalculateLastPositions(input);
			actualOutput.ShouldBe(expectedOutput);
		}

		public static IEnumerable<object[]> GetRoverSquadPositionCalculatorInput()
		{
			var input =
				@"5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
";
			var output =
				@"1 3 N
5 1 E";
			yield return new object[]
			{
				input,
				output
			};
		}
	}
}
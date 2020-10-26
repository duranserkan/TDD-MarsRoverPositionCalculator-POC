using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace MarsRoverPositionCalculator.Test.UnitTests
{
	public class RoverSquadPositionCalculatorTests
	{

		[Theory]
		[MemberData(nameof(GetRoverMovementCalculatorInput))]
		public void RoverMovementCalculatorInput_Should_Be_Created_From_Input_Format(string input, string expectedOutput)
		{
			var calculator = new RoverSquadPositionCalculator();
			var actualOutput = calculator.CalulateLastPositions(input);
			actualOutput.ShouldBe(expectedOutput);
		}

		public static IEnumerable<object[]> GetRoverMovementCalculatorInput()
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

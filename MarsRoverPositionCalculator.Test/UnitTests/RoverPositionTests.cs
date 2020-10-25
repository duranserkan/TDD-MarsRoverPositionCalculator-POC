using MarsRoverPositionCalculator.Models;
using Shouldly;
using Xunit;

namespace MarsRoverPositionCalculator.Test.UnitTests
{
	public class RoverPositionTests
	{
		/// <summary>
		///     Position format is "{x} {y} {h}" where x and y are coordinate values and L is compass point representing letter
		///     x and y co-ordinate values are integer
		///     Cardinal compass point representing letter are N for North, E for East, S for South and W for west
		/// </summary>
		[Theory]
		[InlineData("2 3 N", 2, 3, CardinalCompassPoint.North)]
		public void RoverPosition_Should_Be_Created_From_Position_Format(string positionFormat, int x, int y,
			CardinalCompassPoint heading)
		{
			var roverPosition = RoverPosition.CreateFromPositionFormat(positionFormat);

			roverPosition.X.ShouldBe(x);
			roverPosition.Y.ShouldBe(y);
			roverPosition.Heading.ShouldBe(heading);
		}
	}
}
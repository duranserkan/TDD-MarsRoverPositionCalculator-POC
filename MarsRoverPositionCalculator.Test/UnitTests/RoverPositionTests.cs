using MarsRoverPositionCalculator.Models;
using Shouldly;
using Xunit;

namespace MarsRoverPositionCalculator.Test.UnitTests
{
	public class RoverPositionTests
	{
		/// <summary>
		///A rover's position is made from location and heading.
		///It is represented by a combination of x and y co-ordinates and a letter which describes one of the four cardinal compass points.
		///1. x and y co-ordinate values are integer
		///2. Cardinal compass point representing letter are N for North, E for East, S for South and W for west
		///3. Position format is "{x} {y} {L}" where x and y are coordinate values and L is compass point representing letter
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
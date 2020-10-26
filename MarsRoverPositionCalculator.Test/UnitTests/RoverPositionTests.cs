using System.Collections.Generic;
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

		/// <summary>
		///A rover's movement is controlled by control signal which is represented by a letter
		///1. Control signal L is send for 90 degrees rover spin to left without moving from its current spot
		///2. Control signal R is send for 90 degrees rover spin to right without moving from its current spot
		///3. Control signal M is send for move rover forward one grid point, and maintain the same heading
		/// </summary>
		[Theory]
		[MemberData(nameof(GetRoverPositionControlSignalAndExpectedPosition))]
		public void RoverPosition_Should_Be_Changed_By_Control_Signal(RoverPosition position, RoverControlSignal controlSignal, RoverPosition expectedPosition)
		{
			var newPosition = position.CalculateNewPosition(controlSignal);

			newPosition.X.ShouldBe(expectedPosition.X);
			newPosition.Y.ShouldBe(expectedPosition.Y);
			newPosition.Heading.ShouldBe(expectedPosition.Heading);
		}

		/// <summary>
		///A rover's movement is controlled by control signal which is represented by a letter
		///1. Control signal L is send for 90 degrees rover spin to left without moving from its current spot
		///2. Control signal R is send for 90 degrees rover spin to right without moving from its current spot
		///3. Control signal M is send for move rover forward one grid point, and maintain the same heading
		/// </summary>
		[Theory]
		[MemberData(nameof(GetRoverPositionControlSignalsAndExpectedPosition))]
		public void LastRoverPosition_Should_Be_Calculated(RoverPosition position, RoverControlSignal[] controlSignals, RoverPosition expectedPosition)
		{
			var newPosition = position.CalculateLastPosition(controlSignals);

			newPosition.X.ShouldBe(expectedPosition.X);
			newPosition.Y.ShouldBe(expectedPosition.Y);
			newPosition.Heading.ShouldBe(expectedPosition.Heading);
		}

		public static IEnumerable<object[]> GetRoverPositionControlSignalAndExpectedPosition()
		{
			//north
			yield return new object[]
			{
				new RoverPosition(1,1,CardinalCompassPoint.North),
				RoverControlSignal.Left,
				new RoverPosition(1, 1, CardinalCompassPoint.West)
			};

			yield return new object[]
			{
				new RoverPosition(1,1,CardinalCompassPoint.North),
				RoverControlSignal.Right,
				new RoverPosition(1, 1, CardinalCompassPoint.East)
			};

			yield return new object[]
			{
				new RoverPosition(1,1,CardinalCompassPoint.North),
				RoverControlSignal.Move,
				new RoverPosition(1, 2, CardinalCompassPoint.North)
			};

			//east
			yield return new object[]
			{
				new RoverPosition(1,1,CardinalCompassPoint.East),
				RoverControlSignal.Left,
				new RoverPosition(1, 1, CardinalCompassPoint.North)
			};

			yield return new object[]
			{
				new RoverPosition(1,1,CardinalCompassPoint.East),
				RoverControlSignal.Right,
				new RoverPosition(1, 1, CardinalCompassPoint.South)
			};

			yield return new object[]
			{
				new RoverPosition(1,1,CardinalCompassPoint.East),
				RoverControlSignal.Move,
				new RoverPosition(2, 1, CardinalCompassPoint.East)
			};

			//south
			yield return new object[]
			{
				new RoverPosition(1,1,CardinalCompassPoint.South),
				RoverControlSignal.Left,
				new RoverPosition(1, 1, CardinalCompassPoint.East)
			};

			yield return new object[]
			{
				new RoverPosition(1,1,CardinalCompassPoint.South),
				RoverControlSignal.Right,
				new RoverPosition(1, 1, CardinalCompassPoint.West)
			};

			yield return new object[]
			{
				new RoverPosition(1,1,CardinalCompassPoint.South),
				RoverControlSignal.Move,
				new RoverPosition(1, 0, CardinalCompassPoint.South)
			};

			//west
			yield return new object[]
			{
				new RoverPosition(1,1,CardinalCompassPoint.West),
				RoverControlSignal.Left,
				new RoverPosition(1, 1, CardinalCompassPoint.South)
			};

			yield return new object[]
			{
				new RoverPosition(1,1,CardinalCompassPoint.West),
				RoverControlSignal.Right,
				new RoverPosition(1, 1, CardinalCompassPoint.North)
			};

			yield return new object[]
			{
				new RoverPosition(1,1,CardinalCompassPoint.West),
				RoverControlSignal.Move,
				new RoverPosition(0, 1, CardinalCompassPoint.West)
			};
		}

		public static IEnumerable<object[]> GetRoverPositionControlSignalsAndExpectedPosition()
		{
			yield return new object[]
			{
				new RoverPosition(1, 2, CardinalCompassPoint.North),
				new []
				{
					RoverControlSignal.Left,
					RoverControlSignal.Move,
					RoverControlSignal.Left,
					RoverControlSignal.Move,
					RoverControlSignal.Left,
					RoverControlSignal.Move,
					RoverControlSignal.Left,
					RoverControlSignal.Move,
					RoverControlSignal.Move
				},
				new RoverPosition(1, 3, CardinalCompassPoint.North)
			};

			yield return new object[]
			{
				new RoverPosition(3, 3, CardinalCompassPoint.East),
				new []
				{
					RoverControlSignal.Move,
					RoverControlSignal.Move,
					RoverControlSignal.Right,
					RoverControlSignal.Move,
					RoverControlSignal.Move,
					RoverControlSignal.Right,
					RoverControlSignal.Move,
					RoverControlSignal.Right,
					RoverControlSignal.Right,
					RoverControlSignal.Move
				},
				new RoverPosition(5, 1, CardinalCompassPoint.East)
			};
		}
	}
}
using System;
using System.Collections.Generic;

namespace MarsRoverPositionCalculator.Models
{
	public class RoverPosition
	{
		public RoverPosition(int x, int y, CardinalCompassPoint heading)
		{
			X = x;
			Y = y;
			Heading = heading;
		}

		public int X { get; }
		public int Y { get; }
		public CardinalCompassPoint Heading { get; }

		public static RoverPosition CreateFromPositionFormat(string format)
		{
			var paramsAsString = format.Split(' ');
			if (paramsAsString.Length != 3) throw new ArgumentException($"Invalid position: {format}");

			if (!int.TryParse(paramsAsString[0], out var x)) throw new ArgumentException($"Invalid position: {format}");
			if (!int.TryParse(paramsAsString[1], out var y)) throw new ArgumentException($"Invalid position: {format}");
			if (string.IsNullOrEmpty(paramsAsString[2])) throw new ArgumentException($"Invalid position: {format}");

			var heading = paramsAsString[2].CardinalCompassPointFromShortCode();

			var roverPositon = new RoverPosition(x, y, heading);

			return roverPositon;
		}

		public RoverPosition CalculateNewPosition(RoverControlSignal controlSignal)
		{
			return controlSignal switch
			{
				RoverControlSignal.Left => Heading switch
				{
					CardinalCompassPoint.North => new RoverPosition(X, Y, CardinalCompassPoint.West),
					CardinalCompassPoint.East => new RoverPosition(X, Y, CardinalCompassPoint.North),
					CardinalCompassPoint.South => new RoverPosition(X, Y, CardinalCompassPoint.East),
					CardinalCompassPoint.West => new RoverPosition(X, Y, CardinalCompassPoint.South),
					_ => throw new ArgumentOutOfRangeException()
				},
				RoverControlSignal.Right => Heading switch
				{
					CardinalCompassPoint.North => new RoverPosition(X, Y, CardinalCompassPoint.East),
					CardinalCompassPoint.East => new RoverPosition(X, Y, CardinalCompassPoint.South),
					CardinalCompassPoint.South => new RoverPosition(X, Y, CardinalCompassPoint.West),
					CardinalCompassPoint.West => new RoverPosition(X, Y, CardinalCompassPoint.North),
					_ => throw new ArgumentOutOfRangeException()
				},
				RoverControlSignal.Move => Heading switch
				{
					CardinalCompassPoint.North => new RoverPosition(X, Y + 1, Heading),
					CardinalCompassPoint.East => new RoverPosition(X + 1, Y, Heading),
					CardinalCompassPoint.South => new RoverPosition(X, Y - 1, Heading),
					CardinalCompassPoint.West => new RoverPosition(X - 1, Y, Heading),
					_ => throw new ArgumentOutOfRangeException()
				},
				_ => throw new ArgumentOutOfRangeException(nameof(controlSignal), controlSignal, null)
			};
		}

		public RoverPosition CalculateLastPosition(IReadOnlyList<RoverControlSignal> controlSignals)
		{
			var lastPosition = this;
			foreach (var roverControlSignal in controlSignals)
				lastPosition = lastPosition.CalculateNewPosition(roverControlSignal);

			return lastPosition;
		}
	}
}
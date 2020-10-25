using System;

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

			var heading = paramsAsString[2].FromShortCode();

			var roverPositon = new RoverPosition(x, y, heading);

			return roverPositon;
		}
	}
}
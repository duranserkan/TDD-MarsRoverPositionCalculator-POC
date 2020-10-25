using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverPositionCalculator.Models
{
	public class Position
	{
		public Position(int x, int y)
		{
			X = x;
			Y = y;
		}
		public int X { get;}
		public int Y { get;}

		public static Position CreateFromPositionFormat(string format)
		{
			var paramsAsString = format.Split(' ');
			if (paramsAsString.Length != 2 ) throw new ArgumentException($"Invalid position: {format}");

			if (!int.TryParse(paramsAsString[0], out var x)) throw new ArgumentException($"Invalid position: {format}");
			if (!int.TryParse(paramsAsString[1], out var y)) throw new ArgumentException($"Invalid position: {format}");
			
			var position = new Position(x, y);

			return position;
		}
	}
}

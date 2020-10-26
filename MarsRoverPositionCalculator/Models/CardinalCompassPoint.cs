using System;

namespace MarsRoverPositionCalculator.Models
{
	public enum CardinalCompassPoint
	{
		North = 1,
		East = 2,
		South = 3,
		West = 4
	}

	public static class CardinalCompassPointExtensions
	{
		public static CardinalCompassPoint CardinalCompassPointFromShortCode(this string shortCode)
		{
			return shortCode.ToUpper() switch
			{
				"N" => CardinalCompassPoint.North,
				"E" => CardinalCompassPoint.East,
				"S" => CardinalCompassPoint.South,
				"W" => CardinalCompassPoint.West,
				_ => throw new ArgumentException($"shortCode is not valid: {shortCode}")
			};
		}

		public static string ToShortCode(this CardinalCompassPoint compassPoint)
		{
			return compassPoint switch
			{
				CardinalCompassPoint.North => "N",
				CardinalCompassPoint.East => "E",
				CardinalCompassPoint.South => "S",
				CardinalCompassPoint.West => "W",
				_ => throw new ArgumentException($"compassPoint is not valid: {compassPoint}")
			};
		}
	}
}
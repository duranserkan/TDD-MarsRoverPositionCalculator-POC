using System;

namespace MarsRoverPositionCalculator.Models
{
	public enum RoverControlSignal
	{
		Left = 1,
		Right = 2,
		Move = 3
	}

	public static class RoverControlSignalExtensions
	{
		public static RoverControlSignal RoverControlSignalFromControlLetter(this char controlLetter)
		{
			return controlLetter switch
			{
				'L' => RoverControlSignal.Left,
				'R' => RoverControlSignal.Right,
				'M' => RoverControlSignal.Move,
				_ => throw new ArgumentException($"controlLetter is not valid: {controlLetter}")
			};
		}
	}
}
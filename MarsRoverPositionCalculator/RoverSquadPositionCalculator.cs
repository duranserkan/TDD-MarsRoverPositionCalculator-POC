using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRoverPositionCalculator.Models;

namespace MarsRoverPositionCalculator
{
	public class RoverSquadPositionCalculator
	{
		public string CalulateLastPositions(string inputAsString)
		{
			var input= RoverMovementCalculatorInput.CreateFromInputFormat(inputAsString);
			var output = input.RoverPositionAndControlSignals
				.Select(x => x.RoverPosition.CalculateLastPosition(x.RoverControlSignals))
				.Select(lastPosition => $"{lastPosition.X} {lastPosition.Y} {lastPosition.Heading.ToShortCode()}")
				.Aggregate((result, item) => $"{result}{Environment.NewLine}{item}");

			return output;
		}
	}
}

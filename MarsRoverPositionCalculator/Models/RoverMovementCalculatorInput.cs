using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverPositionCalculator.Models
{
	public class RoverMovementCalculatorInput
	{
		public RoverMovementCalculatorInput(Position upRightCoordinateOfPlateau,
			IReadOnlyList<RoverPositionAndControlSignals> roverPositionAndControlSignals)
		{
			UpRightCoordinateOfPlateau = upRightCoordinateOfPlateau;
			RoverPositionAndControlSignals = roverPositionAndControlSignals;
		}

		public Position UpRightCoordinateOfPlateau { get; }
		public IReadOnlyList<RoverPositionAndControlSignals> RoverPositionAndControlSignals { get; }

		public static RoverMovementCalculatorInput CreateFromInputFormat(string inputFormat)
		{
			var inputLines = inputFormat
				.Split(new[] {Environment.NewLine}, StringSplitOptions.None)
				.Select(i => i.Trim()).ToArray();
			var upRightCoordinateOfPlateau = Position.CreateFromPositionFormat(inputLines[0]);

			var inputLinesWithRoverNumber = inputLines.Skip(1)
				.Select((l, i) => new {Line = l, RoverNumber = (int) Math.Floor((double) i / 2)})
				.ToArray();
			var positions = inputLinesWithRoverNumber.Where((l, i) => i % 2 == 0).ToArray();
			var controlCommands = inputLinesWithRoverNumber.Where((l, i) => i % 2 == 1).ToArray();

			var roverPositionAndControlSignals = positions
				.Join(controlCommands,
					x => x.RoverNumber,
					y => y.RoverNumber,
					(position, commands) =>
					{
						var roverPosition = RoverPosition.CreateFromPositionFormat(position.Line);
						var roverControlSignals =
							commands.Line.Select(c => c.RoverControlSignalFromControlLetter()).ToArray();

						return new RoverPositionAndControlSignals(roverPosition, roverControlSignals);
					}).ToArray();

			return new RoverMovementCalculatorInput(upRightCoordinateOfPlateau, roverPositionAndControlSignals);
		}
	}

	public class RoverPositionAndControlSignals
	{
		public RoverPositionAndControlSignals(RoverPosition roverPosition,
			IReadOnlyList<RoverControlSignal> roverControlSignals)
		{
			RoverPosition = roverPosition;
			RoverControlSignals = roverControlSignals;
		}

		public RoverPosition RoverPosition { get; }
		public IReadOnlyList<RoverControlSignal> RoverControlSignals { get; }
	}
}
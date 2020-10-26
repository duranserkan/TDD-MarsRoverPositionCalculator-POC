using AutoFixture.Xunit2;
using Xunit;

namespace MarsRoverPositionCalculator.Test
{
	public class NSubstitudeInlineData : CompositeDataAttribute
	{
		public NSubstitudeInlineData(params object[] parameters) : base(
			new InlineDataAttribute(parameters, new NSubstitudeDataAttribute()))
		{
		}
	}
}
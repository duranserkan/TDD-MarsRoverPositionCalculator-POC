using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace MarsRoverPositionCalculator.Test
{
	public class NSubstitudeDataAttribute : AutoDataAttribute
	{
		public NSubstitudeDataAttribute() : base(() => new Fixture().Customize(new AutoNSubstituteCustomization()))
		{
		}
	}
}
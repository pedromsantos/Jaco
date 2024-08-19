using Jaco.Notes;

namespace Jaco.Time;

public class SimpleTimeSignature(int beats, Duration duration, int bpm = 60) : TimeSignature(beats, duration, bpm)
{
	public override double ToFillCycle(Duration durationToTry)
	{
		return (BeatDurationTicks / durationToTry.Tick) * Beats;
	}

	public override string ToString()
	{
		var foo = Duration.ToString().Length > 1
				? Duration.ToString().Substring(2)
				: Duration.ToString();

		return $"{Beats}/{foo}";
	}
}

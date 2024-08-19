using Jaco.Notes;

namespace Jaco.Time;

public class CompoundTimeSignature : TimeSignature
{
	public CompoundTimeSignature(int pulses, Duration duration, int bpm = 60)
		: base(pulses / 3, duration, bpm)
	{
		if (pulses % 3 != 0)
		{
			throw new ArgumentException("Compound signatures pulse must be divisible by 3");
		}
	}

	protected override double BeatValue
	{
		get { return Duration.Value * 3; }
	}

	public override double ToFillCycle(Duration durationToTry)
	{
		return (BeatDurationTicks / durationToTry.Tick) * Beats * 3;
	}

	public override double TicksPerCycle
	{
		get { return BeatDurationTicks * Beats * 3; }
	}

	public override string ToString()
	{
		var foo = Duration.ToString().Length > 1
				? Duration.ToString().Substring(2)
				: Duration.ToString();

		return $"{Beats * 3}/{foo}";
	}
}

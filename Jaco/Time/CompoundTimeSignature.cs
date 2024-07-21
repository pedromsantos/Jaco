namespace Jaco;

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

	protected override double beatValue
	{
		get { return duration.Value * 3; }
	}

	public override double ToFillCycle(Duration duration)
	{
		return (BeatDurationTicks / duration.Tick) * beats * 3;
	}

	public override double TicksPerCycle
	{
		get { return BeatDurationTicks * beats * 3; }
	}

	public override string ToString()
	{
		var foo = duration.ToString().Length > 1
				? duration.ToString().Substring(2)
				: duration.ToString();

		return $"{beats * 3}/{foo}";
	}
}

namespace Jaco;

public class SimpleTimeSignature : TimeSignature
{
	public SimpleTimeSignature(int beats, Duration duration, int bpm = 60)
		: base(beats, duration, bpm)
	{
	}

	public override double ToFillCycle(Duration duration)
	{
		return (BeatDurationTicks / duration.Tick) * beats;
	}

	public override string ToString()
	{
		var foo = duration.ToString().Length > 1
				? duration.ToString().Substring(2)
				: duration.ToString();

		return $"{beats}/{foo}";
	}
}

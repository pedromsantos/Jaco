using Jaco.Notes;

namespace Jaco.Time;

public class BeatsPerMinute(int bpm, Duration duration)
{
	private readonly double miliSecondsMultiplier = 60 * 1000;
	private readonly int secondsMultiplier = 60;

	public int Bpm { get; } = bpm;

	public int Minutes(int beats = 1)
	{
		return beats / Bpm;
	}

	public double Seconds(int beats = 1)
	{
		return (beats / (double)Bpm) * secondsMultiplier;
	}

	public double MilliSeconds(int beats = 1)
	{
		return (beats / (double)Bpm) * miliSecondsMultiplier;
	}

	public double SecondsFor(Duration duration1)
	{
		var durationToBeats = duration1.Value / duration.Value;
		return (durationToBeats / Bpm) * secondsMultiplier;
	}

	public double MilliSecondsFor(Duration duration1)
	{
		var durationToBeats = duration1.Value / duration.Value;
		return (durationToBeats / Bpm) * miliSecondsMultiplier;
	}
}
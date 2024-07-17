namespace Jaco;

public class BeatsPerMinute
{
	private readonly double miliSecondsMultiplier = 60 * 1000;
	private readonly int secondsMultiplier = 60;
	private readonly int bpm;
	private readonly Duration duration;

	public BeatsPerMinute(int bpm)
	{
		this.bpm = bpm;
		this.duration = Duration.Quarter;
	}

	public BeatsPerMinute(int bpm, Duration duration)
	{
		this.bpm = bpm;
		this.duration = duration;
	}

	public int BPM
	{
		get { return bpm; }
	}

	public int Minutes(int beats = 1)
	{
		return beats / bpm;
	}

	public double Seconds(int beats = 1)
	{
		return ((double)beats / (double)bpm) * (double)secondsMultiplier;
	}

	public double MilliSeconds(int beats = 1)
	{
		return ((double)beats / (double)bpm) * (double)miliSecondsMultiplier;
	}

	public double SecondsFor(Duration duration)
	{
		double durationToBeats = duration.Value / this.duration.Value;
		return (durationToBeats / bpm) * secondsMultiplier;
	}

	public double MilliSecondsFor(Duration duration)
	{
		double durationToBeats = duration.Value / this.duration.Value;
		return (durationToBeats / bpm) * miliSecondsMultiplier;
	}
}
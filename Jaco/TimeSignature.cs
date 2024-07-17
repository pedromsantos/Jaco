namespace Jaco;

public abstract class TimeSignature
{
	private readonly BeatsPerMinute bpm;

	protected TimeSignature(int beats, Duration duration, int bpm)
	{
		this.beats = beats;
		this.duration = duration;
		this.bpm = new BeatsPerMinute(bpm, duration);
	}

	protected int beats;
	protected Duration duration;

	protected virtual double beatValue
	{
		get { return duration.Value; }
	}

	public double beatDuration
	{
		get { return beatValue; }
	}

	public double BeatDurationMilliseconds
	{
		get { return bpm.MilliSeconds(); }
	}

	public double BeatDurationTicks
	{
		get { return duration.Tick; }
	}

	public double MillisecondsPerMeasure
	{
		get { return BeatDurationMilliseconds * beats; }
	}

	public virtual double TicksPerMeasure
	{
		get { return BeatDurationTicks * beats; }
	}

	public int TicksPerSecond
	{
		get { return (bpm.BPM * Duration.TickPerQuarterNote) / 60; }
	}

	public abstract double ToFillMeasure(Duration duration);

	public double MillisecondsFor(Duration duration)
	{
		return bpm.MilliSecondsFor(duration);
	}
}

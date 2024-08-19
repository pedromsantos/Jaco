using Jaco.Notes;

namespace Jaco.Time;

public abstract class TimeSignature(int beats, Duration duration, int bpm)
{
	private readonly BeatsPerMinute bpm = new BeatsPerMinute(bpm, duration);

	protected readonly int Beats = beats;
	protected readonly Duration Duration = duration;

	protected virtual double BeatValue => Duration.Value;

	public double BeatDuration => BeatValue;

	public double BeatDurationMilliseconds => bpm.MilliSeconds();

	public double BeatDurationTicks => Duration.Tick;

	public double MillisecondsPerCycle => BeatDurationMilliseconds * Beats;

	public virtual double TicksPerCycle => BeatDurationTicks * Beats;

	public int TicksPerSecond => (bpm.Bpm * Duration.TickPerQuarterNote) / 60;

	public abstract double ToFillCycle(Duration durationToTry);

	public double MillisecondsFor(Duration duration)
	{
		return bpm.MilliSecondsFor(duration);
	}
}

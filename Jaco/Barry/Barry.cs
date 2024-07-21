
namespace Jaco;

public abstract class BarryScale : IScale
{
	protected readonly IScale scale;

	protected BarryScale(ScalePattern scalePattern, Pitch root, Duration duration, Octave octave)
	{
		scale = new Scale(scalePattern, root, duration, octave);
	}

	public ScalePattern ScalePattern => scale.ScalePattern;

	public Pitch Root => scale.Root;

	public IEnumerator<Pitch> GetEnumerator()
	{
		throw new NotImplementedException();
	}

	public MelodicLine ScaleUpMelodicLine()
	{
		return scale.ScaleUpMelodicLine();
	}

	public MelodicLine ScaleDownMelodicLine()
	{
		return scale.ScaleDownMelodicLine();

	}

	public abstract MelodicLine ScaleDownMinHalfSteps();

	public abstract MelodicLine ScaleDownMaxHalfSteps();

	public MelodicLine MelodicThirdsFrom(ScaleDegree degree)
	{
		return scale.MelodicThirdsFrom(degree);
	}

	public MelodicLine MelodicThirdsTo(ScaleDegree degree)
	{
		return scale.MelodicThirdsTo(degree);
	}

	public IEnumerable<Pitch> ThirdsFrom(ScaleDegree degree)
	{
		return scale.ThirdsFrom(degree);
	}
}

public class BarryMixolydianScale : BarryScale
{
	public BarryMixolydianScale(Pitch root, Duration duration, Octave octave)
		: base(ScalePattern.Mixolydian, root, duration, octave)
	{
	}

	public override MelodicLine ScaleDownMaxHalfSteps()
	{
		return scale.ScaleDownMelodicLine();
	}

	public override MelodicLine ScaleDownMinHalfSteps()
	{
		return scale.ScaleDownMelodicLine();
	}
}
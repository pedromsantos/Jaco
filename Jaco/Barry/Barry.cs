// namespace Jaco;

// public class BarryHalfStepRule
// {
// 	private readonly ScaleDegree startDegree;
// 	private readonly ScaleDegree endDegree;

// 	private BarryHalfStepRule(ScaleDegree startDegree, ScaleDegree endDegree)
// 	{
// 		this.startDegree = startDegree;
// 		this.endDegree = endDegree;
// 	}

// 	public static readonly BarryHalfStepRule RootAndSeventh = new BarryHalfStepRule(ScaleDegree.I, ScaleDegree.VII);
// 	public static readonly BarryHalfStepRule SecondAndRoot = new BarryHalfStepRule(ScaleDegree.II, ScaleDegree.I);
// 	public static readonly BarryHalfStepRule ThirdAndSecond = new BarryHalfStepRule(ScaleDegree.III, ScaleDegree.II);
// 	public static readonly BarryHalfStepRule SixthAndFifth = new BarryHalfStepRule(ScaleDegree.VI, ScaleDegree.V);

// 	public void Apply(PitchLine line, Scale scale)
// 	{
// 		line.InsertHalfToneBetween(scale.PitchFor(this.startDegree), scale.PitchFor(this.endDegree));
// 	}
// }

// public class BarryHalfStepRules
// {
// 	private static readonly List<BarryHalfStepRules> all = new List<BarryHalfStepRules>();

// 	private readonly List<BarryHalfStepRule> rootChordTonesMin;
// 	private readonly List<BarryHalfStepRule> noRootChordTonesMin;
// 	private readonly List<BarryHalfStepRule> rootChordTonesMax;
// 	private readonly List<BarryHalfStepRule> noRootChordTonesMax;
// 	private readonly Func<Scale, bool> appliesTo;

// 	private BarryHalfStepRules(
// 		List<BarryHalfStepRule> rootChordTonesMin,
// 		List<BarryHalfStepRule> noRootChordTonesMin,
// 		List<BarryHalfStepRule> rootChordTonesMax,
// 		List<BarryHalfStepRule> noRootChordTonesMax,
// 		Func<Scale, bool> appliesTo)
// 	{
// 		this.rootChordTonesMin = rootChordTonesMin;
// 		this.noRootChordTonesMin = noRootChordTonesMin;
// 		this.rootChordTonesMax = rootChordTonesMax;
// 		this.noRootChordTonesMax = noRootChordTonesMax;
// 		this.appliesTo = appliesTo;

// 		BarryHalfStepRules.all.Add(this);
// 	}

// 	public static readonly BarryHalfStepRules Dominant = new BarryHalfStepRules(
// 		new List<BarryHalfStepRule> { BarryHalfStepRule.RootAndSeventh },
// 		new List<BarryHalfStepRule>(),
// 		new List<BarryHalfStepRule>
// 		{
// 			BarryHalfStepRule.RootAndSeventh,
// 			BarryHalfStepRule.SecondAndRoot,
// 			BarryHalfStepRule.ThirdAndSecond
// 		},
// 		new List<BarryHalfStepRule> { BarryHalfStepRule.RootAndSeventh, BarryHalfStepRule.SecondAndRoot },
// 		scale => scale.HasPattern(ScalePattern.Mixolydian)
// 	);

// 	public static readonly BarryHalfStepRules Major = new BarryHalfStepRules(
// 		new List<BarryHalfStepRule> { BarryHalfStepRule.SixthAndFifth },
// 		new List<BarryHalfStepRule>(),
// 		new List<BarryHalfStepRule>
// 		{
// 			BarryHalfStepRule.SecondAndRoot,
// 			BarryHalfStepRule.ThirdAndSecond,
// 			BarryHalfStepRule.SixthAndFifth
// 		},
// 		new List<BarryHalfStepRule> { BarryHalfStepRule.RootAndSeventh, BarryHalfStepRule.SixthAndFifth },
// 		scale => scale.HasPattern(ScalePattern.Ionian)
// 	);

// 	public static readonly BarryHalfStepRules Minor = new BarryHalfStepRules(
// 		new List<BarryHalfStepRule> { BarryHalfStepRule.SixthAndFifth },
// 		new List<BarryHalfStepRule>(),
// 		new List<BarryHalfStepRule>
// 		{
// 			BarryHalfStepRule.SecondAndRoot,
// 			BarryHalfStepRule.ThirdAndSecond,
// 			BarryHalfStepRule.SixthAndFifth
// 		},
// 		new List<BarryHalfStepRule> { BarryHalfStepRule.RootAndSeventh, BarryHalfStepRule.SixthAndFifth },
// 		scale => scale.HasPattern(ScalePattern.HarmonicMinor)
// 	);

// 	public static readonly BarryHalfStepRules Default = new BarryHalfStepRules(
// 		new List<BarryHalfStepRule>(),
// 		new List<BarryHalfStepRule>(),
// 		new List<BarryHalfStepRule>(),
// 		new List<BarryHalfStepRule>(),
// 		() => false
// 	);

// 	public static BarryHalfStepRules BarryRulesFor(Scale scale)
// 	{
// 		return BarryHalfStepRules.all.Find(rule => rule.appliesTo(scale)) ?? BarryHalfStepRules.Default;
// 	}

// 	public PitchLine ApplyMin(Scale scale, ScaleDegree from, ScaleDegree to)
// 	{
// 		var line = scale.Down(from, to);

// 		if (LineStartsAtRootChordTone(from))
// 		{
// 			foreach (var rule in rootChordTonesMin)
// 			{
// 				rule.Apply(line, scale);
// 			}

// 			return line;
// 		}

// 		foreach (var rule in noRootChordTonesMin)
// 		{
// 			rule.Apply(line, scale);
// 		}

// 		return line;
// 	}

// 	public PitchLine ApplyMax(Scale scale, ScaleDegree from, ScaleDegree to)
// 	{
// 		var line = scale.Down(from, to);

// 		if (LineStartsAtRootChordTone(from))
// 		{
// 			foreach (var rule in rootChordTonesMax)
// 			{
// 				rule.Apply(line, scale);
// 			}

// 			return line;
// 		}

// 		foreach (var rule in noRootChordTonesMax)
// 		{
// 			rule.Apply(line, scale);
// 		}

// 		return line;
// 	}

// 	private bool LineStartsAtRootChordTone(ScaleDegree degree)
// 	{
// 		return degree == ScaleDegree.I ||
// 				 degree == ScaleDegree.III ||
// 				 degree == ScaleDegree.V ||
// 				 degree == ScaleDegree.VII;
// 	}
// }
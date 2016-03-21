using System;

namespace Jaco.Infrastructure
{
    public static class IntExtensions
    {
        public static int Clamp(this int value, int min, int max)
        {
            return Math.Min(max, Math.Max(value, min));
        }
    }
}

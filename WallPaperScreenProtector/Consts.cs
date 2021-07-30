using System;
using System.Collections.Generic;
using System.Linq;

namespace WallPaperScreenProtector
{
    public static class Consts
    {
        private static Random _random = new Random();
        public static readonly int MillisecondsPerFrame = 120;
        public static readonly int TimePerScene = 8000;
        public static readonly int QuarterTimePerScene = TimePerScene / 4;

        public static List<string> AvailableWallpapers = new List<string>
        {
            "wp1",
            "wp2",
            "wp3",
        };

        public static string GetRandomWallpaper()
            => AvailableWallpapers.Skip(_random.Next(AvailableWallpapers.Count)).Take(1).First();
    }
}

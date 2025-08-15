using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystem.Utilidades
{
    public static class AppColors
    {
        // Primary Colors
        public static readonly Color Primary = Color.FromArgb(222, 184, 247);
        public static readonly Color SurfaceTint = Color.FromArgb(222, 184, 247);
        public static readonly Color OnPrimary = Color.FromArgb(64, 35, 87);
        public static readonly Color PrimaryContainer = Color.FromArgb(88, 58, 111);
        public static readonly Color OnPrimaryContainer = Color.FromArgb(242, 218, 255);

        // Secondary Colors
        public static readonly Color Secondary = Color.FromArgb(210, 193, 217);
        public static readonly Color OnSecondary = Color.FromArgb(55, 44, 63);
        public static readonly Color SecondaryContainer = Color.FromArgb(78, 66, 86);
        public static readonly Color OnSecondaryContainer = Color.FromArgb(238, 221, 245);

        // Tertiary Colors
        public static readonly Color Tertiary = Color.FromArgb(244, 183, 187);
        public static readonly Color OnTertiary = Color.FromArgb(76, 37, 40);
        public static readonly Color TertiaryContainer = Color.FromArgb(102, 59, 62);
        public static readonly Color OnTertiaryContainer = Color.FromArgb(255, 218, 219);

        // Error Colors
        public static readonly Color Error = Color.FromArgb(255, 180, 171);
        public static readonly Color OnError = Color.FromArgb(105, 0, 5);
        public static readonly Color ErrorContainer = Color.FromArgb(147, 0, 10);
        public static readonly Color OnErrorContainer = Color.FromArgb(255, 218, 214);

        // Background & Surface Colors
        public static readonly Color Background = Color.FromArgb(22, 18, 23);
        public static readonly Color OnBackground = Color.FromArgb(232, 224, 232);
        public static readonly Color Surface = Color.FromArgb(22, 18, 23);
        public static readonly Color OnSurface = Color.FromArgb(232, 224, 232);
        public static readonly Color SurfaceVariant = Color.FromArgb(75, 69, 77);
        public static readonly Color OnSurfaceVariant = Color.FromArgb(205, 195, 206);

        // Outline & Shadow
        public static readonly Color Outline = Color.FromArgb(150, 142, 152);
        public static readonly Color OutlineVariant = Color.FromArgb(75, 69, 77);
        public static readonly Color Shadow = Color.FromArgb(0, 0, 0);
        public static readonly Color Scrim = Color.FromArgb(0, 0, 0);

        // Inverse Colors
        public static readonly Color InverseSurface = Color.FromArgb(232, 224, 232);
        public static readonly Color InverseOnSurface = Color.FromArgb(51, 47, 53);
        public static readonly Color InversePrimary = Color.FromArgb(113, 81, 136);

        // Fixed Colors
        public static readonly Color PrimaryFixed = Color.FromArgb(242, 218, 255);
        public static readonly Color OnPrimaryFixed = Color.FromArgb(42, 12, 64);
        public static readonly Color PrimaryFixedDim = Color.FromArgb(222, 184, 247);
        public static readonly Color OnPrimaryFixedVariant = Color.FromArgb(88, 58, 111);

        public static readonly Color SecondaryFixed = Color.FromArgb(238, 221, 245);
        public static readonly Color OnSecondaryFixed = Color.FromArgb(34, 23, 41);
        public static readonly Color SecondaryFixedDim = Color.FromArgb(210, 193, 217);
        public static readonly Color OnSecondaryFixedVariant = Color.FromArgb(78, 66, 86);

        public static readonly Color TertiaryFixed = Color.FromArgb(255, 218, 219);
        public static readonly Color OnTertiaryFixed = Color.FromArgb(51, 16, 20);
        public static readonly Color TertiaryFixedDim = Color.FromArgb(244, 183, 187);
        public static readonly Color OnTertiaryFixedVariant = Color.FromArgb(102, 59, 62);

        // Surface Container Colors
        public static readonly Color SurfaceDim = Color.FromArgb(22, 18, 23);
        public static readonly Color SurfaceBright = Color.FromArgb(60, 56, 62);
        public static readonly Color SurfaceContainerLowest = Color.FromArgb(16, 13, 18);
        public static readonly Color SurfaceContainerLow = Color.FromArgb(30, 26, 32);
        public static readonly Color SurfaceContainer = Color.FromArgb(34, 30, 36);
        public static readonly Color SurfaceContainerHigh = Color.FromArgb(45, 41, 46);
        public static readonly Color SurfaceContainerHighest = Color.FromArgb(56, 51, 57);
    }
}

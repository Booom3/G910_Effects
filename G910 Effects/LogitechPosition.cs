using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedCSharp;
using static LedCSharp.LogitechGSDK;

namespace G910_Effects
{
    struct LogitechPosition
    {
        public static int bmp2d(int X, int Y)
        {
            return (X + (Y * LOGI_LED_BITMAP_WIDTH)) * LOGI_LED_BITMAP_BYTES_PER_KEY;
        }
        public int X;
        public int Y;
        public int pos1d;
        public static bool IsValid(LogitechPosition p)
        {
            return IsValid(p.X, p.Y);
        }
        public static bool IsValid(int X, int Y)
        {
            return X >= 0 && X < LOGI_LED_BITMAP_WIDTH
                && Y >= 0 && Y < LOGI_LED_BITMAP_HEIGHT;
        }
        public LogitechPosition(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            this.pos1d = bmp2d(X, Y);
        }
        public LogitechPosition(LogitechPosition basePos, int addX, int addY)
        {
            this.X = basePos.X + addX;
            this.Y = basePos.Y + addY;
            this.pos1d = bmp2d(this.X, this.Y);
        }
    }
}

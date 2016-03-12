using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedCSharp;
using static LedCSharp.LogitechGSDK;

namespace G910_Effects
{
    static class LogitechHelper
    {
        public static byte[] bitmap = new byte[LOGI_LED_BITMAP_SIZE];
        public static void SetColor(LogitechPosition p, byte R, byte G, byte B, byte A)
        {
            if (!LogitechPosition.IsValid(p))
                return;

            bitmap[p.pos1d] = B;
            bitmap[p.pos1d + 1] = G;
            bitmap[p.pos1d + 2] = R;
            bitmap[p.pos1d + 3] = A;
        }
        public static void UpdateKeyboard ()
        {
            LogiLedSetLightingFromBitmap(bitmap);
        }
        public static void SetColors(IEnumerable<LogitechPosition> p, byte R, byte G, byte B, byte A)
        {
            foreach (LogitechPosition s in p)
            {
                SetColor(s, R, G, B, A);
            }
        }
    }
}

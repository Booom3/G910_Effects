using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedCSharp;
using static LedCSharp.LogitechGSDK;
using System.Threading;
using System.Drawing;

namespace G910_Effects
{
    static class RadarEffect
    {
        private static LogitechPosition center = new LogitechPosition(8, 2);
        private static List<List<LogitechPosition>> positions = new List<List<LogitechPosition>>();
        private static float currentRotation = 0f;
        public static int width = 1;
        public static int trailLength = 800;
        private static int length = 21;
        public static void RunEffect()
        {
            positions.Clear();
            while (true)
            {
                if (positions.Count > trailLength)
                {
                    LogitechHelper.SetColors(positions[0], 0, 0, 0, 0);
                    positions.RemoveAt(0);
                }
                //for (int i = 0; i < positions.Count; i++)
                //{
                //    for (int j = 0; j < positions[i].Count; j++)
                //    {
                //        positions[i][j] = new LogitechPosition(positions[i][j], 0, 0);
                //    }
                //}
                List<LogitechPosition> newScanLine = new List<LogitechPosition>();
                double lastX = 0, lastY = 0;
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        double currentRotationRadians = currentRotation * (Math.PI / 180);
                        double xD = ((double)i * Math.Cos(currentRotationRadians)) -
                            (((double)j - ((double)width / 3d)) * Math.Sin(currentRotationRadians));
                        int x = (int)Math.Round(xD);
                        double yD = ((double)i * Math.Sin(currentRotationRadians)) +
                            (((double)j - ((double)width / 3d)) * Math.Cos(currentRotationRadians));
                        int y = (int)Math.Round(yD);
                        newScanLine.Add(new LogitechPosition(center, x, y));
                        lastX = xD;
                        lastY = yD;
                    }
                }
                positions.Add(newScanLine);
                for (int i = 0; i < positions.Count; i++)
                {
                    float colorF = (((float)trailLength - (float)positions.Count) + (i + 1f)) / trailLength;
                    byte color = (byte) (255 * colorF);
                    LogitechHelper.SetColors(positions[i], 0, color, 0, 255);
                }
                LogitechHelper.UpdateKeyboard();
                currentRotation += 0.3f;
                if (currentRotation > 360f)
                    currentRotation -= 360f;
                // Debug
                //if (Form1.ActiveForm != null)
                //{
                //    Graphics g = Form1.ActiveForm.CreateGraphics();
                //    //g.Clear(Color.White);
                //    float w = Form1.ActiveForm.Size.Width, h = Form1.ActiveForm.Size.Height;
                //    g.FillRectangle(Brushes.Green, ((float)lastX * 7f) + (w / 2f),
                //        ((float)lastY * 7f) + (h / 2f), 3, 3);
                //}
                Thread.Sleep(3);
            }
        }
    }
}

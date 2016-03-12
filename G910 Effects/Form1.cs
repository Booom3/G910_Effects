using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LedCSharp;
using static LedCSharp.LogitechGSDK;
using System.Threading;

namespace G910_Effects
{
    public partial class Form1 : Form
    {
        Thread currentEffect;
        public Form1()
        {
            LogiLedInit();
            InitializeComponent();
            currentEffect = new Thread(RadarEffect.RunEffect);
            currentEffect.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            currentEffect.Abort();
        }
    }
}

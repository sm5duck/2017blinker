﻿using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace BlinkBlink_EyeJoah.Chart._360
{
    public partial class Gauge360Example : Form
    {
        public static Gauge360Example gauge360example;

        public Gauge360Example()
        {
            gauge360example = this;

            InitializeComponent();

            //standard gauge
            //solidGauge5.From = 0;
            //solidGauge5.To = 100;
            //solidGauge5.Value = 50;

            //custom fill
            recomUsage.Uses360Mode = true;
            recomUsage.From = 0;
            recomUsage.To = 135;
            recomUsage.Value = 15;
            recomUsage.Base.Foreground = new SolidColorBrush(Colors.White); //폰트 색상
            recomUsage.GaugeBackground = new LinearGradientBrush
            {
                GradientStops = new GradientStopCollection
                {
                    new GradientStop(Color.FromRgb(163, 234, 228),0),
                    new GradientStop(Color.FromRgb(50, 208, 186),.5),
                    new GradientStop(Color.FromRgb(59, 188, 170),1)
                }
            };
            recomUsage.Base.GaugeActiveFill = new LinearGradientBrush
            {
                GradientStops = new GradientStopCollection
                {
                    new GradientStop(Colors.SkyBlue, 0),
                    new GradientStop(Colors.SteelBlue, .5),
                    new GradientStop(Colors.DarkBlue, 1)
                }
            };

            //Actual Usage
            solidGauge6.Uses360Mode = false;
            solidGauge6.From = 0;
            solidGauge6.To = 60;
            solidGauge6.Value = 86;
            solidGauge6.Base.LabelsVisibility = Visibility.Visible;
            solidGauge6.Base.GaugeActiveFill = new LinearGradientBrush
            {
                GradientStops = new GradientStopCollection
                {
                      new GradientStop(Colors.Yellow, 0),
                    new GradientStop(Colors.Orange, .5),
                    new GradientStop(Colors.Red, 1)
                }
            };

            //Break
            solidGauge7.Uses360Mode = false;
            solidGauge7.From = 0;
            solidGauge7.To = 60;
            solidGauge7.Value = 18;
            solidGauge7.Base.LabelsVisibility = Visibility.Visible;
            solidGauge7.Base.GaugeActiveFill = new LinearGradientBrush
            {
                GradientStops = new GradientStopCollection
                {
                      new GradientStop(Color.FromRgb(220,227,91), 0),
                      new GradientStop(Color.FromRgb(148,206,82),.5),
                    new GradientStop(Color.FromRgb(69,182,73), 1)
                    //new GradientStop(Colors.Olive, 1)
                }
            };

        }

        public void updateUsageValue(double usageTime)
        {
            usageLabel.Text = usageTime + " min";
            solidGauge6.Value = usageTime;
        }

        public void updateBreakValue(double breakTime)
        {
            breakLabel.Text = breakTime + " min";
            solidGauge7.Value = breakTime;
        }

    }
}

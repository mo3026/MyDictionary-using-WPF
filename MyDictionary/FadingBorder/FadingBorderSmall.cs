using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyDictionary
{
    public class FadingBorderSmall : ContentControl
    {
        public static readonly DependencyProperty FadingThicknessProperty = DependencyProperty.Register("FadingThickness", typeof(Double), typeof(FadingBorderSmall), new PropertyMetadata((Double)0, FadingThicknessValueChanged));
        public static readonly DependencyProperty InnerColorProperty = DependencyProperty.Register("InnerColor", typeof(Color), typeof(FadingBorderSmall), new PropertyMetadata(Colors.Black, ValueChanged));

        public Double FadingThickness
        {
            get { return (Double)GetValue(FadingThicknessProperty); }
            set
            {
                SetValue(FadingThicknessProperty, value);
            }
        }

        private static void FadingThicknessValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as FadingBorderSmall;
            double value = (Double)e.NewValue;
            double HValue = value / 2;
            double NHValue = -HValue;
            control.Resources["Value"] = (Double)value;
            GridLength g = new GridLength(value);
            control.Resources["LengthValue"] = g;
            control.Resources["Size"] = new Size(value, value);
            control.Resources["TopLeft"] = new Thickness(0, 0, NHValue, NHValue);
            control.Resources["TopRight"] = new Thickness(NHValue, 0, 0, NHValue);
            control.Resources["BottomLeft"] = new Thickness(0, NHValue, NHValue, 0);
            control.Resources["BottomRight"] = new Thickness(NHValue, NHValue, 0, 0);
            control.Resources["HorizantalMargin"] = new Thickness(HValue, 0, HValue, 0);
            control.Resources["VerticalMargin"] = new Thickness(0, HValue, 0, 1);
            control.Resources["VerticalMargin3"] = new Thickness(0, HValue, 0, 64);
            control.Resources["Down"] = new Point(0, value);
            control.Resources["Left"] = new Point(value, 0);
            control.Resources["CornerRadius"] = new CornerRadius(HValue, HValue, 0, 0);
        }

        public Color InnerColor
        {
            get { return (Color)GetValue(InnerColorProperty); }
            set
            {
                SetValue(InnerColorProperty, value);
            }
        }

        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as FadingBorderSmall;
            control.Resources["InnerColor"] = (Color)e.NewValue;
        }
    }
}

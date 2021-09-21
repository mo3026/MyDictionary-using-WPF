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
using System.ComponentModel;

namespace MyDictionary
{
    [DefaultEvent("Click")]
    public partial class MoButtonImage : UserControl
    {
        #region Constructor
        public MoButtonImage()
        {
            InitializeComponent();

            this.DataContext = this;
        }
        #endregion

        #region ImageUri Property
        public Uri ImageUri
        {
            get { return (Uri)GetValue(ImageUriProperty); }
            set { SetValue(ImageUriProperty, value); }
        }

        public static readonly DependencyProperty ImageUriProperty =
            DependencyProperty.Register("ImageUri", typeof(Uri), typeof(MoButtonImage), null);
        #endregion

        #region MouseLeftButtonDown Event
        private void borMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RaiseClick(e);
        }
        #endregion

        #region Click Event Procedure
        public delegate void ClickEventHandler(object sender, RoutedEventArgs e);
        public event ClickEventHandler Click;

        protected void RaiseClick(RoutedEventArgs e)
        {
            if (null != Click)
                Click(this, e);
        }
        #endregion

        #region Visual State Animations
        private void borMain_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToElementState(borMain, "MouseEnter", true);
        }

        private void borMain_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToElementState(borMain, "MouseLeave", true);
        }
        #endregion
    }
}

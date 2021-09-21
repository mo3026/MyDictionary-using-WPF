using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MyDictionary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DefinitionCollection dc;
        public static CategoriesCollection cc;

        /*protected override void OnStartup(StartupEventArgs e)
        {
            WpfSingleInstance.Make("MyWpfApplication", this);

            base.OnStartup(e);
        }*/

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            dc = Database.SQLCE.Query.RetrieveData();
            cc = Database.SQLCE.Query.RetrieveCats();

            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime;
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            MessageBox.Show(ex.Message, "Uncaught Thread Exception",
                            MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool DoHandle { get; set; }
        private void Application_DispatcherUnhandledException(object sender,
                               System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if (this.DoHandle)
            {
                //Handling the exception within the UnhandledException handler.
                MessageBox.Show(e.Exception.Message, "Exception Caught",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                e.Handled = true;
            }
            else
            {
                //If you do not set e.Handled to true, the application will close due to crash.
                //MessageBox.Show("Application is going to close! ", "Uncaught Exception");
                e.Handled = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
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
using System.Linq;
using System.Globalization;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Net.Http;

namespace MyDictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal delegate void ProcessArgDelegate(String arg);
        MemoryCleaner m;
        DefinitionCollection dc;
        CategoriesCollection cc;
        System.Threading.CancellationTokenSource tss = new System.Threading.CancellationTokenSource();
        System.Threading.CancellationToken ct;

        public MainWindow()
        {
            m = new MemoryCleaner();
            m.Start();

            InitializeComponent();

            this.AllowsTransparency = true;
            this.WindowStyle = System.Windows.WindowStyle.None;
            //grid1.Background = Brushes.White;
            //MainBorder.CornerRadius = new CornerRadius(0);

            dc = App.dc;
            cc = App.cc;

            if (!cc.Contains("Not Categorized")) cc.Add("Not Categorized");

            System.ComponentModel.ICollectionView o = CollectionViewSource.GetDefaultView(dc);
            Resources["Drink"] = o;
            Resources["Cats"] = cc;

            ComboBoxCats.SelectedValue = "Not Categorized";
            ButtonRemoveCats.IsEnabled = false;
            ComboBoxHardnesses.SelectedItem = Hardness.Indefinite;
            o.Filter = cs_Filter;
            this.Focus();
        }

        bool cs_Filter(object item)
        {
            System.Collections.Generic.KeyValuePair<string, Definition> src = (System.Collections.Generic.KeyValuePair<string, Definition>)item;
            string s = (string)ComboBoxCats.SelectedValue;
            bool b = true;
            if (s != "Not Categorized")
            {
                Definition d = (Definition)src.Value;
                if (d.Category != s) b = false;
            }

            if (b)
            {
                Hardness h = (Hardness)ComboBoxHardnesses.SelectedItem;
                if (h != Hardness.Indefinite)
                {
                    Definition d = (Definition)src.Value;
                    if (d.Hardness != h) b = false;
                }
            }

            return b;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string t = TextBoxWord.Text.Trim().ToLower();
            if (!dc.ContainsKey(t))
            {
                string s = (string)ComboBoxCats.SelectedValue;
                if (s == "" || s == null)
                {
                    ComboBoxCats.SelectedValue = "Not Categorized";
                    s = "Not Categorized";
                }
                Definition d = new Definition(t, s, (Hardness)ComboBoxHardnesses.SelectedItem, dc.ConnectionType);
                d.Meaning = TextBoxMeaning.Text;
                d.Example = TextBoxExample.Text;
                d.Synonym = TextBoxSynonym.Text;
                d.Antonym = TextBoxantonym.Text;
                dc.Add(d.Word, d, true);
                System.Collections.Generic.KeyValuePair<string, Definition> a = dc.First(q => q.Key == d.Word);
                ListBoxWords.SelectedItem = a;
                System.ComponentModel.ICollectionView cs = (System.ComponentModel.ICollectionView)Resources["Drink"];
                cs.Refresh();
                ListBoxWords.ScrollIntoView(a);
                ButtonAddMeaning.IsEnabled = false;
            }
        }

        private void ListBoxWords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxWords.SelectedItems.Count > 0)
            {
                KeyValuePair<string, Definition> x = (KeyValuePair<string, Definition>)ListBoxWords.SelectedItem;

                tss.Cancel();
                tss = new System.Threading.CancellationTokenSource();
                System.Threading.CancellationToken ct = tss.Token;
                System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    Definition d = x.Value;
                    if (!cc.Contains(d.Category)) cc.Add(d.Category);
                    Dispatcher.Invoke((Action)(() =>
                    {
                        this.DataContext = d;
                    }));
                }, ct, System.Threading.Tasks.TaskCreationOptions.LongRunning, PriorityScheduler.Highest);
            }
            else this.DataContext = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Definition dv = (Definition)this.DataContext;
            dv.Meaning = TextBoxMeaning.Text;
        }

        private void OnTargetUpdatedMeaning(Object sender, DataTransferEventArgs args)
        {
            ButtonMeaning.IsEnabled = false;
        }

        private void TextBoxMeaning_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.DataContext != null) ButtonMeaning.IsEnabled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Definition d = (Definition)this.DataContext;
            d.Example = TextBoxExample.Text;
        }

        private void OnTargetUpdatedExample(Object sender, DataTransferEventArgs args)
        {
            ButtonExample.IsEnabled = false;
        }

        private void TextBoxExample_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.DataContext != null) ButtonExample.IsEnabled = true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!cc.Contains(ComboBoxCats.Text))
            {
                cc.Add(ComboBoxCats.Text);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (cc.Contains(ComboBoxCats.Text) && ComboBoxCats.SelectedValue != "Not Categorized")
            {
                cc.Remove(ComboBoxCats.Text);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Definition d = (Definition)this.DataContext;
            d.Category = ComboBoxCat.Text;
        }

        private void OnTargetUpdatedCategory(Object sender, DataTransferEventArgs args)
        {
            ButtonCategory.IsEnabled = false;
        }

        private void ComboBoxCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.DataContext != null) ButtonCategory.IsEnabled = true;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".png";
                dlg.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|Bitmap Files (*.bmp)|*.bmp|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    Uri uri = new Uri(dlg.FileName, UriKind.Relative);
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(dlg.FileName));
                    bi.EndInit();
                    Definition d = (Definition)this.DataContext;
                    d.Images.Add(d.Word, bi);
                }
            }
            catch { }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Definition d = (Definition)this.DataContext;
            d.Images.Remove(d.Word, d.Images[ListViewImages.SelectedIndex]);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("Are you confident about removing the listbox's selected item?", "", MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
            {
                int i = ListBoxWords.SelectedIndex;
                Definition d = (Definition)this.DataContext;
                dc.Remove(d.Word);
                System.ComponentModel.ICollectionView cs = (System.ComponentModel.ICollectionView)Resources["Drink"];
                cs.Refresh();
                if (ListBoxWords.Items.Count > i) ListBoxWords.SelectedIndex = i;
                else ListBoxWords.SelectedIndex = ListBoxWords.Items.Count - 1;
            }
        }

        private void TextBoxWord_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s = TextBoxWord.Text;
            string t = s.Trim().ToLower();
            if (t != "")
            {
                if (!dc.ContainsKey(t))
                {
                    ButtonAddMeaning.IsEnabled = true;
                }
                else
                {
                    ButtonAddMeaning.IsEnabled = false;
                }
            }
            else
            {
                ButtonAddMeaning.IsEnabled = false;
            }
            System.Collections.Generic.KeyValuePair<string, Definition> a = dc.LastOrDefault(q => string.Compare(s, q.Key, true) >= 0);
            if (a.Key != null)
            {
                ListBoxWords.SelectedItem = a;
                ListBoxWords.ScrollIntoView(a);
            }
            else
            {
                this.DataContext = null;
            }
        }

        private void ComboBoxCats_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s = ComboBoxCats.Text;
            if (!cc.Contains(s))
            {
                ButtonAddCategory.IsEnabled = true;
                ButtonRemoveCats.IsEnabled = false;
            }
            else
            {

                ButtonAddCategory.IsEnabled = false;
                if (s == "Not Categorized") ButtonRemoveCats.IsEnabled = false;
                else ButtonRemoveCats.IsEnabled = true;
            }
        }

        private void OnTargetUpdatedImages(Object sender, DataTransferEventArgs args)
        {
            if (this.DataContext != null) ButtonAddImages.IsEnabled = true;
            else ButtonAddImages.IsEnabled = false;
        }

        private void Border_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                ((ToolTip)((Border)sender).ToolTip).Width = ((ToolTip)((Border)sender).ToolTip).Width * 1.20;
                ((ToolTip)((Border)sender).ToolTip).Height = ((ToolTip)((Border)sender).ToolTip).Height * 1.20;
            }
            else
            {
                ((ToolTip)((Border)sender).ToolTip).Width = ((ToolTip)((Border)sender).ToolTip).Width / 1.20;
                ((ToolTip)((Border)sender).ToolTip).Height = ((ToolTip)((Border)sender).ToolTip).Height / 1.20;
            }
        }

        private void ComboBoxCats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxCats.SelectedValue == "Not Categorized") ButtonRemoveCats.IsEnabled = false;
            System.ComponentModel.ICollectionView cs = (System.ComponentModel.ICollectionView)Resources["Drink"];
            cs.Refresh();
        }

        private void OnTargetUpdatedHardness(Object sender, DataTransferEventArgs args)
        {
            ButtonHardness.IsEnabled = false;
        }

        private void ComboBoxHardness_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.DataContext != null) ButtonHardness.IsEnabled = true;
        }

        private void ComboBoxHardnesses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.ComponentModel.ICollectionView cs = (System.ComponentModel.ICollectionView)Resources["Drink"];
            cs.Refresh();
        }

        private void ButtonHardness_Click(object sender, RoutedEventArgs e)
        {
            Definition d = (Definition)this.DataContext;
            d.Hardness = (Hardness)ComboBoxHardness.SelectedValue;
        }

        private void TextBoxSynonym_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            ButtonSynonym.IsEnabled = false;
        }

        private void TextBoxSynonym_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.DataContext != null) ButtonSynonym.IsEnabled = true;
        }

        private void ButtonSynonym_Click(object sender, RoutedEventArgs e)
        {
            Definition d = (Definition)this.DataContext;
            d.Synonym = TextBoxSynonym.Text;
        }

        private void TextBoxantonym_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            Buttonantonym.IsEnabled = false;
        }

        private void TextBoxantonym_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.DataContext != null) Buttonantonym.IsEnabled = true;
        }

        private void Buttonantonym_Click(object sender, RoutedEventArgs e)
        {
            Definition d = (Definition)this.DataContext;
            d.Antonym = TextBoxantonym.Text;
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBoxWord.Text = ((System.Collections.Generic.KeyValuePair<string, Definition>)(ListBoxWords.SelectedItem)).Key;
        }

        private void Item1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            bool wasCodeClosed = new System.Diagnostics.StackTrace().GetFrames().FirstOrDefault(x => x.GetMethod() == typeof(Window).GetMethod("Close")) != null;
            if (wasCodeClosed)
            {
                // Closed with this.Close()
            }
            else
            {
                Dispatcher.InvokeShutdown();
                // Closed some other way.
            }

            base.OnClosing(e);
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void topSizeGrip_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private async void Button_Click_10(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            HttpResponseMessage response = await client.GetAsync("https://api.dictionaryapi.dev/api/v2/entries/en/" + TextBoxWord.Text);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                JavaScriptSerializer js = new JavaScriptSerializer();
                dynamic a = js.Deserialize<dynamic>(responseBody);

                foreach (var keypairs in a[0]["meanings"])
                {
                    for (int k = 0; k < keypairs["definitions"].Length; k++)
                    {
                        TextBoxMeaning.Text+=keypairs["definitions"][k]["definition"] + "\n";
                        if (keypairs["definitions"][k].ContainsKey("example"))
                        {
                            TextBoxExample.Text+=keypairs["definitions"][k]["example"] + "\n";
                        }
                        if (keypairs["definitions"][k].ContainsKey("synonyms"))
                        {
                            for (int l = 0; l < keypairs["definitions"][k]["synonyms"].Length; l++)
                            {
                                if (TextBoxSynonym.Text.Length > 0) TextBoxSynonym.Text += ", ";
                                TextBoxSynonym.Text += keypairs["definitions"][k]["synonyms"][l];
                            }
                        }
                        if (keypairs["definitions"][k].ContainsKey("antonyms"))
                        {
                            for (int l = 0; l < keypairs["definitions"][k]["antonyms"].Length; l++)
                            {
                                if (TextBoxantonym.Text.Length > 0) TextBoxantonym.Text += ", ";
                                TextBoxantonym.Text += keypairs["definitions"][k]["antonyms"][l];
                            }
                        }
                    }
                }
            }
        }
    }
}

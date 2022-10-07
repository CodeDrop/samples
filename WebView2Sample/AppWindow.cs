namespace WebView2Sample
{
    public partial class AppWindow : Form
    {
        public AppWindow()
        {
            InitializeComponent();
        }

        private void AppWindow_Shown(object sender, EventArgs e)
        {
            Browser.Source = new Uri("https://www.sc147.de");
        }
    }
}
using System.Windows;

namespace KAL_GCS_LINKSTAR_1_0.GUI
{
    /// <summary>
    /// Interaction logic for MainStartWindow.xaml
    /// </summary>
    public partial class MainStartWindow : Window
    {
        private StatusDiagram stsDiag;

        private bool test;

        public MainStartWindow()
        {
            InitializeComponent();

            // Set the startup position of main window
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = screenWidth - windowWidth - 100;
            this.Top = screenHeight - windowHeight - 100;

            // Create a status diagram instance
            
            // Create a total link status 
            // Do something here


            // Create a detail link status
            // Do something here
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            if (test == true)
                test = false;
            else
                test = true;

            stsDiag.SetStatus(test);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            // For Debug
            System.Windows.Application.Current.Shutdown();

            // For Release
            //this.WindowState = WindowState.Minimized;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.stsDiag = new StatusDiagram(StatusDiagramCanvas);

            // StatusDiagram.InitializedDiagram should be called now and after Window_Loaded
            // because this uses the actualWidth and actualHeight properties
            stsDiag.InitializeDiagram(2);
        }
    }
}



#region using statements

using DataJuggler.PixelDatabase;
using DataJuggler.UltimateHelper;
using PixelDB = DataJuggler.PixelDatabase.PixelDatabase;

#endregion

namespace DataJuggler.AudioTools.WinFormsTest
{

    #region class MainForm
    /// <summary>
    /// This class [Enter Class Description]
    /// </summary>
    public partial class MainForm : Form
    {
        
        #region Private Variables
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();

            // Create a new instance of a 'SignalInfo' object.
            SignalInfo signal = new SignalInfo();

            // Create a new instance of a 'SignalInfo' object.
            var signal2 = new SignalInfo();
        }
        #endregion
        
        #region Events
            
            #region AnalyzeButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'AnalyzeButton' is clicked.
            /// </summary>
            private void AnalyzeButton_Click(object sender, EventArgs e)
            {
                // Analyze the file and create the Wave
                AudioAnalysis audioAnalysis = WaveVisualizer.VisualizeWave(SourceAudioSelector.Text, Color.LightSteelBlue, Color.White, Color.White, Color.PaleVioletRed);

                // if there were not any errors
                if (!audioAnalysis.HasException)
                {
                    // update the Canvas
                    Canvas.BackgroundImage = audioAnalysis.Bitmap;
                    Canvas.Refresh();
                }
                else
                {
                    // Show a message box for this test
                    MessageBox.Show(audioAnalysis.Exception.ToString(), "Error");
                }
            }
            #endregion
            
        #endregion
        
        #region Methods
            
        #endregion
        
        #region Properties
            
        #endregion
        
    }
    #endregion

}

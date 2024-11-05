

#region using statements

using System.Windows.Forms;

#endregion

namespace DataJuggler.AudioTools.WinFormsTest
{

    #region class MainForm
    /// <summary>
    /// This class is the Designer for the MainForm.
    /// </summary>
    partial class MainForm
    {
        
        #region Private Variables
        private PictureBox Canvas;
        private System.ComponentModel.IContainer components = null;
        private Win.Controls.Button AnalyzeButton;
        private Win.Controls.LabelTextBoxBrowserControl SourceAudioSelector;
        #endregion
        
        #region Events
            
        #endregion
        
        #region Methods
            
            #region Dispose(bool disposing)
            /// <summary>
            ///  Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            #endregion
            
            #region InitializeComponent()
            /// <summary>
            ///  Required method for Designer support - do not modify
            ///  the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
                AnalyzeButton = new Win.Controls.Button();
                SourceAudioSelector = new Win.Controls.LabelTextBoxBrowserControl();
                Canvas = new PictureBox();
                ((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
                SuspendLayout();
                //
                // AnalyzeButton
                //
                AnalyzeButton.BackColor = Color.Transparent;
                AnalyzeButton.ButtonText = "Analyze";
                AnalyzeButton.FlatStyle = FlatStyle.Flat;
                AnalyzeButton.ForeColor = Color.LemonChiffon;
                AnalyzeButton.Location = new Point(710, 114);
                AnalyzeButton.Name = "AnalyzeButton";
                AnalyzeButton.Size = new Size(120, 44);
                AnalyzeButton.TabIndex = 0;
                AnalyzeButton.Theme = Win.Controls.Enumerations.ThemeEnum.Dark;
                AnalyzeButton.Click += AnalyzeButton_Click;
                //
                // SourceAudioSelector
                //
                SourceAudioSelector.BackColor = Color.Transparent;
                SourceAudioSelector.BrowseType = Win.Controls.Enumerations.BrowseTypeEnum.File;
                SourceAudioSelector.ButtonColor = Color.LemonChiffon;
                SourceAudioSelector.ButtonImage = (Image)resources.GetObject("SourceAudioSelector.ButtonImage");
                SourceAudioSelector.ButtonWidth = 48;
                SourceAudioSelector.DarkMode = false;
                SourceAudioSelector.DisabledLabelColor = Color.Empty;
                SourceAudioSelector.Editable = true;
                SourceAudioSelector.EnabledLabelColor = Color.Empty;
                SourceAudioSelector.Filter = null;
                SourceAudioSelector.Font = new Font("Verdana", 12F);
                SourceAudioSelector.HideBrowseButton = false;
                SourceAudioSelector.LabelBottomMargin = 0;
                SourceAudioSelector.LabelColor = Color.LemonChiffon;
                SourceAudioSelector.LabelFont = new Font("Verdana", 12F, FontStyle.Bold);
                SourceAudioSelector.LabelText = "Source Audio:";
                SourceAudioSelector.LabelTopMargin = 0;
                SourceAudioSelector.LabelWidth = 140;
                SourceAudioSelector.Location = new Point(30, 29);
                SourceAudioSelector.Name = "SourceAudioSelector";
                SourceAudioSelector.OnTextChangedListener = null;
                SourceAudioSelector.OpenCallback = null;
                SourceAudioSelector.ScrollBars = ScrollBars.None;
                SourceAudioSelector.SelectedPath = null;
                SourceAudioSelector.Size = new Size(800, 32);
                SourceAudioSelector.StartPath = null;
                SourceAudioSelector.TabIndex = 1;
                SourceAudioSelector.TextBoxBottomMargin = 0;
                SourceAudioSelector.TextBoxDisabledColor = Color.Empty;
                SourceAudioSelector.TextBoxEditableColor = Color.Empty;
                SourceAudioSelector.TextBoxFont = new Font("Verdana", 12F);
                SourceAudioSelector.TextBoxTopMargin = 0;
                SourceAudioSelector.Theme = Win.Controls.Enumerations.ThemeEnum.Dark;
                //
                // Canvas
                //
                Canvas.BackgroundImageLayout = ImageLayout.Stretch;
                Canvas.Location = new Point(30, 185);
                Canvas.Name = "Canvas";
                Canvas.Size = new Size(800, 200);
                Canvas.TabIndex = 2;
                Canvas.TabStop = false;
                //
                // MainForm
                //
                AutoScaleDimensions = new SizeF(7F, 15F);
                AutoScaleMode = AutoScaleMode.Font;
                BackColor = Color.Black;
                ClientSize = new Size(1018, 450);
                Controls.Add(Canvas);
                Controls.Add(SourceAudioSelector);
                Controls.Add(AnalyzeButton);
                Name = "MainForm";
                StartPosition = FormStartPosition.CenterScreen;
                Text = "MainForm";
                ((System.ComponentModel.ISupportInitialize)Canvas).EndInit();
                ResumeLayout(false);
            }
            #endregion
            
        #endregion
        
        #region Properties
            
        #endregion
        
    }
    #endregion

}

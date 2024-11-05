

#region using statements

using DataJuggler.PixelDatabase;
using PixelDB = DataJuggler.PixelDatabase.PixelDatabase;
using DataJuggler.UltimateHelper;
using System.Runtime.Versioning;
using System.Net;
using System.Drawing;

#endregion

namespace DataJuggler.AudioTools
{

    #region class WaveVisualizer
    /// <summary>
    /// This class is used to Create a bitmap image
    /// for a given audio file.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class WaveVisualizer
    {
        
        #region Private Variables
        #endregion
        
        #region Events
            
        #endregion
        
        #region Methods
            
            #region VisualizeWave(string audioFilePath, Color backgroundColor, Color borderColor, Color midLineColor, Color waveLinesColor, int borderThickness = 1, bool drawBorder = true, double containerWidth = 800)
            /// <summary>
            /// returns the Wave
            /// </summary>
            public static AudioAnalysis VisualizeWave(string audioFilePath, Color backgroundColor, Color borderColor, Color midLineColor, Color waveLinesColor, int borderThickness = 1, bool drawBorder = true, double containerWidth = 800)
            {
                // initial value
                AudioAnalysis audioAnalysis =  null;

                // local
                Bitmap bitmap = null;
                string newLine = Environment.NewLine;

                Point borderPoint1 = new Point(0, 0);
                Point borderPoint2 = new Point(0, 0);

                try
                {
                    // analyze the file
                    audioAnalysis = AudioAnalyzer.Analyze(audioFilePath);
                    
                    // if there were not any errors && the SignalData Exists
                    if ((!audioAnalysis.HasException) && (audioAnalysis.HasSignalData))
                    {
                        // set the height and width of the image
                        int height = 200;
                        int width = (int) audioAnalysis.Duration.TotalSeconds * 200;

                        // Create a PixelDatabase
                        PixelDB pixelDatabase = PixelDB.CreateNew(width, height, backgroundColor);

                        // Mid Line
                        borderPoint1 = new Point(0, height / 2);
                        borderPoint2 = new Point(width, height / 2);

                        // Set the bitmap
                        bitmap = pixelDatabase.DirectBitmap.Bitmap;

                        // Draw the MidLine
                        bitmap = pixelDatabase.DrawLine(bitmap, borderPoint1, borderPoint2, borderThickness, borderColor);                        

                        // this adjustment it meant to increase the move for each line.
                        // As the audio is longer, this stretches down the image the 
                        // adjustment needs to be less. Same for the verticalBorderAdjustment.
                        // As the image is larger, the left and right borders need to be longer when
                        // stretch down. I may make this an option for the web as borders are easier with CSS.            
                        double adjustment = .5;
                        int verticalBorderAdjustment = 1;

                        // if wider than container
                        if (width > containerWidth)
                        {  
                            // variable needed for a little extra
                            int extra = (int) NumericHelper.RoundUp((double) audioAnalysis.SignalData.Count * .001, 0);

                            // set the varitcalBorderAdjustment
                            verticalBorderAdjustment = (int)(width / containerWidth) + extra;
                        }

                        // The number of signals indicate longer files have more siglals.
                        if (audioAnalysis.SignalData.Count > 5000)
                        {
                            adjustment = 0;
                            
                        }
                        if (audioAnalysis.SignalData.Count > 4000)
                        {
                            adjustment = .01;                            
                        }
                        else if (audioAnalysis.SignalData.Count > 3000)
                        {
                            adjustment = .02;
                        }
                         else if (audioAnalysis.SignalData.Count > 2000)
                        {
                            adjustment = -.03;
                        }
                        else if (audioAnalysis.SignalData.Count > 1000)
                        {
                            adjustment = .05;
                        }
                        else if (audioAnalysis.SignalData.Count > 500)
                        {
                            adjustment = .1;
                        }
                        else if (audioAnalysis.SignalData.Count > 250)
                        {
                            adjustment = .2;
                        }

                        // locals
                        double currentX = 0;
                        double xMove = NumericHelper.RoundDown(width / (double) audioAnalysis.SignalData.Count, 2) + adjustment;
                        double yMax = audioAnalysis.SignalData.Max(x => x.MaxSignalStrength);
                        double yMin = audioAnalysis.SignalData.Min(x => x.MinSignalStrength);

                        // First draw the borders
                        foreach (SignalInfo signalInfo in audioAnalysis.SignalData)
                        {
                            // Add to currentX
                            currentX += xMove;

                            // Get a normalized value for Y Top value
                            // Get a normalized value for Y Min value
                            // Normalize yTop (0 to 100) and reverse it
                            double yTop = 100 - (signalInfo.MaxSignalStrength * 100);
                            double yBottom =  100 + (Math.Abs(signalInfo.MinSignalStrength) * 100);

                            // Set the points
                            Point startPoint = new Point((int) currentX, (int) yTop);
                            Point endPoint = new Point((int) currentX, (int) yBottom);

                            // Draw the Bottom border
                            bitmap = pixelDatabase.DrawLine(bitmap, startPoint, endPoint, borderThickness, borderColor);
                        }

                        // reload the pixelDatabase with the bitmap
                        // pixelDatabase = PixelDatabaseLoader.LoadPixelDatabase(bitmap, null);

                        // draw the left and right border
                        if (drawBorder)
                        {
                            // Reset the points for a border
                            borderPoint1 = new Point(1, 1);
                            borderPoint2 = new Point(width -1, height -1);
                            pixelDatabase.DrawRectangle(borderPoint1, borderPoint2, borderColor, borderThickness);

                            for (int x = 0; x < verticalBorderAdjustment; x++)
                            {
                                borderPoint1 = new Point(x, 0);
                                borderPoint2 = new Point(x, height);

                                // Draw the Bottom border
                                bitmap = pixelDatabase.DrawLine(bitmap, borderPoint1, borderPoint2, borderThickness, borderColor);
                            }

                            for (int y = width; y > (width - verticalBorderAdjustment); y--)
                            {
                                borderPoint1 = new Point(y, 0);
                                borderPoint2 = new Point(y, height);

                                // Draw the Bottom border
                                bitmap = pixelDatabase.DrawLine(bitmap, borderPoint1, borderPoint2, borderThickness, borderColor);
                            }
                        }
                        
                        // Set the Bitmap
                        audioAnalysis.Bitmap = bitmap;
                    }
                }
                catch (Exception error)
                {
                    // Set the error
                    audioAnalysis.Exception = error;
                }
                
                // return value
                return audioAnalysis;
            }
            #endregion
            
        #endregion
        
        #region Properties
            
        #endregion
        
    }
    #endregion

}



#region using statements

using DataJuggler.UltimateHelper;
using System.Drawing;

#endregion

namespace DataJuggler.AudioTools
{

    #region class AudioAnalysis
    /// <summary>
    /// This class contains strenth info about an Audio file.
    /// </summary>
    public class AudioAnalysis
    {
        
        #region Private Variables
        private TimeSpan duration;
        private int sampleRate;
        private List<RawSignalInfo> rawSignalData;
        private List<SignalInfo> signalData;
        private double maxSignalStrength;
        private double minSignalStrength;
        private Bitmap bitmap;
        private Exception exception;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'AudioAnalysis' object.
        /// </summary>
        public AudioAnalysis()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Methods
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Create a new collection of 'SignalInfo' objects.
                RawSignalData = new();

                // Defaults
                MaxSignalStrength = double.MinValue;
                MinSignalStrength = double.MaxValue;
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region Bitmap
            /// <summary>
            /// This property gets or sets the value for 'Bitmap'.
            /// </summary>
            public Bitmap Bitmap
            {
                get { return bitmap; }
                set { bitmap = value; }
            }
            #endregion
            
            #region Duration
            /// <summary>
            /// This property gets or sets the value for 'Duration'.
            /// </summary>
            public TimeSpan Duration
            {
                get { return duration; }
                set { duration = value; }
            }
            #endregion
            
            #region Exception
            /// <summary>
            /// This property gets or sets the value for 'Exception'.
            /// </summary>
            public Exception Exception
            {
                get { return exception; }
                set { exception = value; }
            }
            #endregion
            
            #region HasBitmap
            /// <summary>
            /// This property returns true if this object has a 'Bitmap'.
            /// </summary>
            public bool HasBitmap
            {
                get
                {
                    // initial value
                    bool hasBitmap = (this.Bitmap != null);
                    
                    // return value
                    return hasBitmap;
                }
            }
            #endregion
            
            #region HasException
            /// <summary>
            /// This property returns true if this object has an 'Exception'.
            /// </summary>
            public bool HasException
            {
                get
                {
                    // initial value
                    bool hasException = (this.Exception != null);
                    
                    // return value
                    return hasException;
                }
            }
            #endregion
            
            #region HasRawSignalData
            /// <summary>
            /// This property returns true if this object has a 'RawSignalData'.
            /// </summary>
            public bool HasRawSignalData
            {
                get
                {
                    // initial value
                    bool hasRawSignalData = (this.RawSignalData != null);
                    
                    // return value
                    return hasRawSignalData;
                }
            }
            #endregion
            
            #region HasSignalData
            /// <summary>
            /// This property returns true if this object has a 'SignalData'.
            /// </summary>
            public bool HasSignalData
            {
                get
                {
                    // initial value
                    bool hasSignalData = (this.SignalData != null);
                    
                    // return value
                    return hasSignalData;
                }
            }
            #endregion
            
            #region MaxSignalStrenth
            /// <summary>
            /// This property gets or sets the value for 'MaxSignalStrength'.
            /// </summary>
            public double MaxSignalStrength
            {
                get { return maxSignalStrength; }
                set { maxSignalStrength = value; }
            }
            #endregion
            
            #region MinSignalStrenth
            /// <summary>
            /// This property gets or sets the value for 'MinSignalStrength'.
            /// </summary>
            public double MinSignalStrength
            {
                get { return minSignalStrength; }
                set { minSignalStrength = value; }
            }
            #endregion
            
            #region SampleRate
            /// <summary>
            /// This property gets or sets the value for 'SampleRate'.
            /// </summary>
            public int SampleRate
            {
                get { return sampleRate; }
                set { sampleRate = value; }
            }
            #endregion
            
            #region RawSignalData
            /// <summary>
            /// This property gets or sets the value for 'RawSignalData'.
            /// </summary>
            public List<RawSignalInfo> RawSignalData
            {
                get { return rawSignalData; }
                set { rawSignalData = value; }
            }
            #endregion
            
            #region SignalData
            /// <summary>
            /// This property gets or sets the value for 'SignalData'.
            /// </summary>
            public List<SignalInfo> SignalData
            {
                get { return signalData; }
                set { signalData = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}

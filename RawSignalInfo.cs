

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataJuggler.AudioTools
{

    #region class SignalInfo
    /// <summary>
    /// This class is used to get the strength of Audio files at each level.
    /// </summary>
    public class RawSignalInfo
    {
        
        #region Private Variables
        private double signalStrength;
        private double time;
        #endregion

        #region Events

        #endregion

        #region Methods

            #region ToString()
            /// <summary>
            /// method returns the String
            /// </summary>
            public override string ToString()
            {
                // return value
                return "Signal Strength: " + signalStrength + " " + "Time: " + time;
            }
            #endregion
            
        #endregion

        #region Properties

            #region SignalStrength
            /// <summary>
            /// This property gets or sets the value for SignalStrength.
            /// </summary>
            public double SignalStrength
            {
                get { return signalStrength; }
                set { signalStrength = value; }
            }
            #endregion
            
            #region Time
            /// <summary>
            /// This property gets or sets the value for Time.
            /// </summary>
            public double Time
            {
                get { return time; }
                set { time = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}

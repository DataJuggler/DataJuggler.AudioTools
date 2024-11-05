

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
    public class SignalInfo
    {
        
        #region Private Variables
        private double minSignalStrength;
        private double maxSignalStrength;
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
                return "Min: " + MinSignalStrength + " Max: " + MaxSignalStrength + " Time: " + time;
            }
            #endregion
            
        #endregion

        #region Properties
            
            #region MaxSignalStrength
            /// <summary>
            /// This property gets or sets the value for 'MaxSignalStrength'.
            /// </summary>
            public double MaxSignalStrength
            {
                get { return maxSignalStrength; }
                set { maxSignalStrength = value; }
            }
            #endregion
            
            #region MinSignalStrength
            /// <summary>
            /// This property gets or sets the value for 'MinSignalStrength'.
            /// </summary>
            public double MinSignalStrength
            {
                get { return minSignalStrength; }
                set { minSignalStrength = value; }
            }
            #endregion
            
            #region Time
            /// <summary>
            /// This property gets or sets the value for 'Time'.
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

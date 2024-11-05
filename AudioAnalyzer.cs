

#region using statements

using DataJuggler.UltimateHelper;
using NAudio.Wave;

#endregion

namespace DataJuggler.AudioTools
{

    #region class AudioAnalyzer
    /// <summary>
    /// This class is used to analyze an Audio file.
    /// </summary>
    public class AudioAnalyzer
    {
        
        #region Methods
            
            #region Analyze(string audioFilePath)
            /// <summary>
            /// method Analyze
            /// </summary>
            public static AudioAnalysis Analyze(string audioFilePath)
            {
                // Create a new instance of an 'AudioAnalysis' object.
                AudioAnalysis analysis = new AudioAnalysis();

                try
                {
                    using (var reader = new AudioFileReader(audioFilePath))
                    {
                        analysis.Duration = reader.TotalTime;
                        analysis.SampleRate = reader.WaveFormat.SampleRate;
                        float[] buffer = new float[reader.WaveFormat.SampleRate * reader.WaveFormat.Channels];
                        int samplesRead;
                        int totalSamplesRead = 0;
                    
                        while ((samplesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            for (int n = 0; n < samplesRead; n++)
                            {
                                float sample = buffer[n];
                                double timeInSeconds = (double)totalSamplesRead / analysis.SampleRate;
                                totalSamplesRead++;
                            
                                analysis.RawSignalData.Add(new RawSignalInfo { SignalStrength = sample, Time = timeInSeconds });
                            
                                if (sample > analysis.MaxSignalStrength)
                                {
                                    analysis.MaxSignalStrength = sample;
                                }
                            
                                if (sample < analysis.MinSignalStrength)
                                {
                                    analysis.MinSignalStrength = sample;
                                }
                            }
                        }
                    }

                    // Now Condense the data
                    List<List<RawSignalInfo>> signalGroups = AudioAnalyzer.GroupSignalData(analysis.RawSignalData);

                    // Now Score each Group
                    analysis.SignalData = ConvertSignalGroups(signalGroups);
                }
                catch (Exception error)
                {
                    // Return the Exception
                    analysis.Exception = error;
                }
                
                // return value
                return analysis;
            }
            #endregion

            #region ConvertSignalGroups(List<RawSignalInfo> rawSignalData)
            /// <summary>
            /// returns a list of Signal Data
            /// </summary>
            public static List<SignalInfo> ConvertSignalGroups(List<List<RawSignalInfo>> signalGroups)
            {
                // Initial value
                List<SignalInfo> signalInfo = new();

                // If the signalGroups collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(signalGroups))
                {
                    // Iterate the collection of var objects
                    foreach (var group in signalGroups)
                    {
                        // set the values
                        double minSignalStrength = group.Min(info => info.SignalStrength);
                        double maxSignalStrength = group.Max(info => info.SignalStrength);
                        double averageTime = group.Average(info => info.Time);
                        
                        SignalInfo newSignalInfo = new SignalInfo
                        {
                            MinSignalStrength = NumericHelper.RoundDown(minSignalStrength, 4),
                            MaxSignalStrength = NumericHelper.RoundUp(maxSignalStrength, 4),
                            Time = averageTime
                        };

                        // add this item
                        signalInfo.Add(newSignalInfo);
                    }
                }

                // Return value
                return signalInfo;
            }
            #endregion
            
            #region GroupSignalData(List<RawSignalInfo> rawSignalData)
            /// <summary>
            /// method returns a list of Signal Data
            /// </summary>
            public static List<List<RawSignalInfo>> GroupSignalData(List<RawSignalInfo> rawSignalData)
            {
                // Initial value
                List<List<RawSignalInfo>> signalGroups = null;
                
                // Use ListHelper to check if the rawSignalData collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(rawSignalData))
                {
                    signalGroups = rawSignalData
                    .Select((s, i) => new { Signal = s, Index = i })
                    .GroupBy(x => x.Index / 1000)
                    .Select(g => g.Select(x => x.Signal).ToList())
                    .ToList();
                }
                
                // Return value
                return signalGroups;
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}

DataJuggler.AudioTools makes it simple to draw a Wave file image in C#. NAudio is used to read audio 
files and DataJuggler.PixelDatabase is used to create the wave images.

# Simple WInForms example: 

Canvas is an 800 x 200 PictureBox with BackgroundImageLayout set to Stretch.

The image created will 200 height and width will be 200 for every second of audio.
Longer audio files do take longer.

    using DataJuggler.AudioTools;

    // Path to your audioFile
	string path = "c:\Temp\Audio.mp3"

    // Analyze the file and create the Wave
    AudioAnalysis audioAnalysis = WaveVisualizer.VisualizeWave(path, Color.LightSteelBlue, Color.White, Color.White, Color.PaleVioletRed);

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

# Future Updates
I am building an audio player now for Blazor and I wanted this to display the wav pattern.
I may build a WinForms player also if anyone has any interested in this let me know.

# Technical Mumbo Jumbo
The way this project works is it reads all the RawSignalInfo data from the audio file, then the RawSignalInfo
is condensed into SignalInfo. Chuncks of 1,000 RawSignalInfo are combined into 1 SignalInfo object,
and the values for MaxSignalInfo and MinSignalInfo are set from the Max and Min of the 1,000.
This means for a 4 second audio file at 48000 Sample Rate, you should get about 196,000 RawSignalInfo
which condenses down to about 196 SignalInfo, which is much easier to work with.

I compared the results against Audacity and it seems to match.

Please create an issue if you find any problems or if you have any suggestions or somments.

Thanks


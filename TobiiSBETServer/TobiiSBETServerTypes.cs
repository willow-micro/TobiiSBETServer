// Target: .NET 6 (LTS)

// Default
// Additional
// Third-party
using EyeTracking;

namespace TobiiSBETServer
{
    /// <summary>
    /// Application State for ui management and status bar
    /// </summary>
    public enum AppState
    {
        /// <summary>
        /// Waiting for starting the eye tracker
        /// </summary>
        WaitForETStart,
        /// <summary>
        /// Waiting for starting the websocket server
        /// </summary>
        WaitForWSStart,
        /// <summary>
        /// Websocket server is started
        /// </summary>
        WSStarted
    }

    /// <summary>
    /// Gaze data to collect from screen-based eye tracker
    /// </summary>
    public struct SBGazeCollectData
    {
        /// <summary>
        /// Initialzer for SBGazeCollectData
        /// </summary>
        /// <param name="t">Unix time in ms</param>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        public SBGazeCollectData(long t, int x, int y)
        {
            this.time = t;
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Unix time in ms
        /// </summary>
        public long time;
        /// <summary>
        /// X coordinate
        /// </summary>
        public int x;
        /// <summary>
        /// Y coordinate
        /// </summary>
        public int y;
    }

    /// <summary>
    /// Event ID for websocket packets
    /// </summary>
    public enum WSEventID
    {
        /// <summary>
        /// Detected a fixation is starting
        /// </summary>
        FixationStarted,
        /// <summary>
        /// Detected a fixation is ending
        /// </summary>
        FixationEnded,
        /// <summary>
        /// Latest LF/HF ratio is computed
        /// </summary>
        LFHFComputed
    }

    /// <summary>
    /// Data for the status bar in the preview window
    /// </summary>
    public struct PreviewData
    {
        /// <summary>
        /// Eye movement
        /// </summary>
        public EyeMovementType eyeMovementType;
        /// <summary>
        /// Validity
        /// </summary>
        public bool isValid;
        /// <summary>
        /// X coordinate
        /// </summary>
        public int x;
        /// <summary>
        /// Y coordinate
        /// </summary>
        public int y;
        /// <summary>
        /// Angular velocity [deg/s]
        /// </summary>
        public float angularVelocity;
        /// <summary>
        /// Pupil diameter of left eye [mm]
        /// </summary>
        public float leftPD;
        /// <summary>
        /// Pupil diameter of right eye [mm]
        /// </summary>
        public float rightPD;
        /// <summary>
        /// Latest LF/HF ratio
        /// </summary>
        public float latestLFHF;
    }

}
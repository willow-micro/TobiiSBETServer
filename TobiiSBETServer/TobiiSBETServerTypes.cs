// Target: .NET 6 (LTS)

// Default
// Additional
// Third-party


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
}
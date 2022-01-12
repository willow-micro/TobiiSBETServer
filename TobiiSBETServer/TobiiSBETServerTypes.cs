// Target: .NET 6 (LTS)

// Default
// Additional
// Third-party


namespace TobiiSBETServer
{
    public enum AppState
    {
        WaitForETStart,
        WaitForWSStart,
        WSStarted
    }

    public struct SBGazeCollectData
    {
        public long time;
        public int x;
        public int y;
    }

    public enum WSEventID
    {
        FixationStarted,
        FixationEnded,
        LFHFComputed
    }
}
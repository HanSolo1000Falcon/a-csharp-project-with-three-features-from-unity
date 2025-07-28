using System.Diagnostics;

namespace StupidLittleGameEngineThing.Engine.Classes;

public class Time
{
    public static float deltaTime { get; private set; }
    public static float fixedDeltaTime { get; private set; } = 0.02f;
    public static float time { get; private set; }

    private static long lastTicks = Stopwatch.GetTimestamp();
    private static readonly double tickFrequency = 1.0 / Stopwatch.Frequency;

    public static void FrameUpdate()
    {
        long nowTicks = Stopwatch.GetTimestamp();
        deltaTime = (float)((nowTicks - lastTicks) * tickFrequency);
        lastTicks = nowTicks;

        time += deltaTime;
    }
}
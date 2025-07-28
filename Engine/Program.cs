using Timer = System.Timers.Timer;
using System.Timers;
using System.Reflection;
using StupidLittleGameEngineThing.Engine.Classes;

namespace StupidLittleGameEngineThing.Engine;

public class Program
{
    public static List<CycleBehaviour> cycleBehaviours = new();
    
    private static Timer timer;
    
    public static void Main()
    {
        timer = new Timer(1000.0 / 50.0);
        timer.Elapsed += TimerElapsed;
        timer.AutoReset = true;
        timer.Start();
        
        Type[] cycleBehavioursArray = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsClass && !type.IsAbstract && typeof(CycleBehaviour).IsAssignableFrom(type) && type != typeof(CycleBehaviour)).ToArray();

        foreach (Type type in cycleBehavioursArray)
            cycleBehaviours.Add(Activator.CreateInstance(type) as CycleBehaviour);

        while (true)
        {
            Time.FrameUpdate();
            
            foreach (CycleBehaviour cycleBehaviour in cycleBehaviours)
                cycleBehaviour.OnFrameUpdate();
        }
    }

    private static void TimerElapsed(object? sender, ElapsedEventArgs e)
    {
        foreach (CycleBehaviour cycleBehaviour in cycleBehaviours)
            cycleBehaviour.OnPhysicsUpdate();
    }
}
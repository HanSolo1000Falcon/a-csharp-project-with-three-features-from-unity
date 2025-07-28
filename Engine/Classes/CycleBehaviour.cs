using System.Reflection;

namespace StupidLittleGameEngineThing.Engine.Classes;

public class CycleBehaviour
{
    private MethodInfo cachedOnFrameUpdate;
    private MethodInfo cachedOnPhysicsUpdate;
    
    public void OnFrameUpdate()
    {
        if (cachedOnFrameUpdate == null)
            cachedOnFrameUpdate = GetType().GetMethod("FrameUpdate", BindingFlags.NonPublic | BindingFlags.Instance);
        
        if (cachedOnFrameUpdate != null)
            cachedOnFrameUpdate.Invoke(this, null);
    }

    public void OnPhysicsUpdate()
    {
        if (cachedOnPhysicsUpdate == null)
            cachedOnPhysicsUpdate = GetType().GetMethod("PhysicsUpdate", BindingFlags.NonPublic | BindingFlags.Instance);
        
        if (cachedOnPhysicsUpdate != null)
            cachedOnPhysicsUpdate.Invoke(this, null);
    }
}
using UnityEngine;

public class EventSystem : GameSystem
{
    public static EventSystem Instance;
    public override void Init()
    {
        if(Instance != null)
        {
            return;
        }
        Instance = this;
    }

    public override void AfterInit()
    {

    }

    public override void Destroy()
    {

    }

    public void OnDestroy()
    {
        Destroy();
    }
}

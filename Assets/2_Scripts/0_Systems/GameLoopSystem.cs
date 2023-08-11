using System.Collections.Generic;
using UnityEngine;

public sealed class GameLoopSystem : GameSystem
{
    private static GameLoopSystem instance;

    public static GameLoopSystem Instance { get { return instance; } }

    [SerializeField] private List<GameSystem> systems;

    public void Awake()
    {
        for(int i = 0; i < systems.Count; i++)
        {
            systems[i].Init();
        }

        for (int i = 0; i < systems.Count; i++)
        {
            systems[i].AfterInit();
        }
    }

    public override void Init()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    public void Update()
    {
        for (int i = 0; i < systems.Count; i++)
        {
            systems[i].EveryFrame();
        }
    }

    public bool GetSystem<T>(out T system) where T : GameSystem
    {
        foreach (var item in systems)
        {
            if(item is T find) 
            {
                system = find;
            }
        }
        system = default(T);
        return false;
    }

    public override void Destroy()
    {
    }

    public void OnDestroy()
    {
        Destroy();
    }
}

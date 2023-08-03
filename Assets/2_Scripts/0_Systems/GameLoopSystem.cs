using System.Collections.Generic;
using UnityEngine;

public sealed class GameLoopSystem : GameSystem
{
    public static GameLoopSystem Instance;

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
        if(Instance != null)
        {
            return;
        }
        Instance = this;
    }

    public void Update()
    {
        for (int i = 0; i < systems.Count; i++)
        {
            systems[i].EveryUpdate();
        }
    }

    public T GetSystem<T>()
    {
        foreach (var system in systems)
        {
            if(system is T find) 
            {
                return find;
            }
        }

        return default(T);
    }

    public override void Destroy()
    {
    }

    public void OnDestroy()
    {
        Destroy();
    }
}

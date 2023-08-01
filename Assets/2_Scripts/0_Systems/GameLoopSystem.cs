using System.Collections.Generic;
using UnityEngine;

public sealed class GameLoopSystem : GameSystem
{
    [SerializeField] private List<GameSystem> System;

    public void Awake()
    {
        for(int i = 0; i < System.Count; i++)
        {
            System[i].Init();
        }

        for (int i = 0; i < System.Count; i++)
        {
            System[i].AfterInit();
        }
    }

    public void Update()
    {
        for (int i = 0; i < System.Count; i++)
        {
            System[i].EveryUpdate();
        }
    }

    public override void Destroy()
    {
    }

    public void OnDestroy()
    {
        Destroy();
    }
}

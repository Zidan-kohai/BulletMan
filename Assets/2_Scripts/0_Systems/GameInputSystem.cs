using UnityEngine;

public class GameInputSystem : GameSystem
{
    public override void Init()
    {

    }

    public override void AfterInit()
    {

    }

    public override void EveryUpdate()
    {
        GameLoopSystem.Instance.GetSystem<GameEventSystem>().OnMousePosition(Input.mousePosition);
    }
}

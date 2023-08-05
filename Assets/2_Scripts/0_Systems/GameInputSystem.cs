using UnityEngine;

public class GameInputSystem : GameSystem
{

    private Camera m_Camera;
    public override void Init()
    {

    }

    public override void AfterInit()
    {
        m_Camera = Camera.main;
    }

    public override void EveryFrame()
    {
        GameLoopSystem.Instance.GetSystem<GameEventSystem>().OnMousePosition(m_Camera.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButton(0))
        {
            GameLoopSystem.Instance.GetSystem<GameEventSystem>().OnMouseUnder(m_Camera.ScreenToWorldPoint(Input.mousePosition));

        }else if (Input.GetMouseButtonUp(0))
        {
            GameLoopSystem.Instance.GetSystem<GameEventSystem>().OnMouseAbove(new Vector2(0,0));
        }
    }
}

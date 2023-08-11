using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class GameInputSystem : GameSystem
{
    private Camera m_Camera;

    private GameEventSystem eventSystem;
    public override void Init()
    {

    }

    public override void AfterInit()
    {
        m_Camera = Camera.main;
        if (GameLoopSystem.Instance.GetSystem(out GameEventSystem system))
        {
            eventSystem = system;
        }
    }

    public override void EveryFrame()
    {
        eventSystem.OnMousePosition(m_Camera.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButton(0))
        {
            eventSystem.OnMouseUnder(m_Camera.ScreenToWorldPoint(Input.mousePosition));

        }else if (Input.GetMouseButtonUp(0))
        {
            eventSystem.OnMouseAbove(new Vector2(0,0));
        }
    }
}

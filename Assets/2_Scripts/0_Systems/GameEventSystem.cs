using System;
using System.Linq;
using UnityEngine;

public class GameEventSystem : GameSystem
{
    public static GameEventSystem Instance;
    public override void Init()
    {
        if(Instance != null)
        {
            return;
        }
        Instance = this;
    }

    private Action mouseUnder;
    private Action mouseAbove;
    private Action<Vector2> mousePosition;

    #region Mouse

    #region MouseUnder
    public void SubscribeOnMouseUnder(Action sender)
    {
        if(mouseUnder != null)
        {
            mouseUnder = sender;
        }
        if(mouseUnder.GetInvocationList().Length > 0 && !mouseUnder.GetInvocationList().Contains(sender)) 
        {
            mouseUnder += sender;
        }
    }
    public void UnsubscribeOnMouseUnder(Action sender)
    {
        mouseUnder -= sender;
    }
    public void OnMouseUnder()
    {
        mouseUnder?.Invoke();
    }
    #endregion

    #region MouseAbove
    public void SubscribeOnMouseAbove(Action sender)
    {
        if (mouseAbove != null)
        {
            mouseAbove = sender;
        }
        if (mouseAbove.GetInvocationList().Length > 0 && !mouseAbove.GetInvocationList().Contains(sender))
        {
            mouseAbove += sender;
        }
    }
    public void UnsubscribeOnMouseAbove(Action sender)
    {
        mouseAbove -= sender;
    }
    public void OnMouseAbove()
    {
        mouseAbove?.Invoke();
    }
    #endregion

    #region MousePosition
    public void SubscribeOnMousePosition(Action<Vector2> sender)
    {
        if (mousePosition != null)
        {
            mousePosition = sender;
        }
        if (mousePosition.GetInvocationList().Length > 0 && !mousePosition.GetInvocationList().Contains(sender))
        {
            mousePosition += sender;
        }
    }
    public void UnsubscribeOnMousePosition(Action<Vector2> sender)
    {
        mousePosition -= sender;
    }
    public void OnMMousePosition(Vector2 Position)
    {
        mousePosition?.Invoke(Position);
    }

    #endregion

    #endregion


    public override void Destroy()
    {

    }

    public void OnDestroy()
    {
        Destroy();
    }
}

using System;
using System.Linq;
using UnityEngine;

public class GameEventSystem : GameSystem
{
    public override void Init()
    { 
    }

    private Action<Vector2> mouseUnder;
    private Action<Vector2> mouseAbove;
    private Action<Vector2> mousePosition;
    private Action<MonoBehaviour> spawnObject;


    #region Mouse

    #region MouseUnder
    public void SubscribeOnMouseUnder(Action<Vector2> sender)
    {
        if(mouseUnder == null)
        {
            mouseUnder = sender;
        }
        if(mouseUnder.GetInvocationList().Length > 0 && !mouseUnder.GetInvocationList().Contains(sender)) 
        {
            mouseUnder += sender;
        }
    }
    public void UnsubscribeOnMouseUnder(Action<Vector2> sender)
    {
        mouseUnder -= sender;
    }
    public void OnMouseUnder(Vector2 Position)
    {
        mouseUnder?.Invoke(Position);
    }
    #endregion

    #region MouseAbove
    public void SubscribeOnMouseAbove(Action<Vector2> sender)
    {
        if (mouseAbove == null)
        {
            mouseAbove = sender;
        }
        if (mouseAbove.GetInvocationList().Length > 0 && !mouseAbove.GetInvocationList().Contains(sender))
        {
            mouseAbove += sender;
        }
    }
    public void UnsubscribeOnMouseAbove(Action<Vector2> sender)
    {
        mouseAbove -= sender;
    }
    public void OnMouseAbove(Vector2 Position)
    {
        mouseAbove?.Invoke(Position);
    }
    #endregion

    #region MousePosition
    public void SubscribeOnMousePosition(Action<Vector2> sender)
    {
        if (mousePosition == null)
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
    public void OnMousePosition(Vector2 Position)
    {
        mousePosition?.Invoke(Position);
    }

    #endregion

    #endregion

    #region SpawnObject
    public void SubscribeOnSpawnObject(Action<MonoBehaviour> sender)
    {
        if (spawnObject == null)
        {
            spawnObject = sender;
        }
        if (spawnObject.GetInvocationList().Length > 0 && !spawnObject.GetInvocationList().Contains(sender))
        {
            spawnObject += sender;
        }
    }
    public void UnsubscribeOnSpawnObject(Action<MonoBehaviour> sender)
    {
        spawnObject -= sender;
    }
    public void OnSpawnObject(MonoBehaviour obj)
    {
        spawnObject?.Invoke(obj);
    }
    #endregion
    public override void Destroy()
    {

    }

    public void OnDestroy()
    {
        Destroy();
    }
}

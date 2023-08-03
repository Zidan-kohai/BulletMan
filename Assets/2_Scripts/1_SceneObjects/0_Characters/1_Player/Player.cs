using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour, IDinamicObject
{
    private void OnEnable()
    {
        GameLoopSystem.Instance.GetSystem<GameEventSystem>().SubscribeOnMousePosition(HandRotation);
    }

    public void EveryFrame()
    {
        
    }

    private void HandRotation(Vector2 mousePosition)
    {
        Debug.Log(mousePosition);
    }

    private void OnDestroy()
    {
        GameLoopSystem.Instance.GetSystem<GameEventSystem>().UnsubscribeOnMousePosition(HandRotation);
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour, IDinamicObject
{
    private void OnEnable()
    {
        GameLoopSystem.Instance.GetSystem<GameEventSystem>().OnSpawnObject(this);
    }

    public void EveryFrame()
    {

    }

    private void OnDestroy()
    {
    }
}

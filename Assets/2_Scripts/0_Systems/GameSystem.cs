using UnityEngine;

public abstract class GameSystem : MonoBehaviour
{
    public virtual void Init() { }

    public virtual void AfterInit() { }

    public virtual void EveryFrame() { }

    public virtual void Destroy() { }
}
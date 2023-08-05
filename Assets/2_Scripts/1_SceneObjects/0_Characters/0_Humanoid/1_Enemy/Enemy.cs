using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour, IDinamicObject
{
    [Header("General")]
    [SerializeField] private float waitToReady;
    private void OnEnable()
    {
        OnSpawn(waitToReady);
    }

    public void OnSpawn(float waitToReady)
    {
        DOTween.Sequence().AppendInterval(waitToReady).OnComplete(() =>
        {
            GameLoopSystem.Instance.GetSystem<GameEventSystem>().OnSpawnObject(this);

        }).SetLink(gameObject);
    }

    public void EveryFrame()
    {

    }

    private void OnDestroy()
    {
    }
}

using UnityEngine;

public class Player : MonoBehaviour, IDinamicObject
{
    [Header("Hand")]
    [SerializeField] private Transform hand;
    [SerializeField] private float AndleOfset;

    [Header("Bullet")]
    [SerializeField] private Transform bulletSpawnPosition;

    [Header("LineRenderer")]
    [SerializeField] private LineRenderer bulletPath;
    [SerializeField] private float distance;

    private void OnEnable()
    {
        Invoke("Subscribe", 0.5f);
    }

    private void Subscribe()
    {
        GameLoopSystem.Instance.GetSystem<GameEventSystem>().SubscribeOnMouseUnder(OnMouseUnder);
        GameLoopSystem.Instance.GetSystem<GameEventSystem>().SubscribeOnMouseAbove(OnMouseAbove);
        GameLoopSystem.Instance.GetSystem<GameEventSystem>().OnSpawnObject(this);
    }

    public void EveryFrame()
    {

    }
    private void OnMouseUnder(Vector2 mousePosition)
    {
        HandRotation(mousePosition);
        DrawBulletPath();
    }

    private void OnMouseAbove(Vector2 mousePosition)
    {
        HandRotation(mousePosition);
        ClearBulletPath();
    }


    private void HandRotation(Vector2 mousePosition)
    {
        Vector2 direction = (mousePosition - new Vector2(hand.position.x, hand.position.y)).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - AndleOfset;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        hand.rotation = rotation;
    }

    private void DrawBulletPath()
    {
        bulletPath.positionCount = 2;

        bulletPath.SetPositions(new Vector3[] { bulletSpawnPosition.position, bulletSpawnPosition.position + (bulletSpawnPosition.right) * distance });

    }

    private void ClearBulletPath()
    {
        bulletPath.positionCount = 0;
    }

    

    private void OnDestroy()
    {
        GameLoopSystem.Instance.GetSystem<GameEventSystem>().UnsubscribeOnMouseUnder(OnMouseUnder);
        GameLoopSystem.Instance.GetSystem<GameEventSystem>().UnsubscribeOnMouseAbove(OnMouseAbove);
    }
}

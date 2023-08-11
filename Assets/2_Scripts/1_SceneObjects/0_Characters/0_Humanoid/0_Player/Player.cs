using UnityEngine;

public class Player : MonoBehaviour, IDinamicObject
{
    [Header("General")]
    [SerializeField] private float waitToReady;

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
        Invoke("OnSpawn", waitToReady);
    }

    public void OnSpawn()
    {
        if (GameLoopSystem.Instance.GetSystem(out GameEventSystem system))
        {
            system.SubscribeOnMouseUnder(OnMouseUnder);
            system.SubscribeOnMouseAbove(OnMouseAbove);
            system.OnSpawnObject(this);
        }
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
        if (GameLoopSystem.Instance.GetSystem<GameEventSystem>(out GameEventSystem system))
        {
            system.UnsubscribeOnMouseUnder(OnMouseUnder);
            system.UnsubscribeOnMouseAbove(OnMouseAbove);
        }
    }
}

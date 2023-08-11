using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Enemy : MonoBehaviour, IDinamicObject
{
    [Header("General")]
    [SerializeField] private float waitToReady;

    [Header("Components")]
    [SerializeField] private Animator anim;
    [SerializeField] private List<Solver2D> solvers;
    [SerializeField] private List<Rigidbody2D> rigidbodies;
    [SerializeField] private List<HingeJoint2D> hingleJoints;
    [SerializeField] private List<Collider2D> colliders;


    [Header("Collision")]
    [SerializeField] private List<IgnoreCollistion> ignoreCollision;

    private void OnEnable()
    {
        Invoke("OnSpawn", waitToReady);
    }

    public void OnSpawn()
    {
        if (GameLoopSystem.Instance.GetSystem(out GameEventSystem system))
        {
            system.OnSpawnObject(this);
        }

        IgnoreCollision();
    }

    private void IgnoreCollision()
    {
        foreach (var item in ignoreCollision)
        {
            for (int i = 0; i < item.Collisions.Count; i++)
            {
                for (int j = i + 1; j < item.Collisions.Count; j++)
                {
                    Physics2D.IgnoreCollision(item.Collisions[i], item.Collisions[j]);
                }
            }
        }
    }

    public void EveryFrame()
    {

    }

    protected virtual void GetDamage()
    {
        Death();
    }

    [ContextMenu("Death")]
    private void Death()
    {
        anim.enabled = false;

        foreach(var s in solvers)
            s.weight = 0f;

        foreach(var r in rigidbodies)
            r.simulated = true;

        foreach (var h in hingleJoints)
            h.enabled = true;

        foreach (var c in colliders)
            c.isTrigger = false;
    }

    private void OnDestroy()
    {

    }
}
[Serializable]
public struct IgnoreCollistion
{
    public List<Collider2D> Collisions;
}

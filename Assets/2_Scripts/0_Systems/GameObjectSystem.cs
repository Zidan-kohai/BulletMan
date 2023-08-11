using System.Collections.Generic;
using UnityEngine;

public class GameObjectSystem : GameSystem
{  
    private List<MonoBehaviour> dinamicObject = new();
    private List<MonoBehaviour> staticObject = new();

    [Header("Dinamic Object")]
    [SerializeField] private Transform heroParent;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private Transform interactiveObjectParent;

    [Header("Static Object")]
    [SerializeField] private Transform staticParent;

    public override void Init()
    {

    }
    public override void AfterInit()
    {
        if (GameLoopSystem.Instance.GetSystem(out GameEventSystem system))
        {
            system.SubscribeOnSpawnObject(AddObject);
        }
    }

    private void AddObject(MonoBehaviour obj)
    {
        if (obj is IDinamicObject && !dinamicObject.Contains(obj))
        {
            if(obj is Player)
            {
                obj.transform.parent = heroParent;
            }
            else if(obj is Enemy) {

                obj.transform.parent = enemyParent;
            }
            else
            {
                obj.transform.parent = interactiveObjectParent;
            }

            dinamicObject.Add(obj);
            return;
        }

        if(!staticObject.Contains(obj))
        {
            obj.transform.parent = staticParent;
            staticObject.Add(obj);
            return;
        }
    }

    private void RemoveObject(MonoBehaviour obj)
    {
        foreach (var item in dinamicObject)
        {
            if(obj.Equals(item))
            {
                dinamicObject.Remove(item);
                return;
            }
        }

        foreach (var item in staticObject)
        {
            if (obj.Equals(item))
            {
                staticObject.Remove(item);
                return;
            }
        }
    }


    public override void Destroy()
    {
        if (GameLoopSystem.Instance.GetSystem(out GameEventSystem system))
        {
            system.UnsubscribeOnSpawnObject(AddObject);
        }
    }

    public void OnDestroy() 
    {
        Destroy();
    }
}

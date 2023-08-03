using System.Collections.Generic;
using UnityEngine;

public class GameObjectSystem : GameSystem
{  
    private List<MonoBehaviour> dinamicObject = new();
    private List<MonoBehaviour> staticObject = new();


    public override void Init()
    {

    }
    public override void AfterInit()
    {

    }

    private void AddObject(MonoBehaviour obj)
    {
        if (obj is IDinamicObject && !dinamicObject.Contains(obj))
        {
            dinamicObject.Add(obj);
            return;
        }

        if(!staticObject.Contains(obj))
        {
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
    }

    public void OnDestroy() 
    {
        Destroy();
    }
}

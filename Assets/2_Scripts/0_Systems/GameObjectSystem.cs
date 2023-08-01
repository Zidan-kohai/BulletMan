using System.Collections.Generic;

public class GameObjectSystem : GameSystem
{  
    private List<object> dinamicObject = new();
    private List<object> staticObject = new();


    public override void Init()
    {

    }
    public override void AfterInit()
    {

    }

    private void AddObject(object obj)
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

    private void RemoveObject(object obj)
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

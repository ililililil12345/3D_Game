using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : Singleton<Pool>
{
    public List<GameObject> coinPool = new List<GameObject>();
    public List<GameObject> rightCarPool = new List<GameObject>();
    public List<GameObject> leftCarPool = new List<GameObject>();

    public void InPool(GameObject obj)
    {
        if (obj.GetComponent<Coin>())
        {
            coinPool.Add(obj);
        }
        else if (obj.GetComponent<Car>())
        {
            if (obj.transform.rotation.y == 0)
            {
                rightCarPool.Add(obj);
            }
            else if (obj.transform.rotation.y == 180)
            {
                leftCarPool.Add(obj);
            }
        }
        obj.transform.parent = transform.parent;
        obj.SetActive(false);
    }
    
}

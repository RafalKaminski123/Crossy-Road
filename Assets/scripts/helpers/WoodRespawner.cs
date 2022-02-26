using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodRespawner : MonoBehaviour
{
    public GameObject woodRef;
    public int woodCount;
    public Vector3 spacing;
    public bool clearOnGenerate;
    [ContextMenu("RespawnWoods")]
   public void RespawnWood()
    {
        if(clearOnGenerate)
        {
            ClearWoods();
        }

        for (int i = 0; i < woodCount; i++)
        {
            Instantiate(woodRef, woodRef.transform.position + (spacing * i), woodRef.transform.rotation, transform);
        }
    }
    [ContextMenu("ClearWoods")] 
    public void ClearWoods()
    {
       Transform[] toChildrens = GetComponentsInChildren<Transform>();
        for (int i = 0; i < toChildrens.Length; i++)
        {
            if (toChildrens[i] != transform && toChildrens[i] != woodRef.transform)
            {
                DestroyImmediate(toChildrens[i].gameObject);
            }
        }
        
    }
    
}

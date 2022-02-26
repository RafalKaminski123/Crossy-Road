using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodRespawner : MonoBehaviour
{
    public GameObject woodRef;
    public int woodCount;
    public Vector3 spacing;
    [ContextMenu("RespawnWoods")]
   public void RespawnWood()
    {
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

            }
        }
        Debug.Log(toChildrens.Length);
    }
}

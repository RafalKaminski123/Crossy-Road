using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothness;
    [SerializeField] private Vector3 rotationOffset;
    private void Start()
    {
        
        transform.position = player.transform.position + offset;
        transform.rotation = Quaternion.LookRotation((player.transform.position + rotationOffset) - transform.position);

    }

    private void Update()
    {
        float newZ = Mathf.Lerp(transform.position.z, (player.transform.position + offset).z, smoothness * Time.deltaTime);
       //transform.position =  Vector3.Lerp(transform.position, player.transform.position + offset, smoothness * Time.deltaTime);
        transform.position =  new Vector3(offset.x,offset.y, newZ );
    }

   
}

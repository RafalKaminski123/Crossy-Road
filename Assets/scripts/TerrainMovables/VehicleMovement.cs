using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<PlayerController>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   public bool isNonRbForce;
   public Vector3 dir;
   public float force;
    public LayerMask groundLayer;
   public Rigidbody rb;
    private Vector3 velocity;

   
    private void Update()
    {
        if (isNonRbForce)
        {
            velocity = dir * force * Time.deltaTime;
            bool Isgrounded = Physics.Raycast(transform.position, Vector2.down, 0.3f, groundLayer);
            Debug.DrawRay(transform.position, Vector2.down);
            if (!Isgrounded)
            {
                transform.Translate(velocity);
                
            }
            else
            {
                Debug.Log(" hitgroundproj");
                force = 0;
                dir = Vector3.zero;
                rb.velocity = Vector3.zero;
            }
        }
        
    }

}

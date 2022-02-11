using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody ballRigidbody;
    [SerializeField] private float force;


    void FixedUpdate()
    {
        ballRigidbody.AddForce(Vector3.back*force, ForceMode.Acceleration);
    }

    /*void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, Vector3.up*lineHeight); 
    }*/

    
}

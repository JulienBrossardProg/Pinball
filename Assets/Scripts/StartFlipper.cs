using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFlipper : MonoBehaviour
{
    private Vector3 springScale;
    [SerializeField] private KeyCode key = KeyCode.DownArrow;
    [SerializeField] private Rigidbody ballRigidbody;
    [SerializeField] private float force;
    private bool isTouchBall;

    private void Awake()
    {
        springScale = transform.localScale;
    }

    void Update()
    {
        Spring();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            isTouchBall = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            isTouchBall = false;
        }
    }

    void Spring()
    {
        if (Input.GetKey(key) && transform.localScale.z>= 0.1f)
        {
            transform.localScale -= new Vector3(0, 0, 0.01f);
        }
        
        else if (!Input.GetKey(key) && isTouchBall)
        {
            transform.localScale = new Vector3(springScale.x, springScale.y, Mathf.Lerp(transform.localScale.z, springScale.z, 20*Time.deltaTime )) ;
            if (Input.GetKeyUp(key))
            {
                ballRigidbody.AddForce(Vector3.forward * force);
            }
        }
    }
    
}

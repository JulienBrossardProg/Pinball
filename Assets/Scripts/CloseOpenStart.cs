using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOpenStart : MonoBehaviour
{
    [SerializeField] private MeshRenderer wallMesh;
    [SerializeField] private BoxCollider wallCollider;
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            wallMesh.enabled = true;
            wallCollider.isTrigger = false;
        }
    }
}

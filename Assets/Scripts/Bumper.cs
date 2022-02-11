using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float distanceX;
    [SerializeField] private float distanceZ;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private MeshRenderer bumperMesh;
    [SerializeField] private Material sharedMaterial;
    [SerializeField] private Gradient gradient;
    private Vector3 startingScale;
    public AnimationCurve curve;
    public float curveEvolution;
    public float animationSpeed = 0.01f;
    [SerializeField] private float points =10;

    private void Awake()
    {
        bumperMesh = GetComponent<MeshRenderer>();
    }
    
    private void Start()
    {
        startingScale = transform.localScale;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            distanceX = other.transform.position.x - transform.position.x;
            distanceZ = other.transform.position.z - transform.position.z;
            other.rigidbody.AddForce(new Vector3(distanceX, 0, distanceZ) * force);
            scoreManager.ScoreCount(points);
            ChangeScale();
        }
    }

    void ChangeScale()
    {
        curveEvolution = 0;
        StartCoroutine(ChangeScaleCoroutine());
    }

    IEnumerator ChangeScaleCoroutine()
    {
        yield return new WaitForEndOfFrame();
        curveEvolution += animationSpeed;
        transform.localScale = startingScale * (1 + curve.Evaluate(curveEvolution));

        bumperMesh.sharedMaterial.color = gradient.Evaluate(curveEvolution);

        if (curveEvolution < 1)
        {
            StartCoroutine(ChangeScaleCoroutine());
        }
       

    }
}

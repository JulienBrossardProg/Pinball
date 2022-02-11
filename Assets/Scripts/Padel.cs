using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padel : MonoBehaviour
{
    [SerializeField] private float targetPosition = 75;
    [SerializeField] private float originPosition;

    [SerializeField] private HingeJoint hingeJoint;

    private JointSpring jointSpring;

    [SerializeField] private KeyCode key = KeyCode.Space;

    private void Start()
    {
        jointSpring = hingeJoint.spring;
    }

    void Update()
    {
        if (Input.GetKey(key))
        {
            jointSpring.targetPosition = targetPosition;
        }

        else
        {
            jointSpring.targetPosition = originPosition;
        }

        hingeJoint.spring = jointSpring;
    }
}

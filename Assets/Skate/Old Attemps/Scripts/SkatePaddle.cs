using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkatePaddle : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private WheelJoint2D[] wheels;
    [SerializeField] private GameObject floor;

    // Start is called before the first frame update
    void Start()
    {
        //wheels = GetComponents<WheelJoint2D>();
        wheels = FindObjectsOfType<WheelJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        JointMotor2D motor = wheels[0].motor;
        motor.motorSpeed = speed * xDirection;
        
        foreach (WheelJoint2D wheel in wheels) {
            wheel.motor = motor;
        }

        // move along a path
        // p = f()
        // angle = f()
        //transform.MoveTowards(transform.position, floor.transform.position)
    }
}

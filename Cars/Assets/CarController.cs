using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    public InputManager inputManager;
    public List<WheelCollider> throttleWheels;
    public List<WheelCollider> steeringWheels;
    public float strengthCoefficient = 7500f;
    public float maxTurn = 20f;
    public Transform centerOfMass;
    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        rigidbody = GetComponent<Rigidbody>();

        if (centerOfMass)
        {
            rigidbody.centerOfMass = centerOfMass.position;
        }
    }

    void FixedUpdate()
    {
        foreach(WheelCollider wheel in throttleWheels)
        {
            wheel.motorTorque = strengthCoefficient * Time.deltaTime * inputManager.throttle;
        }

        foreach(WheelCollider wheel in steeringWheels)
        {
            wheel.steerAngle = maxTurn * inputManager.steer;
        }
    }
}

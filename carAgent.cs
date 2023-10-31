using System;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class CarAgent : Agent
{
    public GameObject car;
    public Vector3 m_move;

    private VehicleBehaviour.WheelVehicle m_carController;

    [SerializeField] private Vector3 m_dirToTarget;
    [SerializeField] private Vector3 m_velocity;
    [SerializeField] private Vector3 m_angularVelocity;

    Rigidbody m_carRigidbody;

    public override void Initialize()
    {
        Debug.Log("Agent Initialized");
        m_carRigidbody = car.GetComponent<Rigidbody>();
        m_carController = GetComponent<VehicleBehaviour.WheelVehicle>();
        m_carController.AgentMove(new Vector3(338.44f,21.3f,352.65f));
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        Debug.Log("Collecting Observations");

        // Agent velocity
        Vector3 m_velocity = transform.InverseTransformDirection(m_carRigidbody.velocity) / 20f;
        sensor.AddObservation(new Vector3(m_velocity.x, m_velocity.y, m_velocity.z)); // vec2
        Debug.Log(m_velocity);

        // // Agent's normalized local position
        sensor.AddObservation(new Vector3(transform.localPosition.x / 500f, transform.localPosition.y / 500f, transform.localPosition.z / 500f)); // vec2

        // // Agent's normalized torque and steering angle
        sensor.AddObservation(m_carController.GetTorque()); //float
        sensor.AddObservation(m_carController.GetSteeringAngle()); //float

        // // Dot product of agent forward and direction to incoming checkpoint/target
        // sensor.AddObservation(Vector3.Dot(transform.forward, m_dirToTarget)); //float

        // // Agent angular velocity
        m_angularVelocity = transform.InverseTransformDirection(m_carRigidbody.angularVelocity) / 3f;
        sensor.AddObservation(m_angularVelocity.y); // float
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Debug.Log(actions.ContinuousActions.Length);
        Debug.Log(actions.ContinuousActions[0]);
        Debug.Log(actions.ContinuousActions[1]);
        Debug.Log(actions.ContinuousActions[2]);
        // m_move.x = Mathf.Clamp(actions.ContinuousActions[0], -1f, 1f);
        // m_move.y = Mathf.Clamp(actions.ContinuousActions[1], -1f, 1f);
        // m_move.z = Mathf.Clamp(actions.ContinuousActions[2], -1f, 1f);
        // m_carController.AgentMove(m_move);
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var _actionsOut = actionsOut.ContinuousActions;
        Debug.Log(actionsOut.ContinuousActions.Length);
        // _actionsOut[0] = m_move.x;
        // _actionsOut[1] = m_move.y;
        // _actionsOut[2] = m_move.z;
        // m_carController.AgentMove(m_move);
    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumPhysics : MonoBehaviour
{
    public RigidBody2D body2d;
    public float leftPush;
    public float rightPush;
    public float velocityThreshold;

    void Start()
    {
        body2d = GetComponent(RigidBody2D());
        body2d.angularVelocity = velocityThreshold;
    }

    void Update()
    {
        Push();
    }

    public void Push()
    {
        if(transform.rotation.z> 0
            && (body2d.angularVelocity.z < rightPush)
            && (body2d.angularvelocity > 0)
            && body2d.angularVelocity < velocityThreshold)
        {
            body2d.angularVelocity = velocityThreshold;
        } else if(transform.rotation.z < 0
            && (body2d.angularVelocity > leftPush)
            && (body2d.angularVelocity < 0)
            && body2d.angularVelocity > velocityThreshold * -1) {
            body2d.angularVelocity = velocityThreshold * -1;
        }
    }
}
*/
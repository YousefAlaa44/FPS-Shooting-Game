using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody Rg;
    Vector3 Velocity;
    void Start()
    {
        Rg = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _Velocity)
    {
        Velocity = _Velocity;   
    }

    public void LookAt(Vector3 LookPoint)
    {
        Vector3 CorrectHeight = new Vector3(LookPoint.x, transform.position.y, LookPoint.z);
        transform.LookAt(CorrectHeight);
    }

    void FixedUpdate()
    {
        Rg.MovePosition(Rg.position + Velocity * Time.fixedDeltaTime);
    }
}

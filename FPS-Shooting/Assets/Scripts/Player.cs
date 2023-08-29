using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float Speed = 5f;

    PlayerController controller;
    Camera maincamera;
    void Start()
    {
        controller = GetComponent<PlayerController>();
        maincamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MovInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 playerVelocity = MovInput.normalized * Speed;

        controller.Move(playerVelocity);

        Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);

        Plane GroundPlane = new Plane(Vector3.up, Vector3.zero);
        float RayDistence;
        if (GroundPlane.Raycast(ray,out RayDistence))
        {
            Vector3 Point = ray.GetPoint(RayDistence);
            //Debug.DrawLine(ray.origin, Point, Color.red);
            controller.LookAt(Point);
        }

        
    }
}

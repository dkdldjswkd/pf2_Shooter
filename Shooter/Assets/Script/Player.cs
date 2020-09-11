using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlayerController))]
[RequireComponent (typeof(GunController))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 5;
    PlayerController controller;
    Camera viewCamera;
    GunController gunController;

    // Start is called before the first frame update
    void Start()
    {
        gunController = GetComponent<GunController>();
        controller = GetComponent<PlayerController>();
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //이동을 입력받는곳
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        //바라보는 방향을 입력받는곳
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlain = new Plane(Vector3.up, Vector3.zero); // 노멀벡터, 원점으로부터 거리
        float rayDistance;

        if (groundPlain.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }

        //무기조작입력
        if (Input.GetMouseButton(0))
        {
            gunController.Shoot();
        }
    }
}

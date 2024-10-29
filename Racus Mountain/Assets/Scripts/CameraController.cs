using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    private float positionX;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(positionX, transform.position.y, transform.position.z), ref velocity, cameraSpeed);

    }

    public void MoveCamera(Transform nextRoom)
    {
        positionX = nextRoom.position.x;
    }
}

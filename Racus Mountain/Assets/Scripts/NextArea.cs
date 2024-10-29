using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextArea : MonoBehaviour
{
    [SerializeField] private Transform currentArea;
    [SerializeField] private Transform nextArea;
    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(other.transform.position.x < transform.position.x)
            {
                cam.MoveCamera(nextArea);
            }
            else {
                cam.MoveCamera(currentArea);
            }
        }
    }

}

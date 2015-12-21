using UnityEngine;
using System.Collections;
using System;
public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Transform startPos;
    public Transform target;
    void Update()
    {
        float deltaY = Math.Max(player.transform.position.y, 0f) - Camera.main.transform.position.y;
        //float deltaY = player.transform.position.y - Camera.main.transform.position.y;
        if (Camera.main.transform.position.y > 0 && player.transform.position.y > Camera.main.transform.position.y || (Camera.main.transform.position.y == 0 && deltaY > 0))
        {
            //move camera by character
            Camera.main.transform.position += new Vector3(0f, deltaY, 0f);
        }
    }
}

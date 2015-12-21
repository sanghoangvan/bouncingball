using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

    public GameObject Ball;
    void Update()
    {
        this.gameObject.transform.position = new Vector3(0, Ball.transform.position.y - 0.28f, Ball.transform.position.z);
    }
}

using UnityEngine;
using System.Collections;

public class HitBall : MonoBehaviour
{
    private float speed = 8f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Debug.Log("GAME OVER");

    }
}

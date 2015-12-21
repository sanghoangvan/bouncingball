using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
    public bool grounded;
    public Transform groundcheck;
    public float speed = 7f;
    float groundRadius = 0.01f;
    public LayerMask ground;

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundRadius, ground);
        if (grounded && this.gameObject.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }
      
    }
}

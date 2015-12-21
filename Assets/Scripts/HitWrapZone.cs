using UnityEngine;
using System.Collections;

public class HitWrapZone : MonoBehaviour {
    // Use this for initialization
    public GameObject WrapZone;
    void Awake()
    {
    }
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            WrapZone.GetComponent<Renderer>().enabled = false;
            WrapZone.GetComponent<Collider2D>().isTrigger = false;
            this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

}

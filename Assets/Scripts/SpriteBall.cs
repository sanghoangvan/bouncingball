using UnityEngine;
using System.Collections;

public class SpriteBall : MonoBehaviour {
    void Awake()
    {
        //this.gameObject.GetComponent<Sprite>().name
        Sprite[] sprites = Resources.LoadAll<Sprite>("ball");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[UnityEngine.Random.Range(0, 3)];
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

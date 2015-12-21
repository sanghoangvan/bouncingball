using UnityEngine;
using System.Collections;

public class LineZoneCollider : MonoBehaviour {
    public GameObject WrapZone;
    private float LineZoneRight = 4.34f;
    private float box1CenterX,box2CenterX;
    private float LineZonePosY;
    
    // Use this for initialization
    void Update()
    {
    }
    void Start () {
        BoxCollider2D boxCollider1 = this.gameObject.AddComponent<BoxCollider2D>();
        boxCollider1.size = new Vector3((LineZoneRight-WrapZone.transform.position.x-0.55f)/2, 0.04f, 0);
        box1CenterX = (LineZoneRight - boxCollider1.size.x)/2;
        boxCollider1.offset = new Vector3(box1CenterX, 0, 0);
        //
        BoxCollider2D boxCollider2 = this.gameObject.AddComponent<BoxCollider2D>();
        boxCollider2.size = new Vector3((LineZoneRight + WrapZone.transform.position.x - 0.55f) / 2.0f, 0.04f, 0);
        box2CenterX = (-LineZoneRight + boxCollider2.size.x) / 2;
        boxCollider2.offset = new Vector3(box2CenterX, 0, 0);
       
    }
   

}


using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public int _Score;
    private int _BestScore;
    public Text ScoreText, ScoreText1, BestScoreText;
    public GameObject UIGameOver;
    public GameObject ZoneLine;
    public GameObject GroundCheck;
    public float smoothTime = 0.2F;
    private float yVelocity = 0.0F;
    public GameObject SpriteBall;

    void Start()
    {
        _BestScore = PlayerPrefs.GetInt("BestScore");
    }

    // Update is called once per frame
    void Update()
    {

        ScoreText.text = _Score.ToString();
        ScoreText1.text = _Score.ToString();
        if (_Score > _BestScore)
        {
            PlayerPrefs.SetInt("BestScore", _Score);
            PlayerPrefs.Save();
        }
        //Using acceleration
        float newPosition = Mathf.SmoothDamp(transform.position.x, Input.acceleration.x * 4f + transform.position.x, ref yVelocity, smoothTime);
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
        if (Input.acceleration.x > 0)
        {
            SpriteBall.transform.RotateAroundLocal(Vector3.back, 3.0f * Time.deltaTime);
        }
        else if (Input.acceleration.x < 0)
        {
            SpriteBall.transform.RotateAroundLocal(Vector3.forward, 3.0f * Time.deltaTime);
        }
        else if (Input.acceleration.x == 0)
        {
            SpriteBall.transform.rotation = Quaternion.identity;
        }
        //this.gameObject.GetComponent<Rigidbody2D>().AddTorque(-Input.acceleration.x + -Input.acceleration.x * 0.4f);
        //float step = speed * Time.deltaTime;
        //target.position = new Vector3(transform.position.x+ Input.acceleration.x * 4.0f, transform.position.y, transform.position.z);
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x -= 0.1f;
            this.transform.position = position;
            float tiltAroundZ = position.x;
            SpriteBall.transform.RotateAroundLocal(Vector3.forward, 3.0f * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x += 0.1f;
            this.transform.position = position;
            float tiltAroundZ = position.x;
            SpriteBall.transform.RotateAroundLocal(Vector3.back, 3.0f * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spike")
        {
            //Debug.Log("GameOver");
            Time.timeScale = 0;
            this.gameObject.active = false;
            UIGameOver.active = true;
            BestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
        }
        else if (col.gameObject.tag == "LineZone" || col.gameObject.tag == "WrapZone")
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8.5f, ForceMode2D.Impulse);
        }
        else if (col.gameObject.tag == "Wall")
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Col1")
        {
            _Score++;
            if (_Score > 6)
            GameController.Instance.CreateStairView2();
        }


    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "LineZone")
        {
            other.gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }


}

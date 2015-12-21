using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    Camera mainCamera;

    public GameObject StairObj, SpkieObj, UIHome;
    public Transform firstStair;
    public float dist = 0f;
    public GameObject ContainerObj;
    private GameObject ZoneObj;
    private float ZoneObjPosX;
    private float WrapZonePosX;
    private float WrapZonePosX1;
    private float SpikePos, SpikePos2, SpikePos3;
    private int _zoneNumber, numChild;
    List<GameObject> ZoneList = new List<GameObject>();
    //private float _firstStairt=-7.06f;
    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //StartCoroutine(SpawnStairsTask());
        SpawnStairsTask();
    }
    void Update()
    {
    }

    // Update is called once per frame
    public void CreateStairView()
    {
        ZoneObj = Instantiate(StairObj, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        ZoneObj.GetComponent<ZoneManager>().ZoneNumber = _zoneNumber;
        ZoneObj.transform.position = new Vector3(0, firstStair.transform.position.y + 2.2f * _zoneNumber, 0);
        ZoneObj.transform.parent = ContainerObj.transform;
        ZoneList.Add(ZoneObj);

        if (ZoneList.Count < 2)
        {
            ZoneObj.GetComponent<ZoneManager>().BeforeZone = ZoneList[ZoneObj.GetComponent<ZoneManager>().ZoneNumber - 1];
        }
        else if (ZoneList.Count >= 2)
        {
            ZoneObj.GetComponent<ZoneManager>().BeforeZone = ZoneList[ZoneObj.GetComponent<ZoneManager>().ZoneNumber - 2];
        }
    }
    /*IEnumerator*/
    private void SpawnStairsTask()
    {
        for (int i = 0; i <= 10; i++)
        {
            dist = dist + 2.2f;
            _zoneNumber = i + 1;
            CreateStairView();
            //yield return new WaitForSeconds(0.1f);
        }
    }
    public void CreateStairView2()
    {
        int numChild = ContainerObj.transform.childCount;
        //Debug.Log(ContainerObj.transform.GetChild(numChild - 1).GetComponent<ZoneManager>().ZoneNumber);
        ZoneObj = Instantiate(StairObj, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        ZoneObj.GetComponent<ZoneManager>().ZoneNumber = numChild;
        //Debug.Log(firstStair.transform.position.y);
        ZoneObj.transform.position = new Vector3(0, firstStair.transform.position.y + 2.2f * numChild, 0);
        ZoneObj.transform.parent = ContainerObj.transform;
        ZoneList.Add(ZoneObj);
        ZoneObj.GetComponent<ZoneManager>().BeforeZone = ZoneList[ZoneObj.GetComponent<ZoneManager>().ZoneNumber - 2];
    }

    public void OnReplayBtn()
    {
        Application.LoadLevel(0);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    public void OnHomeBtn()
    {
        Application.LoadLevel(0);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        UIHome.SetActive(true);
    }
    public void OnPlayBtn()
    {
        UIHome.SetActive(false);
    }
}

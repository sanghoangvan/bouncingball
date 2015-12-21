using UnityEngine;
using System.Collections;

public class ZoneManager : MonoBehaviour
{
    public int ZoneNumber;
    public GameObject SpikeObj, WrapZone, Wall;
    private float SpikePos, SpikePos11, SpikePos2, SpikePos22, SpikePos3;
    private float WrapZonePosX, WallPosX, WallPosX1;
    private float spikeOffsetY = 0.16f, offsetLeftAndRight = 0.5f;
    private Vector3 _screenPosition;
    private float _leftScreen, _rightScreen;
    public GameObject BeforeZone, SpikeBeforeZone;

 
    void Awake()
    {

        CheckEdgeScreen();
        WrapZone.transform.position = new Vector3(UnityEngine.Random.Range(_leftScreen + offsetLeftAndRight, _rightScreen - offsetLeftAndRight), WrapZone.transform.position.y, WrapZone.transform.position.z);
        WrapZonePosX = WrapZone.transform.position.x;



    }
    private void CheckEdgeScreen()
    {
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        _screenPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        _leftScreen = _screenPosition.x;
        _rightScreen = -_leftScreen;

    }
    void Start()
    {

        RandomSpikePos();
        if (ZoneNumber == 2)
        {
            RandomNumberSpike(UnityEngine.Random.Range(0, 2));
        }

        if (ZoneNumber > 2 && ZoneNumber <= 11)
        {
            if (ZoneNumber % 2 == 0)
                RandomNumberSpike(UnityEngine.Random.Range(0, 3));
            else
                RandomNumberSpike(3);
        }
        if (ZoneNumber > 11 && ZoneNumber <= 20)
        {
            if (ZoneNumber % 2 == 0)
                RandomNumberSpike(UnityEngine.Random.Range(4, 6));
            else
                RandomNumberSpike(UnityEngine.Random.Range(0, 4));
        }
        if (ZoneNumber > 20)
        {
            RandomNumberSpike(UnityEngine.Random.Range(3, 8));
        }

    }

    //Random Spike Position
    private void RandomSpikePos()
    {
        if (WrapZonePosX > 1.5f)
        {
            SpikePos = UnityEngine.Random.Range(_leftScreen + offsetLeftAndRight, WrapZonePosX - 1.0f);
            if (Mathf.Abs(_leftScreen) - Mathf.Abs(SpikePos) > Mathf.Abs(SpikePos) - Mathf.Abs(WrapZonePosX - 1.0f))
            {
                SpikePos11 = UnityEngine.Random.Range(_leftScreen + offsetLeftAndRight, SpikePos - 1.0f);
            }
            else
            {
                SpikePos11 = UnityEngine.Random.Range(SpikePos + 1.0f, WrapZonePosX - 1.0f);
            }
            SpikePos2 = UnityEngine.Random.Range(_leftScreen + offsetLeftAndRight, WrapZonePosX - 1.0f);
            if (Mathf.Abs(_leftScreen) - Mathf.Abs(SpikePos2) > Mathf.Abs(SpikePos2) - Mathf.Abs(WrapZonePosX - 1.0f))
            {
                SpikePos22 = UnityEngine.Random.Range(_leftScreen + offsetLeftAndRight, SpikePos - 1.0f);
            }
            else
            {
                SpikePos22 = UnityEngine.Random.Range(SpikePos + 1.0f, WrapZonePosX - 1.0f);
            }
        }
        else if (WrapZonePosX < -1.5f)
        {
            SpikePos = UnityEngine.Random.Range(WrapZonePosX + 1.0f, _rightScreen - offsetLeftAndRight);
            if (Mathf.Abs(_rightScreen) - Mathf.Abs(SpikePos) > Mathf.Abs(SpikePos) - Mathf.Abs(WrapZonePosX + 1.0f))
            {
                SpikePos11 = UnityEngine.Random.Range(_rightScreen - offsetLeftAndRight, SpikePos + 1.0f);
            }
            else
            {
                SpikePos11 = UnityEngine.Random.Range(WrapZonePosX + 1.0f, SpikePos - 1.0f);
            }
            SpikePos2 = UnityEngine.Random.Range(WrapZonePosX + 1.0f, _rightScreen - offsetLeftAndRight);
            if (Mathf.Abs(_rightScreen) - Mathf.Abs(SpikePos2) > Mathf.Abs(SpikePos2) - Mathf.Abs(WrapZonePosX + 1.0f))
            {
                SpikePos22 = UnityEngine.Random.Range(_rightScreen - offsetLeftAndRight, SpikePos + 1.0f);
            }
            else
            {
                SpikePos22 = UnityEngine.Random.Range(WrapZonePosX + 1.0f, SpikePos - 1.0f);
            }
        }
        else if (WrapZonePosX > -1.5f && WrapZonePosX < 1.5f)
        {
            float[] SpikePosX = { UnityEngine.Random.Range(_leftScreen + offsetLeftAndRight, WrapZonePosX - 1.0f), UnityEngine.Random.Range(WrapZonePosX + 1.0f, _rightScreen - offsetLeftAndRight) };
            float[] SpikePosX2 = { UnityEngine.Random.Range(_leftScreen + offsetLeftAndRight, WrapZonePosX - 1.0f), UnityEngine.Random.Range(WrapZonePosX + 1.0f, _rightScreen - offsetLeftAndRight) };
            int indexSpikePosX = UnityEngine.Random.Range(0, SpikePosX.Length);
            int indexSpikePosX2 = UnityEngine.Random.Range(0, SpikePosX2.Length);
            SpikePos = SpikePosX[indexSpikePosX];
            if (SpikePos < WrapZonePosX)
            {
                SpikePos11 = UnityEngine.Random.Range(WrapZonePosX + 1.0f, _rightScreen - offsetLeftAndRight);
            }
            else
            {
                SpikePos11 = UnityEngine.Random.Range(_leftScreen + offsetLeftAndRight, WrapZonePosX - 1.0f);
            }
            SpikePos2 = SpikePosX2[indexSpikePosX2];
            if (SpikePos2 < WrapZonePosX)
            {
                SpikePos22 = UnityEngine.Random.Range(WrapZonePosX + 1.0f, _rightScreen - offsetLeftAndRight);
            }
            else
            {
                SpikePos22 = UnityEngine.Random.Range(_leftScreen + offsetLeftAndRight, WrapZonePosX - 1.0f);
            }
        }

    }
    //Random NumberSpike
    private void RandomNumberSpike(int rdSpikePos)
    {
        if (rdSpikePos == 1)
        {
            GameObject spikeObj = Instantiate(SpikeObj, new Vector3(SpikePos, this.gameObject.transform.position.y + spikeOffsetY, this.gameObject.transform.position.z), Quaternion.identity) as GameObject;
            spikeObj.transform.parent = this.gameObject.transform;

        }
        else if (rdSpikePos == 2)
        {
            GameObject spikeObj = Instantiate(SpikeObj, new Vector3(SpikePos, this.gameObject.transform.position.y - spikeOffsetY, this.gameObject.transform.position.z), Quaternion.Euler(0, 0, 180)) as GameObject;
            spikeObj.transform.parent = this.gameObject.transform;
        }
        else if (rdSpikePos == 3)
        {
            GameObject spikeObj = Instantiate(SpikeObj, new Vector3(SpikePos, this.gameObject.transform.position.y + spikeOffsetY, this.gameObject.transform.position.z), Quaternion.identity) as GameObject;
            spikeObj.transform.parent = this.gameObject.transform;
            GameObject spikeObj2 = Instantiate(SpikeObj, new Vector3(SpikePos2, this.gameObject.transform.position.y - spikeOffsetY, this.gameObject.transform.position.z), Quaternion.Euler(0, 0, 180)) as GameObject;
            spikeObj2.transform.parent = this.gameObject.transform;
        }
        else if (rdSpikePos == 4)
        {
            GameObject spikeObj = Instantiate(SpikeObj, new Vector3(SpikePos, this.gameObject.transform.position.y + spikeOffsetY, this.gameObject.transform.position.z), Quaternion.identity) as GameObject;
            spikeObj.transform.parent = this.gameObject.transform;
            GameObject spikeObj2 = Instantiate(SpikeObj, new Vector3(SpikePos11, this.gameObject.transform.position.y + spikeOffsetY, this.gameObject.transform.position.z), Quaternion.identity) as GameObject;
            spikeObj2.transform.parent = this.gameObject.transform;
            GameObject spikeObj3 = Instantiate(SpikeObj, new Vector3(SpikePos2, this.gameObject.transform.position.y - spikeOffsetY, this.gameObject.transform.position.z), Quaternion.Euler(0, 0, 180)) as GameObject;
            spikeObj3.transform.parent = this.gameObject.transform;
        }
        else if (rdSpikePos == 5)
        {
            GameObject spikeObj = Instantiate(SpikeObj, new Vector3(SpikePos, this.gameObject.transform.position.y - spikeOffsetY, this.gameObject.transform.position.z), Quaternion.Euler(0, 0, 180)) as GameObject;
            spikeObj.transform.parent = this.gameObject.transform;
            GameObject spikeObj2 = Instantiate(SpikeObj, new Vector3(SpikePos11, this.gameObject.transform.position.y - spikeOffsetY, this.gameObject.transform.position.z), Quaternion.Euler(0, 0, 180)) as GameObject;
            spikeObj2.transform.parent = this.gameObject.transform;
            GameObject spikeObj3 = Instantiate(SpikeObj, new Vector3(SpikePos2, this.gameObject.transform.position.y + spikeOffsetY, this.gameObject.transform.position.z), Quaternion.identity) as GameObject;
            spikeObj3.transform.parent = this.gameObject.transform;
        }
        else if (rdSpikePos == 6)
        {
            GameObject spikeObj = Instantiate(SpikeObj, new Vector3(SpikePos, this.gameObject.transform.position.y + spikeOffsetY, this.gameObject.transform.position.z), Quaternion.identity) as GameObject;
            spikeObj.transform.parent = this.gameObject.transform;
            GameObject spikeObj2 = Instantiate(SpikeObj, new Vector3(SpikePos11, this.gameObject.transform.position.y + spikeOffsetY, this.gameObject.transform.position.z), Quaternion.identity) as GameObject;
            spikeObj2.transform.parent = this.gameObject.transform;
            GameObject spikeObj3 = Instantiate(SpikeObj, new Vector3(SpikePos2, this.gameObject.transform.position.y - spikeOffsetY, this.gameObject.transform.position.z), Quaternion.Euler(0, 0, 180)) as GameObject;
            spikeObj3.transform.parent = this.gameObject.transform;
            GameObject spikeObj4 = Instantiate(SpikeObj, new Vector3(SpikePos22, this.gameObject.transform.position.y - spikeOffsetY, this.gameObject.transform.position.z), Quaternion.Euler(0, 0, 180)) as GameObject;
            spikeObj4.transform.parent = this.gameObject.transform;
        }
        else if (rdSpikePos == 7)
        {
            GameObject spikeObj = Instantiate(SpikeObj, new Vector3(SpikePos, this.gameObject.transform.position.y - spikeOffsetY, this.gameObject.transform.position.z), Quaternion.Euler(0, 0, 180)) as GameObject;
            spikeObj.transform.parent = this.gameObject.transform;
            GameObject spikeObj2 = Instantiate(SpikeObj, new Vector3(SpikePos11, this.gameObject.transform.position.y - spikeOffsetY, this.gameObject.transform.position.z), Quaternion.Euler(0, 0, 180)) as GameObject;
            spikeObj2.transform.parent = this.gameObject.transform;
            GameObject spikeObj3 = Instantiate(SpikeObj, new Vector3(SpikePos2, this.gameObject.transform.position.y + spikeOffsetY, this.gameObject.transform.position.z), Quaternion.identity) as GameObject;
            spikeObj3.transform.parent = this.gameObject.transform;
            GameObject spikeObj4 = Instantiate(SpikeObj, new Vector3(SpikePos22, this.gameObject.transform.position.y + spikeOffsetY, this.gameObject.transform.position.z), Quaternion.identity) as GameObject;
            spikeObj4.transform.parent = this.gameObject.transform;
        }
    }
}

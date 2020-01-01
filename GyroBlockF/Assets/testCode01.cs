using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testCode01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        Input.compass.enabled = true;
    }
    /// <summary>
    /// Androidのジャイロを起動する
    /// </summary>
    public void gyroBoot()
    {

    }

    // Update is called once per frame
    void Update()
    {
        testCode();
    }
    #region TestCode
    /// <summary>
    /// ジャイロ値の返しを行います
    /// </summary>
    public void testCode()
    {
        //GetComponent<Text>().text = $"X:{Input.gyro.attitude.eulerAngles.x}, Y:{Input.gyro.attitude.eulerAngles.y}, Z:{Input.gyro.attitude.eulerAngles.z}";
    }
    public void testCode2(string data)
    {
        GetComponent<Text>().text = data;
    }
    #endregion
}

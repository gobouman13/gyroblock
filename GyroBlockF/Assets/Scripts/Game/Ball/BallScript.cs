/*
*モジュールＩＤ：Nor_Ball_01
*モジュール名称：ゲームプレイ時ボール挙動
*機能概要：ボールの重力、当たり判定、アクションを管理
*
*改訂履歴：2019/12/30 NorHum
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float ballGravity;
    public Vector2 ballSpeed;
    public bool switches;
    TouchPhase touch=new TouchPhase();
    // Start is called before the first frame update
    /// <summary>
    /// アプリケーション初期挙動の設定
    /// </summary>
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
        boundWall();      
    }
    public void move()
    {
        transform.position += new Vector3(ballSpeed.x, 0f, ballSpeed.y) * Time.deltaTime;
        bool touches = Input.touchCount>0;
        if (touches)
        {
            ballSpeed.y -= ballGravity * Time.deltaTime * 3f;
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            ballSpeed.y -= ballGravity * Time.deltaTime;
            GetComponent<Renderer>().material.color = Color.white;
        }
        

    }
    public void boundBar(GameObject Bar)
    {
        float num = -(ballSpeed.y / Mathf.Cos(Mathf.Deg2Rad * Bar.transform.localEulerAngles.y));
        Debug.Log(num);
        ballSpeed = new Vector2(Mathf.Sin(Mathf.Deg2Rad * Bar.transform.localEulerAngles.y), Mathf.Cos(Mathf.Deg2Rad * Bar.transform.localEulerAngles.y)) * num;
        //float deg = Vector2.Angle(Vector2.zero, ballSpeed);
        //ballSpeed = new Vector2(Mathf.Cos(Mathf.Deg2Rad * deg), Mathf.Sin(Mathf.Deg2Rad * deg));
    }
    public void boundWall()
    {
        Vector3 pos = transform.position;
        if (pos.x >= 5.1f || pos.x <= -5.1f)
        {
            transform.position = new Vector3(5.1f * (pos.x > 0f ? 1f : -1f), pos.y, pos.z);
            if (ballSpeed.x * pos.x > 0f)
            {
                ballSpeed.x *= -1f;
            }
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bar":
                boundBar(collision.gameObject);
                break;
        }
        
    }
}

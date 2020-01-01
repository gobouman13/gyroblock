using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Bar
{
    public class gameBarScript : MonoBehaviour
    {
        #region VARIABLE_NUMBER
            
            public int minSpeed;
            public float maxSpeed;
            public float rotWidth;
            public float speed;
            public int addSpeed;
            float nowRot;
            public float reboundSpeed,reboundSpeed2;
            public int reboundSwitch;
            public GameObject debugText;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            Input.gyro.enabled = true;
            Input.compass.enabled = true;
        }

        // Update is called once per frame
        void Update()
        {
            moveMaster();
        }
        #region MOVING_BASE
            public void moveMaster()
            {

                move_rotation();
                move_position();
                boundCheck();
            }
            public void move_rotation()
            {
                nowRot = -Input.gyro.attitude.eulerAngles.z;
                transform.localEulerAngles = new Vector3(0f, (nowRot)+90f,0f);

            }
            public void move_position()
            {
                
                speed = maxSpeed / rotWidth * (nowRot + 90f < -180f ? nowRot + 450f : nowRot + 90f) * Time.deltaTime;
                transform.position += new Vector3(speed, 0f, 0f);
            }
            public void boundCheck()
            {
                Vector3 pos = transform.position;
                if (pos.x >= 4.5f || pos.x <= -4.5f)
                {
                    transform.position = new Vector3(4.5f*(pos.x>0f?1f:-1f), pos.y, pos.z);
                }
            }
        #endregion
    }
}
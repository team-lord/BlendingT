﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    
    private GameObject player;
    private GameObject boss;

    //public float cameraX;
    //public float cameraY;
    public float cameraZ;

    private bool isWatchingPlayer;
    private bool isWatchingPlayerCenter;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        isWatchingPlayer = true;
        isWatchingPlayerCenter = false;
    }

    // Update is called once per frame
    /*
    void LateUpdate() {
        if (isWatchingPlayer) {
            Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
    }
    */

    void LateUpdate()
    {

        if (isWatchingPlayer)
        {
            if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17)
            {
                Debug.Log("11");
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y < -8)
            {
                Debug.Log("12");
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, player.transform.position.y + 4, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17)
            {
                Debug.Log("13");
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y >= 8)
            {
                Debug.Log("14");
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, player.transform.position.y - 4, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < -17)
            {
                Debug.Log("15");
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, -17, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > 17)
            {
                Debug.Log("16");
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, 17, cameraZ);
            }




            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x < -14 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17)
            {
                Debug.Log("21");
                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x < -14 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y < -8)
            {
                Debug.Log("22");
                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, player.transform.position.y + 4, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x < -14 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17)
            {
                Debug.Log("23");
                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x < -14 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y >= 8)
            {
                Debug.Log("24");
                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, player.transform.position.y - 4, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x < -14 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < -17)
            {
                Debug.Log("25");
                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, -17, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x < -14 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > 17)
            {
                Debug.Log("26");
                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, 17, cameraZ);
            }





            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x < 14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17)
            {
                Debug.Log("31");
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x < 14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y < -8)
            {
                Debug.Log("32");
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, player.transform.position.y + 4, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x < 14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17)
            {
                Debug.Log("33");
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x < 14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y >= 8)
            {
                Debug.Log("34");
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, player.transform.position.y - 4, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x < 14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < -17)
            {
                Debug.Log("35");
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, -17, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x < 14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > 17)
            {
                Debug.Log("36");
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, 17, cameraZ);
            }




            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x >= 14 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17)
            {
                Debug.Log("41");
                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x >= 14 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y < -8)
            {
                Debug.Log("42");
                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, player.transform.position.y + 4, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x >= 14 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17)
            {
                Debug.Log("43");
                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x >= 14 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y >= 8)
            {
                Debug.Log("44");
                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, player.transform.position.y - 4, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x >= 14 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < -17)
            {
                Debug.Log("45");
                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, -17, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x >= 14 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > 17)
            {
                Debug.Log("46");
                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, 17, cameraZ);
            }




            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < -18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17)
            {
                Debug.Log("51");
                Camera.main.transform.position = new Vector3(-18, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }


            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < -18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y < -8)
            {
                Debug.Log("52");
                Camera.main.transform.position = new Vector3(-18, player.transform.position.y + 4, cameraZ);
            }


            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < -18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17)
            {
                Debug.Log("53");
                Camera.main.transform.position = new Vector3(-18, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }


            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < -18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y >= 8)
            {
                Debug.Log("54");
                Camera.main.transform.position = new Vector3(-18, player.transform.position.y - 4, cameraZ);
            }


            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < -18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < -17)
            {
                Debug.Log("55");
                Camera.main.transform.position = new Vector3(-18, -17, cameraZ);
            }


            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < -18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > 17)
            {
                Debug.Log("56");
                Camera.main.transform.position = new Vector3(-18, 17, cameraZ);
            }




            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > 18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17)
            {
                Debug.Log("61");
                Camera.main.transform.position = new Vector3(18, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > 18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y < -8)
            {
                Debug.Log("62");
                Camera.main.transform.position = new Vector3(18, player.transform.position.y + 4, cameraZ);
            }

            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > 18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17)
            {
                Debug.Log("63");
                Camera.main.transform.position = new Vector3(18, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > 18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y >= 8)
            {
                Debug.Log("64");
                Camera.main.transform.position = new Vector3(18, player.transform.position.y - 4, cameraZ);
            }

            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > 18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < -17)
            {
                Debug.Log("65");
                Camera.main.transform.position = new Vector3(18, -17, cameraZ);
            }

            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > 18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > 17)
            {
                Debug.Log("66");
                Camera.main.transform.position = new Vector3(18, player.transform.position.y, cameraZ);
            }
        }

        else if (isWatchingPlayerCenter)
        {
            Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
    }

    public void IsWatchingPlayer(bool _bool) {
        isWatchingPlayer = _bool;
    }

    public void IsWatchingPlayerCenter(bool _bool)
    {
        isWatchingPlayerCenter = _bool;
    }
}

using System.Collections;
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
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y < -8)
            {
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, player.transform.position.y + 4, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17)
            {
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y >= 8)
            {
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, player.transform.position.y - 4, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < -17)
            {
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, -17, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > 17)
            {
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, 17, cameraZ);
            }




            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x < -14 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17)
            {
                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x < -14 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y < -8)
            {
                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, player.transform.position.y + 4, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x < -14 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17)
            {
                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x < -14 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y >= 8)
            {
                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, player.transform.position.y - 4, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x < -14 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < -17)
            {
                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, -17, cameraZ);
            }

            else if (boss.transform.position.x >= player.transform.position.x && player.transform.position.x - boss.transform.position.x < -14 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > 17)
            {
                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, 17, cameraZ);
            }





            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x < 14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17)
            {
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x < 14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y < -8)
            {
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, player.transform.position.y + 4, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x < 14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17)
            {
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x < 14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y >= 8)
            {
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, player.transform.position.y - 4, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x < 14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < -17)
            {
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, -17, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x < 14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < 18 && (player.transform.position.x + boss.transform.position.x) * 0.5 > -18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > 17)
            {
                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, 17, cameraZ);
            }




            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x >= 14 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17)
            {
                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x >= 14 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y < -8)
            {
                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, player.transform.position.y + 4, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x >= 14 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17)
            {
                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x >= 14 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y >= 8)
            {
                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, player.transform.position.y - 4, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x >= 14 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < -17)
            {
                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, -17, cameraZ);
            }

            else if (boss.transform.position.x < player.transform.position.x && player.transform.position.x - boss.transform.position.x >= 14 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > 17)
            {
                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, 17, cameraZ);
            }




            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < -18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17)
            {
                Camera.main.transform.position = new Vector3(-18, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }


            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < -18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y < -8)
            {
                Camera.main.transform.position = new Vector3(-18, player.transform.position.y + 4, cameraZ);
            }


            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < -18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17)
            {
                Camera.main.transform.position = new Vector3(-18, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }


            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < -18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y >= 8)
            {
                Camera.main.transform.position = new Vector3(-18, player.transform.position.y - 4, cameraZ);
            }


            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < -18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < -17)
            {
                Camera.main.transform.position = new Vector3(-18, -17, cameraZ);
            }


            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 < -18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > 17)
            {
                Camera.main.transform.position = new Vector3(-18, 17, cameraZ);
            }




            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > 18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17)
            {
                Camera.main.transform.position = new Vector3(18, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > 18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y < -8)
            {
                Camera.main.transform.position = new Vector3(18, player.transform.position.y + 4, cameraZ);
            }

            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > 18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < 17 && (player.transform.position.y + boss.transform.position.y) * 0.5 > -17)
            {
                Camera.main.transform.position = new Vector3(18, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
            }

            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > 18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y >= 8)
            {
                Camera.main.transform.position = new Vector3(18, player.transform.position.y - 4, cameraZ);
            }

            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > 18 && boss.transform.position.y >= player.transform.position.y && player.transform.position.y - boss.transform.position.y >= -8 && (player.transform.position.y + boss.transform.position.y) * 0.5 < -17)
            {
                Camera.main.transform.position = new Vector3(18, -17, cameraZ);
            }

            else if (player.transform.position.x - boss.transform.position.x <= 14 && player.transform.position.x - boss.transform.position.x >= -14 && (player.transform.position.x + boss.transform.position.x) * 0.5 > 18 && boss.transform.position.y < player.transform.position.y && player.transform.position.y - boss.transform.position.y < 8 && (player.transform.position.y + boss.transform.position.y) * 0.5 > 17)
            {
                Camera.main.transform.position = new Vector3(18, player.transform.position.y, cameraZ);
            }
        }

        else if (isWatchingPlayerCenter)
        {
            Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, cameraZ);
        }
    }

    public void IsWatchingPlayer(bool _bool) {
        isWatchingPlayer = _bool;
        if (isWatchingPlayer) {
            isWatchingPlayerCenter = false;
        }
    }

    public void IsWatchingPlayerCenter(bool _bool)
    {
        isWatchingPlayerCenter = _bool;
        if(isWatchingPlayerCenter) {
            isWatchingPlayer = false;
        }
    }
}

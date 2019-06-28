using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private GameObject player;
    private GameObject boss;

    //public float cameraX;
    //public float cameraY;
    public float cameraZ;

    private bool isWatchingPlayer;
    private bool isWatchingPlayerCenter;
    private bool isWatchingRight;

    // Start is called before the first frame update
    void Start()
    {
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

    /*
void LateUpdate()
{
    if (isWatchingPlayer)

        if (player.transform.position.x >= -20 && player.transform.position.x < 20)
        {
            if (player.transform.position.y >= -18 && player.transform.position.y < 18)
            {
                Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, cameraZ);
            }

            else if (player.transform.position.y < -18)
            {
                Camera.main.transform.position = new Vector3(player.transform.position.x, -18, cameraZ);
            }

            else
            {
                Camera.main.transform.position = new Vector3(player.transform.position.x, 18, cameraZ);
            }
        }

        else if (player.transform.position.x < -20)
        {
            if (player.transform.position.y >= -18 && player.transform.position.y < 18)
            {
                Camera.main.transform.position = new Vector3(-20, player.transform.position.y, cameraZ);
            }

            else if (player.transform.position.y < -18)
            {
                Camera.main.transform.position = new Vector3(-20, -18, cameraZ);
            }

            else
            {
                Camera.main.transform.position = new Vector3(-20, 18, cameraZ);
            }
        }

        else
        {
            if (player.transform.position.y >= -18 && player.transform.position.y < 18)
            {
                Camera.main.transform.position = new Vector3(20, player.transform.position.y, cameraZ);
            }

            else if (player.transform.position.y < -18)
            {
                Camera.main.transform.position = new Vector3(20, -18, cameraZ);
            }

            else
            {
                Camera.main.transform.position = new Vector3(20, 18, cameraZ);
            }
        }
}
*/
    private void LateUpdate()
    {
        if (isWatchingPlayer)
        {
            if (boss.transform.position.x >= player.transform.position.x)
            {//x1572
                if (boss.transform.position.y >= player.transform.position.y)
                {//y1572
                    if (player.transform.position.x - boss.transform.position.x >= -14)
                    {//x157
                        if (player.transform.position.y - boss.transform.position.y >= -8)
                        {//y157
                            if ((player.transform.position.x + boss.transform.position.x) * 0.5f > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5f < 18)
                            {//x1
                                if ((player.transform.position.y + boss.transform.position.y) * 0.5f >= -17 && (player.transform.position.y + boss.transform.position.y) * 0.5f < 17)
                                {
                                    //11
                                    Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
                                }

                                else if ((player.transform.position.y + boss.transform.position.y) * 0.5f < -17)
                                {
                                    //15
                                    Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, -17, cameraZ);
                                }

                                else
                                {
                                    //17
                                    Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, 17, cameraZ);
                                }
                            }
                            else if ((player.transform.position.x + boss.transform.position.x) * 0.5f < -18)
                            {//x5
                                if ((player.transform.position.y + boss.transform.position.y) * 0.5f >= -17 && (player.transform.position.y + boss.transform.position.y) * 0.5f < 17)
                                {
                                    //51
                                    Camera.main.transform.position = new Vector3(-18, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
                                }

                                else if ((player.transform.position.y + boss.transform.position.y) * 0.5f < -17)
                                {
                                    //55
                                    Camera.main.transform.position = new Vector3(-18, -17, cameraZ);
                                }

                                else
                                {
                                    //57
                                    Camera.main.transform.position = new Vector3(-18, 17, cameraZ);
                                }
                            }

                            else
                            {//x7
                                if ((player.transform.position.y + boss.transform.position.y) * 0.5f >= -17 && (player.transform.position.y + boss.transform.position.y) * 0.5f < 17)
                                {
                                    //71
                                    Camera.main.transform.position = new Vector3(18, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
                                }

                                else if ((player.transform.position.y + boss.transform.position.y) * 0.5f < -17)
                                {
                                    //75
                                    Camera.main.transform.position = new Vector3(18, -17, cameraZ);
                                }

                                else
                                {
                                    //77
                                    Camera.main.transform.position = new Vector3(18, 17, cameraZ);
                                }
                            }
                        }

                        else
                        {//y2
                            if ((player.transform.position.x + boss.transform.position.x) * 0.5f > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5f < 18)
                            {
                                //12
                                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, player.transform.position.y + 4, cameraZ);
                            }
                            else if ((player.transform.position.x + boss.transform.position.x) * 0.5f < -18)
                            {
                                //52
                                Camera.main.transform.position = new Vector3(-18, player.transform.position.y + 4, cameraZ);
                            }
                            else
                            {
                                //72
                                Camera.main.transform.position = new Vector3(18, player.transform.position.y + 4, cameraZ);
                            }

                        }
                    }

                    else
                    {//x2
                        if (player.transform.position.y - boss.transform.position.y >= -8)
                        {//y157
                            if ((player.transform.position.y + boss.transform.position.y) * 0.5f >= -17 && (player.transform.position.y + boss.transform.position.y) * 0.5f < 17)
                            {
                                //21
                                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
                            }

                            else if ((player.transform.position.y + boss.transform.position.y) * 0.5f < -17)
                            {
                                //25
                                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, -17, cameraZ);
                            }

                            else
                            {
                                //27
                                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, 17, cameraZ);
                            }
                        }

                        else
                        {//y2
                         //22
                            Camera.main.transform.position = new Vector3(player.transform.position.x + 7, player.transform.position.y + 4, cameraZ);
                        }
                    }
                }

                else
                {//y3684
                    if (player.transform.position.x - boss.transform.position.x >= -14)
                    {//x157
                        if (player.transform.position.y - boss.transform.position.y < 8)
                        {//y368
                            if ((player.transform.position.x + boss.transform.position.x) * 0.5f > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5f < 18)
                            {//x1
                                if ((player.transform.position.y + boss.transform.position.y) * 0.5f < 17 && (player.transform.position.y + boss.transform.position.y) * 0.5f >= -17)
                                {
                                    //13   
                                    Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
                                }

                                else if ((player.transform.position.y + boss.transform.position.y) * 0.5f < -17)
                                {
                                    //16
                                    Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, -17, cameraZ);
                                }

                                else
                                {
                                    //18
                                    Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, 17, cameraZ);
                                }
                            }
                            else if ((player.transform.position.x + boss.transform.position.x) * 0.5f < -18)
                            {//x5
                                if ((player.transform.position.y + boss.transform.position.y) * 0.5f < 17 && (player.transform.position.y + boss.transform.position.y) * 0.5f >= -17)
                                {
                                    //53
                                    Camera.main.transform.position = new Vector3(-18, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
                                }

                                else if ((player.transform.position.y + boss.transform.position.y) * 0.5f < -17)
                                {
                                    //56
                                    Camera.main.transform.position = new Vector3(-18, -17, cameraZ);
                                }

                                else
                                {
                                    //58
                                    Camera.main.transform.position = new Vector3(-18, 17, cameraZ);
                                }
                            }

                            else
                            {//x7
                                if ((player.transform.position.y + boss.transform.position.y) * 0.5f < 17 && (player.transform.position.y + boss.transform.position.y) * 0.5f >= -17)
                                {
                                    //73
                                    Camera.main.transform.position = new Vector3(18, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
                                }

                                else if ((player.transform.position.y + boss.transform.position.y) * 0.5f < -17)
                                {
                                    //76
                                    Camera.main.transform.position = new Vector3(18, -17, cameraZ);
                                }

                                else
                                {
                                    //78
                                    Camera.main.transform.position = new Vector3(18, 17, cameraZ);
                                }
                            }
                        }

                        else
                        {//y4
                            if ((player.transform.position.x + boss.transform.position.x) * 0.5f > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5f < 18)
                            {//x1
                             //14
                                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, player.transform.position.y - 4, cameraZ);
                            }
                            else if ((player.transform.position.x + boss.transform.position.x) * 0.5f < -18)
                            {//x5
                             //54
                                Camera.main.transform.position = new Vector3(-18, player.transform.position.y - 4, cameraZ);
                            }

                            else
                            {//x7
                             //74
                                Camera.main.transform.position = new Vector3(18, player.transform.position.y - 4, cameraZ);
                            }
                        }
                    }

                    else
                    {//x2
                        if (player.transform.position.y - boss.transform.position.y >= -8)
                        {//y368
                            if ((player.transform.position.y + boss.transform.position.y) * 0.5f < 17 && (player.transform.position.y + boss.transform.position.y) * 0.5f >= -17)
                            {
                                //23
                                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
                            }

                            else if ((player.transform.position.y + boss.transform.position.y) * 0.5f < -17)
                            {
                                //26
                                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, -17, cameraZ);
                            }

                            else
                            {
                                //28
                                Camera.main.transform.position = new Vector3(player.transform.position.x + 7, 17, cameraZ);
                            }
                        }

                        else
                        {//y4
                         //24
                            Camera.main.transform.position = new Vector3(player.transform.position.x + 7, player.transform.position.y - 4, cameraZ);
                        }
                    }
                }
            }

            else
            {//x3684
                if (boss.transform.position.y >= player.transform.position.y)
                {//y1572
                    if (player.transform.position.x - boss.transform.position.x < 14)
                    {//x368
                        if (player.transform.position.y - boss.transform.position.y >= -8)
                        {//y157
                            if ((player.transform.position.x + boss.transform.position.x) * 0.5f < 18 && (player.transform.position.x + boss.transform.position.x) * 0.5f > -18)
                            {//x3
                                if ((player.transform.position.y + boss.transform.position.y) * 0.5f >= -17 && (player.transform.position.y + boss.transform.position.y) * 0.5f < 17)
                                {
                                    //31
                                    Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
                                }

                                else if ((player.transform.position.y + boss.transform.position.y) * 0.5f < -17)
                                {
                                    //35
                                    Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, -17, cameraZ);
                                }

                                else
                                {
                                    //37
                                    Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, 17, cameraZ);
                                }
                            }

                            else if ((player.transform.position.x + boss.transform.position.x) * 0.5f < -18)
                            {//x6
                                if ((player.transform.position.y + boss.transform.position.y) * 0.5f >= -17 && (player.transform.position.y + boss.transform.position.y) * 0.5f < 17)
                                {
                                    //61
                                    Camera.main.transform.position = new Vector3(-18, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
                                }

                                else if ((player.transform.position.y + boss.transform.position.y) * 0.5f < -17)
                                {
                                    //65
                                    Camera.main.transform.position = new Vector3(-18, -17, cameraZ);
                                }

                                else
                                {
                                    //67
                                    Camera.main.transform.position = new Vector3(-18, 17, cameraZ);
                                }
                            }

                            else
                            {//x8
                                if ((player.transform.position.y + boss.transform.position.y) * 0.5f >= -17 && (player.transform.position.y + boss.transform.position.y) * 0.5f < 17)
                                {
                                    //81
                                    Camera.main.transform.position = new Vector3(18, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
                                }

                                else if ((player.transform.position.y + boss.transform.position.y) * 0.5f < -17)
                                {
                                    //85
                                    Camera.main.transform.position = new Vector3(18, -17, cameraZ);
                                }

                                else
                                {
                                    //87
                                    Camera.main.transform.position = new Vector3(18, 17, cameraZ);
                                }
                            }
                        }

                        else
                        {//y2
                            if ((player.transform.position.x + boss.transform.position.x) * 0.5f < 18 && (player.transform.position.x + boss.transform.position.x) * 0.5f > -18)
                            {//x3
                             //32
                                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, player.transform.position.y + 4, cameraZ);
                            }

                            else if ((player.transform.position.x + boss.transform.position.x) * 0.5f < -18)
                            {//x6
                             //62
                                Camera.main.transform.position = new Vector3(-18, player.transform.position.y + 4, cameraZ);
                            }

                            else
                            {//x8
                             //82
                                Camera.main.transform.position = new Vector3(18, player.transform.position.y + 4, cameraZ);
                            }
                        }

                    }

                    else
                    {//x4
                        if (player.transform.position.y - boss.transform.position.y >= -8)
                        {//y157
                            if ((player.transform.position.y + boss.transform.position.y) * 0.5f >= -17 && (player.transform.position.y + boss.transform.position.y) * 0.5f < 17)
                            {
                                //41
                                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
                            }

                            else if ((player.transform.position.y + boss.transform.position.y) * 0.5f < -17)
                            {
                                //45
                                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, -17, cameraZ);
                            }

                            else
                            {
                                //47
                                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, 17, cameraZ);
                            }
                        }

                        else
                        {//y2
                         //42
                            Camera.main.transform.position = new Vector3(player.transform.position.x - 7, player.transform.position.y + 4, cameraZ);
                        }
                    }
                }

                else
                {//y3684
                    if (player.transform.position.x - boss.transform.position.x < 14)
                    {//x368
                        if (player.transform.position.y - boss.transform.position.y < 8)
                        {//y368
                            if ((player.transform.position.x + boss.transform.position.x) * 0.5f > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5f < 18)
                            {//x3
                                if ((player.transform.position.y + boss.transform.position.y) * 0.5f >= -17 && (player.transform.position.y + boss.transform.position.y) * 0.5f < 17)
                                {
                                    //33
                                    Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
                                }

                                else if ((player.transform.position.y + boss.transform.position.y) * 0.5f < -17)
                                {
                                    //36
                                    Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, -17, cameraZ);
                                }

                                else
                                {
                                    //38
                                    Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, 17, cameraZ);
                                }
                            }
                            else if ((player.transform.position.x + boss.transform.position.x) * 0.5f < -18)
                            {//x6
                                if ((player.transform.position.y + boss.transform.position.y) * 0.5f >= -17 && (player.transform.position.y + boss.transform.position.y) * 0.5f < 17)
                                {
                                    //63
                                    Camera.main.transform.position = new Vector3(-18, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
                                }

                                else if ((player.transform.position.y + boss.transform.position.y) * 0.5f < -17)
                                {
                                    //66
                                    Camera.main.transform.position = new Vector3(-18, -17, cameraZ);
                                }

                                else
                                {
                                    //68
                                    Camera.main.transform.position = new Vector3(-18, 17, cameraZ);
                                }
                            }

                            else
                            {//x8
                                if ((player.transform.position.y + boss.transform.position.y) * 0.5f >= -17 && (player.transform.position.y + boss.transform.position.y) * 0.5f < 17)
                                {
                                    //83
                                    Camera.main.transform.position = new Vector3(18, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
                                }

                                else if ((player.transform.position.y + boss.transform.position.y) * 0.5f < -17)
                                {
                                    //86
                                    Camera.main.transform.position = new Vector3(18, -17, cameraZ);
                                }

                                else
                                {
                                    //88
                                    Camera.main.transform.position = new Vector3(18, 17, cameraZ);
                                }
                            }
                        }

                        else
                        {//y4
                            if ((player.transform.position.x + boss.transform.position.x) * 0.5f > -18 && (player.transform.position.x + boss.transform.position.x) * 0.5f < 18)
                            {
                                //34
                                Camera.main.transform.position = new Vector3((player.transform.position.x + boss.transform.position.x) * 0.5f, player.transform.position.y - 4, cameraZ);
                            }

                            else if ((player.transform.position.x + boss.transform.position.x) * 0.5f < -18)
                            {
                                //64
                                Camera.main.transform.position = new Vector3(-18, player.transform.position.y - 4, cameraZ);
                            }

                            else
                            {
                                //84
                                Camera.main.transform.position = new Vector3(18, player.transform.position.y - 4, cameraZ);
                            }
                        }
                    }

                    else
                    {//x4
                        if (player.transform.position.y - boss.transform.position.y < 8)
                        {//y368
                            if ((player.transform.position.y + boss.transform.position.y) * 0.5f >= -17 && (player.transform.position.y + boss.transform.position.y) * 0.5f < 17)
                            {
                                //43
                                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, (player.transform.position.y + boss.transform.position.y) * 0.5f, cameraZ);
                            }

                            else if ((player.transform.position.y + boss.transform.position.y) * 0.5f < -17)
                            {
                                //46
                                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, -17, cameraZ);
                            }

                            else
                            {
                                //48
                                Camera.main.transform.position = new Vector3(player.transform.position.x - 7, 17, cameraZ);
                            }
                        }

                        else
                        {//y4
                         //44
                            Camera.main.transform.position = new Vector3(player.transform.position.x - 7, player.transform.position.y - 4, cameraZ);
                        }
                    }
                }
            }
        }

        else if (isWatchingPlayerCenter)
        {
            if (player.transform.position.x >= -20 && player.transform.position.x < 20)
            {
                if (player.transform.position.y >= -18 && player.transform.position.y < 18)
                {
                    Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, cameraZ);
                }

                else if (player.transform.position.y < -18)
                {
                    Camera.main.transform.position = new Vector3(player.transform.position.x, -18, cameraZ);
                }

                else
                {
                    Camera.main.transform.position = new Vector3(player.transform.position.x, 18, cameraZ);
                }
            }

            else if (player.transform.position.x < -20)
            {
                if (player.transform.position.y >= -18 && player.transform.position.y < 18)
                {
                    Camera.main.transform.position = new Vector3(-20, player.transform.position.y, cameraZ);
                }

                else if (player.transform.position.y < -18)
                {
                    Camera.main.transform.position = new Vector3(-20, -18, cameraZ);
                }

                else
                {
                    Camera.main.transform.position = new Vector3(-20, 18, cameraZ);
                }
            }

            else
            {
                if (player.transform.position.y >= -18 && player.transform.position.y < 18)
                {
                    Camera.main.transform.position = new Vector3(20, player.transform.position.y, cameraZ);
                }

                else if (player.transform.position.y < -18)
                {
                    Camera.main.transform.position = new Vector3(20, -18, cameraZ);
                }

                else
                {
                    Camera.main.transform.position = new Vector3(player.transform.position.x, 18, cameraZ);
                }
            }
        }

        else if (isWatchingRight)
        {
            Camera.main.transform.position = new Vector3(18, 0, cameraZ);
        }

    }

    public void IsWatchingPlayer(bool _bool)
    {
        isWatchingPlayer = _bool;
        if (isWatchingPlayer)
        {
            isWatchingPlayerCenter = false;
        }
    }

    public void IsWatchingPlayerCenter(bool _bool)
    {
        isWatchingPlayerCenter = _bool;
        if (isWatchingPlayerCenter)
        {
            isWatchingPlayer = false;
        }
    }
}
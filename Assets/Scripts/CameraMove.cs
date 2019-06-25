using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    
    private GameObject player;

    private bool isWatchingPlayer;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");

        isWatchingPlayer = true;
    }

    // Update is called once per frame
    void LateUpdate() { // LateUpdate 한번 써봤음
        if (isWatchingPlayer) {
            Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
    }

    public void IsWatchingPlayer(bool _bool) {
        isWatchingPlayer = _bool;
        Debug.Log(_bool);
    }
}

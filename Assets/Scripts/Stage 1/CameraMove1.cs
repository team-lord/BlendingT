using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove1 : MonoBehaviour
{
    private GameObject puzzleBall1st;
    private GameObject billiardTable;
    private GameObject puzzleBall2nd;

    private bool watchPuzzleBall1st;
    private bool watchPuzzleBall2nd;

    // Start is called before the first frame update
    void Start()
    {
        puzzleBall1st = GameObject.Find("PuzzleBall");
        billiardTable = GameObject.Find("BilliardTable");
        puzzleBall2nd = GameObject.Find("2ndPuzzleBall");

        watchPuzzleBall1st = false;
        watchPuzzleBall2nd = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (watchPuzzleBall1st) {
            transform.position = puzzleBall1st.transform.position + new Vector3(0, 0, -10);
        } else if (watchPuzzleBall2nd) {
            // if(puzzleBall2nd.activeSelf)
            transform.position = puzzleBall2nd.transform.position + new Vector3(0, 0, -10);
        }
    }

    public void WatchPuzzleBall1st() {
        GetComponent<CameraMove>().IsWatchingPlayer(false);
        watchPuzzleBall1st = true;
        watchPuzzleBall2nd = false;
    }

    public void WatchBilliardTable() {
        watchPuzzleBall1st = false;
        transform.position = new Vector3(billiardTable.transform.position.x, 8, -10);
        watchPuzzleBall2nd = false;
    }

    public void WatchPuzzleBall2nd() {
        watchPuzzleBall1st = false;
        watchPuzzleBall2nd = true;
    }

    public void WatchPlayer() {
        watchPuzzleBall1st = false;
        watchPuzzleBall2nd = false;
        GetComponent<CameraMove>().IsWatchingPlayer(true);        
    }
}

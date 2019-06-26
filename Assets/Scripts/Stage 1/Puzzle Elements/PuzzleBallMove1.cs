using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBallMove1 : MonoBehaviour {

    private GameObject[] puzzleBall = new GameObject [2];
    private Vector3[] localPosition = new Vector3 [2];

    private GameObject puzzleButton;
    private GameObject audienceManager;
    private GameObject billiardTable;
    private GameObject phonograph;
    private GameObject motorFan;

    private GameObject player;

    // Start is called before the first frame update
    void Start() {

        puzzleBall[0] = GameObject.Find("PuzzleBall");
        puzzleBall[1] = GameObject.Find("2ndPuzzleBall");

        localPosition[0] = puzzleBall[0].transform.localPosition;
        localPosition[1] = puzzleBall[1].transform.localPosition;

        puzzleButton = GameObject.Find("PuzzleButton");
        audienceManager = GameObject.Find("AudienceManager");
        billiardTable = GameObject.Find("BilliardTable");
        phonograph = GameObject.Find("Phonograph");
        motorFan = GameObject.Find("MotorFan");

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {

    }

    void PuzzleComplete() {
        audienceManager.GetComponent<AudienceManager1>().PuzzleComplete();
    }
    
    public void Initialize() {
        billiardTable.GetComponent<BilliardTable1>().Initialize();
        puzzleButton.GetComponent<PuzzleStartButton1>().Initialize();
        for(int i=0; i<2; i++) {
            puzzleBall[i].transform.localPosition = localPosition[i];
            puzzleBall[i].transform.rotation = Quaternion.identity;
            puzzleBall[i].GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            puzzleBall[i].GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
        player.GetComponent<MoveTumbleP1>().CanMoveTumble1(true);
        player.GetComponent<AttackFireP1>().CanAttackFire(true);
        Camera.main.GetComponent<CameraMove1>().WatchPlayerCenter();
    }
                    
    public void PuzzleFail() {
        // 반짝거리는 애니메이션 시작
        StartCoroutine(WaitPuzzleFail());
    }

    IEnumerator WaitPuzzleFail() {
        yield return new WaitForSeconds(1f);
        Initialize();
    }
}

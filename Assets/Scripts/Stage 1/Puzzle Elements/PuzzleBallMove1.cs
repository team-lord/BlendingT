using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBallMove1 : MonoBehaviour {

    private Vector3 localPosition;

    private GameObject audienceManager;
    private GameObject billiardTable;
    private GameObject phonograph;
    private GameObject motorFan;

    // Start is called before the first frame update
    void Start() {
        localPosition = transform.localPosition;
        
        audienceManager = GameObject.Find("AudienceManager");
        billiardTable = GameObject.Find("BilliardTable");
        phonograph = GameObject.Find("Phonograph");
        motorFan = GameObject.Find("MotorFan");
    }

    // Update is called once per frame
    void Update() {

    }

    void PuzzleComplete() {
        audienceManager.GetComponent<AudienceManager>().PuzzleComplete();
    }
    
    public void Initialize() {
        billiardTable.GetComponent<BilliardTable1>().Initialize();
        transform.localPosition = localPosition;
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

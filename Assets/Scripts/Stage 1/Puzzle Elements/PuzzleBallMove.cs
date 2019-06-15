using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBallMove : MonoBehaviour {
    private Vector3 direction;
    public float moveSpeed;

    private GameObject audienceManager;

    private GameObject billiardTable;
    private GameObject phonograph;
    private GameObject motorFan;

    // Start is called before the first frame update
    void Start() {
        direction = Vector3.zero;

        audienceManager = GameObject.Find("AudienceManager");
        billiardTable = GameObject.Find("BilliardTable");
        phonograph = GameObject.Find("Phonograph");
        motorFan = GameObject.Find("motorFan");
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Move() {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    public void Direction(Vector3 _direction) {
        direction = _direction;
        direction.Normalize();
    }

    public void SpeedIncrease(float _float) {
        moveSpeed += _float;
    }

    void PuzzleComplete() {
        audienceManager.GetComponent<AudienceManager>().PuzzleComplete();
    }
    
    public void Initialize() {
        billiardTable.GetComponent<BilliardTable>().Initialize();
    }
}

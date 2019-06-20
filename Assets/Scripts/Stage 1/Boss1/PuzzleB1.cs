using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleB1 : MonoBehaviour
{
    private bool isPuzzlePhase;

    private GameObject audienceManager;

    private float time;
    public float deductionDelay;

    private bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        isPuzzlePhase = false;
        isReady = true;

        audienceManager = GameObject.Find("AudienceManager");
        time = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (isPuzzlePhase) {
            if (isReady) {
                isReady = false;
                GameObject.Find("Puzzle").transform.Translate(new Vector3(-60, 0, 0));
            }
            time += Time.deltaTime;
            if(time > deductionDelay) {
                time = 0;
                audienceManager.GetComponent<AudienceManager1>().PuzzlePhase();
            }
        }
    }

    public void IsPuzzlePhase(bool _bool) {
        isPuzzlePhase = _bool;
    }
}

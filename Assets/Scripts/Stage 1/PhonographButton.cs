using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhonographButton : MonoBehaviour
{
    public int numberQ; // answer = 3;

    private GameObject puzzleManager;
    private bool isReady;

    public float cooltimeQ;

    // Start is called before the first frame update
    void Start()
    {
        puzzleManager = GameObject.Find("PuzzleManager");
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (isReady) {
            if (collider.tag=="PlayerMelee") {
                StartCoroutine(Wait(cooltimeQ));

                puzzleManager.GetComponent<PuzzleManager>().isPhonographOn = true;
                GetComponentInParent<Phonograph>().isPhonographOn = true;

                puzzleManager.GetComponent<PuzzleManager>().phonographNumber = numberQ;
                // 버튼 색깔 바꾸세용
            }
        }
    }

    IEnumerator Wait(float time) {
        isReady = false;
        yield return new WaitForSeconds(time);
        isReady = true;
    }
}

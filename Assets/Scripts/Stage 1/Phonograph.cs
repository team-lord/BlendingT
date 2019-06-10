using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phonograph : MonoBehaviour
{
    public bool isPhonographOn;

    public int currentNumber; // 0, 1, 2, -1:Off

    private GameObject puzzleManager;
    public GameObject[] buttonsQ = new GameObject[3];

    public Sprite[] spritesQ = new Sprite[4];
    private int spriteNumber; // 0 -> 1 -> 2 -> 3 -> 0

    private bool isReady;
    public float delayQ;

    // Start is called before the first frame update
    void Start()
    {
        isPhonographOn = false;

        spritesQ[0] = GetComponent<SpriteRenderer>().sprite;
        puzzleManager = GameObject.Find("PuzzleManager");

        spriteNumber = 0;

        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPhonographOn) {
            Dance();
        }
        
    }

    public void Change(int number) {
        if (isReady) {
            StartCoroutine(WaitChange(delayQ));
            if (currentNumber == number) {
                isPhonographOn = false;
                puzzleManager.GetComponent<PuzzleManager>().isPhonographOn = false;
                buttonsQ[currentNumber].GetComponent<PhonographButton>().TurnOff();
                currentNumber = -1;
            } else {
                isPhonographOn = true;
                puzzleManager.GetComponent<PuzzleManager>().isPhonographOn = true;
                buttonsQ[currentNumber].GetComponent<PhonographButton>().TurnOff();
                currentNumber = number;
            }
        }
    }

    IEnumerator WaitChange(float time) {
        isReady = false;
        yield return new WaitForSeconds(time);
        isReady = true;
    }

    void Dance() {
        if(spriteNumber < 3) {
            spriteNumber++;
        } else {
            spriteNumber = 0; // 3 -> 0
        }
        GetComponent<SpriteRenderer>().sprite = spritesQ[spriteNumber];
        // 애니메이션으로 들썩들썩 구현
    }
}

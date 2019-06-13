using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phonograph : MonoBehaviour
{
    private bool isPhonographOn;

    public int currentNumber; // 0, 1, 2, -1:Off

    private GameObject puzzleManager;
    public GameObject[] buttonsQ = new GameObject[3];

    public Sprite[] spritesQ = new Sprite[4];
    private int spriteNumber; // 0 -> 1 -> 2 -> 3 -> 0

    private bool isReady;
    public float delayQ;

    private float time;
    public float animationDelayQ;

    // Start is called before the first frame update
    void Start()
    {
        isPhonographOn = false;

        spritesQ[0] = GetComponent<SpriteRenderer>().sprite;
        puzzleManager = GameObject.Find("PuzzleManager");

        spriteNumber = 0;

        isReady = true;

        time = 0;
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
            if (currentNumber == number) { // 켜져 있는 버튼을 눌러 끄기
                isPhonographOn = false;
                buttonsQ[currentNumber].GetComponent<PhonographButton>().TurnOff();
                currentNumber = -1;
            } else { // 다른 버튼을 눌러 버튼을 바꾸기
                isPhonographOn = true;
                buttonsQ[number].GetComponent<PhonographButton>().TurnOn();
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
        time += Time.deltaTime;
        if (time > animationDelayQ) {
            time = 0;
            if (spriteNumber < 3) {
                spriteNumber++;
            } else {
                spriteNumber = 0; // 3 -> 0
            }
            GetComponent<SpriteRenderer>().sprite = spritesQ[spriteNumber];
        }
        
    }

    public int CurrentButton() {
        if (isPhonographOn) {
            return currentNumber;
        } else {
            return -1; // isPhonographOn = false;
        }
    }
}

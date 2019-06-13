using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phonograph : MonoBehaviour
{
    private GameObject dolls;

    private bool isPhonographOn;

    public int currentNumber; // 0, 1, 2, -1: Off
    
    public GameObject[] buttons = new GameObject[3];

    private bool isReady;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        dolls = GameObject.Find("Dolls");

        isPhonographOn = false;

        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Change(int number) {
        if (isReady) {
            StartCoroutine(Wait());
            if (currentNumber == number) { // 켜져 있는 버튼을 눌러 끄기
                isPhonographOn = false;
                // TODO - 애니메이션 종료
                buttons[currentNumber].GetComponent<PhonographButton>().TurnOff();
                currentNumber = -1;
            } else { // 다른 버튼을 눌러 버튼을 바꾸기
                isPhonographOn = true;
                // TODO - 들썩거리는 애니메이션 시작 (끝 없음. 계속 반복)
                buttons[number].GetComponent<PhonographButton>().TurnOn();
                buttons[currentNumber].GetComponent<PhonographButton>().TurnOff();
                currentNumber = number;
            }
        }
    }

    IEnumerator Wait() {
        isReady = false;
        yield return new WaitForSeconds(delay);
        isReady = true;
    }
       
}

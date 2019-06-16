using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phonograph1 : MonoBehaviour
{
    private GameObject dolls;

    private int currentNumber; // 0, 1, 2, 3: Off
    
    public GameObject[] buttons = new GameObject[3];

    private bool isReady;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        dolls = GameObject.Find("Dolls");

        currentNumber = 3;

        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Change(int number) {
        if (isReady) {
            StartCoroutine(IsReady());
            if (currentNumber == number) { // 켜져 있는 버튼을 눌러 끄기
                // TODO - 애니메이션 종료
                buttons[currentNumber].GetComponent<PhonographButton1>().TurnOff();
                currentNumber = 3;
            } else { // 다른 버튼을 눌러 버튼을 바꾸기
                // TODO - 들썩거리는 애니메이션 시작 (끝 없음. 계속 반복)
                buttons[number].GetComponent<PhonographButton1>().TurnOn();
                if(currentNumber < 3) {
                    buttons[currentNumber].GetComponent<PhonographButton1>().TurnOff();
                }
                currentNumber = number;
            }

            dolls.GetComponent<Dolls1>().TargetDoll(number);

        }
    }

    IEnumerator IsReady() {
        isReady = false;
        yield return new WaitForSeconds(delay);
        isReady = true;
    }
       
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankMachine : MonoBehaviour
{
    private int currentPlank; // 0:Rubber, 1:Wood, 2:Ice

    private bool isReady;
    public float delayQ;

    public GameObject leftButtonQ;
    public GameObject rightButtonQ;

    // Start is called before the first frame update
    void Start()
    {
        currentPlank = 0;
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeNext() { // 0 -> 1 -> 2 -> 0
        if (isReady) {
            StartCoroutine(Change(delayQ));
            if(currentPlank < 2) {
                currentPlank++;
            } else {
                currentPlank = 0;
            }
            // 다음 판 불러오는 애니메이션
            rightButtonQ.GetComponent<PlankMachineButton>().ChangeSprite();
        }
    }

    public void ChangePrevious() { // 2 -> 1 -> 0 -> 2
        if (isReady) {
            StartCoroutine(Change(delayQ));
            if(currentPlank > 0) {
                currentPlank--;
            } else {
                currentPlank = 2;
            }
            // 이전 판 불러오는 애니메이션
            leftButtonQ.GetComponent<PlankMachineButton>().ChangeSprite();
        }
    }

    IEnumerator Change(float time) {
        isReady = false;
        yield return new WaitForSeconds(time);
        isReady = true;
    }

    public int CurrentPlank() {
        return currentPlank;
    }
}

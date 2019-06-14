using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolls : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[3]; // 애니메이션이 끝나면 sprite 바꾸기

    private Sprite offSprite;

    private bool isReady;

    private int currentDoll;
    private int targetDoll;

    // Start is called before the first frame update
    void Start()
    {
        offSprite = GetComponent<SpriteRenderer>().sprite;

        isReady = false;

        currentDoll = 3;
        targetDoll = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady) {
            if (currentDoll == targetDoll) {
                // TODO - targetDoll이 내려가는 애니메이션 시작
                currentDoll = 3;
            } else {
                if (currentDoll == 3) {
                    // TODO - targetDoll이 올라가는 애니메이션 시작
                } else {
                    // TODO - currentDoll이 내려가고 targetDoll이 올라가는 애니메이션 시작
                }
                currentDoll = targetDoll;
            }
            isReady = false;
        }
    }
    
    public void TargetDoll(int number) {
        isReady = true;
        targetDoll = number;
    }
}

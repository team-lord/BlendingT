using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour
{
    public GameObject sunflower;
    private GameObject puzzleManager;

    public bool bulbPulse;
    private bool isBulbOn;

    // Start is called before the first frame update
    void Start()
    {
        bulbPulse = false;
        isBulbOn = false;

        puzzleManager = GameObject.Find("puzzleManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(bulbPulse && !isBulbOn) {
            isBulbOn = true;
            bulbPulse = false;
            puzzleManager.GetComponent<PuzzleManager>().isBulbOn = true;
            // 전구에 불 켜지는 애니메이션 or light처리
        } else if (bulbPulse && isBulbOn){
            isBulbOn = false;
            bulbPulse = false;
            puzzleManager.GetComponent<PuzzleManager>().isBulbOn = false;
            // 전구에 불 꺼지는 애니메이션 or light처리
        }

    }
        
}

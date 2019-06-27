using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience1 : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[5];

    private int previousStep;
    private int currentStep;
    
    // Start is called before the first frame update
    void Start()
    {
        previousStep = 1;
        currentStep = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreChange(int step) {
        currentStep = step;
        if(currentStep != previousStep) {
            switch (currentStep) {
                case 0:
                    // TODO - 야유
                    break;
                case 1:
                    // TODO - 수군수군
                    break;
                case 2:
                    // TODO - 환호
                    break;
                case 3:
                    // TODO - 환호
                    break;
                case 4:
                    // TODO - 박수갈채
                    break;
                default:
                    break;
            }
            GetComponent<SpriteRenderer>().sprite = sprites[step];
        }
        previousStep = currentStep;
    }
}

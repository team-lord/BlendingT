using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeLevers : MonoBehaviour
{
    public GameObject[] fakeLevers = new GameObject[11];

    private int currentLever; // 11: all off

    // Start is called before the first frame update
    void Start()
    {
        currentLever = 11;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change(int number) {
        if (number == currentLever) {
            currentLever = 11;
        } else {
            fakeLevers[currentLever].GetComponent<FakeLever>().TurnOff();
            currentLever = number;
        }
    }
}

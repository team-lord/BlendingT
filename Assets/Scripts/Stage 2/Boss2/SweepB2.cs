using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepB2 : MonoBehaviour
{
    // 애니메이션 전용

    private GameObject boss;
    private GameObject player;
    
    // Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Sweep() {
        // TODO - 애니메이션 시작
       
    }
}

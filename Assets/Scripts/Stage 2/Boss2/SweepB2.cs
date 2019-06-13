using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepB2 : MonoBehaviour
{
    // 애니메이션 전용

    private GameObject boss;
    private GameObject player;

    private Vector3[] baseDirections = new Vector3[8];

    private bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        player = GameObject.Find("Player");



        isReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            Vector3 _movement;
            _movement = boss.GetComponent<MoveB2>().GiveDirection();
            AnimationStart(_movement);
        }
    }
    
    void AnimationStart(Vector3 movement)
    {
        
    }

    public void Sweep() {
        // TODO - 애니메이션 시작
        isReady = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1Maker2 : MonoBehaviour
{
    public GameObject bullet1;

    public int repetition;
    private int count;
    public float delay;
    private float time;

    private GameObject player;
    private GameObject boss;

    Animator animator;

    // Start is called before the first frame update
    void Start() {
        count = 0;
        time = 0;

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        animator = boss.GetComponent<Animator>();
        animator.SetBool("spin", true);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        if(time > delay) {
            int _random = Random.Range(0, 60);
            for (int i=0; i<6; i++) {
                Fire(_random + 60 * i);
            }

            time = 0;
            count++;
            CheckDestroy();
        }
    }

    void Fire(int degree) {
        Instantiate(bullet1, transform.position, Quaternion.Euler(new Vector3(0, 0, degree)));
    }

    void CheckDestroy() {
        if (count >= repetition) {
            boss.GetComponent<PatternB2>().PatternEnd();
            Destroy(gameObject);
            animator.SetBool("spin", false);
        }
    }
}

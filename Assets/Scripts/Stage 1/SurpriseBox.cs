using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseBox : MonoBehaviour
{
    // TODO

    public GameObject bullet2;

    public float delay;
    private float time;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        animator = GetComponent<Animator>();
        // TODO - 등장 애니메이션 시작
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;

        if (time > delay) {
            time = 0;
            animator.SetTrigger("attack");
            for (int i = 0; i < 6; i++) {
                Fire(60 * i);
            }
        }
    }

    void Fire(int degree) {
        Instantiate(bullet2, transform.position, Quaternion.Euler(new Vector3(0, 0, degree)));
    }
}

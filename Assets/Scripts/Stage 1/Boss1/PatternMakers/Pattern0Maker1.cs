using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern0Maker1 : MonoBehaviour
{
    public GameObject[] bullet0s = new GameObject[4];
    private GameObject bullet;

    public int repetition;
    private int count;
    public float delay;
    private float time;

    private GameObject player;
    private GameObject boss;

    Animator animator;
    private Vector3 playerDirection;

    public AudioClip cardFireSound;
    private AudioSource bossAudio;

    // Start is called before the first frame update
    void Start() {
        count = 0;
        time = 0;

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        animator = boss.GetComponent<Animator>();
        bossAudio = boss.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        playerDirection = (player.transform.position - transform.position).normalized;
        animator.SetFloat("cardDirectionX", playerDirection.x);
        animator.SetFloat("cardDirectionY", playerDirection.y);

        if (time > delay) {
            
            // 카드 던지는 애니메이션 시작
            for(int i=0; i<9; i++) {
                bullet = bullet0s[Random.Range(0, bullet0s.Length)];

                Fire(bullet, -40 + 10 * i);
            }
            animator.SetTrigger("cardFire");
            bossAudio.PlayOneShot(cardFireSound);

            time = 0;
            count++;
            CheckDestroy();
        }
    }

    void Fire(GameObject bullet, float degree) {
        Vector3 _direction = (player.transform.position - transform.position).normalized;

        Quaternion _rotation = Quaternion.Euler(0, 0, degree);
        Vector3 _newDirection = _rotation * _direction;

        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, _newDirection));
    }

    void CheckDestroy() {
        if (count >= repetition) {
            boss.GetComponent<PatternB1>().PatternEnd();
            Destroy(gameObject);
        }
    }

}

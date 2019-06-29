using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlanket1 : MonoBehaviour
{
    public GameObject blanket;

    private GameObject boss;
    private GameObject player;

    Animator animator;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        player = GameObject.Find("Player");

        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "PuzzleBall") {

            Destroy(collision.gameObject);

            animator.SetTrigger("explode");
            audio.Play();


            // PuzzleBall이 깨지는 애니메이션 시작
            // 이후 PuzzleBall Destroy.

            Instantiate(blanket, transform.position, Quaternion.identity);

            GameObject.Find("Puzzle").transform.position = new Vector3(64, 0, 0);

            GameObject.Find("AudienceManager").GetComponent<AudienceManager1>().PuzzleComplete();

            StartCoroutine(Phase2());

            
        }
    }

    IEnumerator Phase2() {
        yield return new WaitForSeconds(2f);
        boss.GetComponent<PhaseB1>().Phase2();
        player.GetComponent<MoveTumbleP1>().CanMoveTumble1(true);
        player.GetComponent<AttackFireP1>().CanAttackFire(true);

        Camera.main.GetComponent<CameraMove1>().WatchPlayer();

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlanket1 : MonoBehaviour
{
    public GameObject blanket;

    private GameObject boss;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "PuzzleBall") {
            Destroy(collision.gameObject);

            animator.SetTrigger("explode");

            // PuzzleBall이 깨지는 애니메이션 시작
            // 이후 PuzzleBall Destroy.

            Instantiate(blanket, transform.position, Quaternion.identity);            
            GameObject.Find("AudienceManager").GetComponent<AudienceManager1>().PuzzleComplete();
            GameObject.Find("Boss").GetComponent<PhaseB1>().Phase2();
            StartCoroutine(WatchPlayer());
        }
    }

    IEnumerator WatchPlayer() {
        yield return new WaitForSeconds(1f);
        Camera.main.GetComponent<CameraMove1>().WatchPlayer();
    }
}

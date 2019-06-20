using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlanket1 : MonoBehaviour
{
    public GameObject blanket;

    private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "PuzzleBall") {
            Instantiate(blanket, transform.position, Quaternion.identity);
            Destroy(gameObject);

            // PuzzleBall이 깨지는 애니메이션 시작
            // Destroy(collision.gameObject);
            // 이후 PuzzleBall Destroy.

            GameObject.Find("AudienceManager").GetComponent<AudienceManager1>().PuzzleComplete();

            GameObject.Find("Boss").GetComponent<PhaseB1>().Phase2();

        }
    }
}

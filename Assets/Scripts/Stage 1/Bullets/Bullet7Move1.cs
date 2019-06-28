using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet7Move1 : MonoBehaviour {

    // Wave 입니다.

    private float scale; 
    private float time;

    private GameObject player;
    public float petrifyTime;
    private bool isReady;

    // Start is called before the first frame update
    void Start() {
        time = 0;

        player = GameObject.Find("Player");
        isReady = true;
    }
    
    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        
        scale = 24 * Mathf.Pow(time / 2 - 0.5f, 3) - 2 * time + 3;

        transform.localScale = new Vector3(scale, scale, 0);

        if(time > 2f) {
            
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isReady) {
            if (collision.tag == "Player") {
                player.GetComponent<AttackFireP1>().Petrify(petrifyTime);
                isReady = false;
            }
        }
    }

    IEnumerator Petrify() {
        player.GetComponent<AttackFireP1>().CanAttackFire(false);
        yield return new WaitForSeconds(petrifyTime);
        player.GetComponent<AttackFireP1>().CanAttackFire(true);
    }
}

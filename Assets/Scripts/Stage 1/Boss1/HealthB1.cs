using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthB1 : MonoBehaviour
{
    private int phase;

    public int phase0MaxHealth;
    private int phase0Health;

    public int phase2MaxHealth;
    private int phase2Health;

    // Start is called before the first frame update
    void Start()
    {
        phase = 0;

        phase0Health = phase0MaxHealth;
        phase2Health = phase2MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(phase == 0) {
            if (collision.tag == "PlayerBullet") {
                phase0Health--;
                Destroy(collision.gameObject);

                CheckAlive();
            } else if (collision.tag == "PlayerMelee") {
                phase0Health -= 2;

                CheckAlive();
            }
        } else if (phase == 2) {
            if (collision.tag == "PlayerBullet") {
                phase2Health--;
                Destroy(collision.gameObject);

                CheckAlive();
            } else if (collision.tag == "PlayerMelee") {
                phase2Health -= 2;

                CheckAlive();
            }
        }       
    }

    void CheckAlive() {
        if (phase == 0) {
            if (phase0Health <= 0) {
                phase0Health = 0;
                GetComponent<PhaseB1>().Phase1();
                phase = 2;
                Destroy(GameObject.FindGameObjectWithTag("PatternMaker"));

            }
        } else if (phase == 2) {
            if (phase2Health <= 0) {
                phase2Health = 0;
                GetComponent<PhaseB1>().Phase3();
                Destroy(GameObject.FindGameObjectWithTag("PatternMaker"));


            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthB1 : MonoBehaviour
{
    private int phase;

    public int phase0MaxHealth;
    private int phase0Health;

    public int phase2MaxHealth;
    private int phase2Health;

    public Text health;

    // Start is called before the first frame update
    void Start()
    {
        phase = 0;

        phase0Health = phase0MaxHealth;
        phase2Health = phase2MaxHealth;

        health.text = phase0Health.ToString();
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
            ChangeHeart0();
            if (phase0Health <= 0) {
                phase0Health = 0;
                GetComponent<PhaseB1>().Phase1();
                phase = 2;
                Destroy(GameObject.FindGameObjectWithTag("PatternMaker"));
                health.text = "";
            }
        } else if (phase == 2) {
            ChangeHeart2();
            if (phase2Health <= 0) {
                phase2Health = 0;
                GetComponent<PhaseB1>().Phase3();
                Destroy(GameObject.FindGameObjectWithTag("PatternMaker"));
            }
        }
    }


    void ChangeHeart0() {
        health.text = phase0Health.ToString();
    }

    void ChangeHeart2() {
        health.text = phase2Health.ToString();
    }

    public void Phase2() {
        health.text = phase2Health.ToString();
    }
}

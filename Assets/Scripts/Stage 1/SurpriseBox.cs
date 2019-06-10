using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseBox : MonoBehaviour
{
    public GameObject bulletQ;
    public GameObject surpriseBoxManager;
    public GameObject surpriseBoxChecker; // 자식

    private GameObject player;

    private bool canFire;
    public float fireDelayQ;

    public int maxHealthQ;
    private int health;

    private bool isAwaken;
    public float awakenTimeQ;
    public float duplicatingTimeQ;
    public float rangeQ;

    private float time;

    private int duplicateCounter; // twice duplicate, then explode

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        canFire = true;

        health = maxHealthQ;

        isAwaken = true;
        time = 0;

        duplicateCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (isAwaken) {
            if (canFire) {
                StartCoroutine(WaitFire(fireDelayQ));
            }
        }
        CheckPhase();
    }
    
    void CheckPhase() {
        if (isAwaken) {
            if(time > awakenTimeQ) {
                isAwaken = false;
            }
        } else {
            if(time > duplicatingTimeQ) {
                if(duplicateCounter < 2) {
                    Duplicate();
                } else {
                    Explode();
                }
            }
        }
    }

    IEnumerator WaitFire(float time) {
        canFire = false;
        Vector3 _direction = (player.transform.position - transform.position).normalized;
        Instantiate(bulletQ, transform.position, Quaternion.LookRotation(Vector3.up, _direction));
        yield return new WaitForSeconds(time);
        canFire = true;
    }

    void Duplicate() {
        bool _canDuplicate = false;
        Vector3 _direction;
        do {
            float _range = Random.Range(0, rangeQ);
            float _theta = Random.Range(0, 2 * Mathf.PI);

            float _x = _range * Mathf.Cos(_theta);
            float _y = _range * Mathf.Sin(_theta);

            _direction = new Vector3(_x, _y, 0);
            surpriseBoxChecker.transform.position = transform.position + _direction;
            _canDuplicate = !surpriseBoxChecker.GetComponent<SurpriseBoxChecker>().ExistSurpriseBox();
        } while (!_canDuplicate);
        
        int _maxHealth = maxHealthQ;
        GetComponent<SurpriseBox>().maxHealthQ = health;
        Instantiate(gameObject, surpriseBoxChecker.transform.position, transform.rotation);
        GetComponent<SurpriseBox>().maxHealthQ = _maxHealth;

        Destroy(surpriseBoxChecker);

        surpriseBoxManager.GetComponent<SurpriseBoxManager>().Duplicate();
        duplicateCounter++;
    }

    void Explode() {
        for(int i=0; i<12; i++) {
            FireBullet(30 * i);
        }
        surpriseBoxManager.GetComponent<SurpriseBoxManager>().Destroy();
        Destroy(gameObject);
    }

    void FireBullet(int degree) {
        Instantiate(bulletQ, transform.position, Quaternion.Euler(new Vector3(0, 0, degree)));
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (isAwaken) {
            if(collider.tag == "PlayerMelee") {
                health--;
                CheckAlive();
            }
        }
    }

    void CheckAlive() {
        if(health <= 0) {
            Destroy(gameObject);
            surpriseBoxManager.GetComponent<SurpriseBoxManager>().Destroy();
        }
    }
}

// TODO
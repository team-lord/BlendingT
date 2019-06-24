using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour
{
    private bool isReal;
    public int number;

    private bool isReady;
    private bool isReadyFake;

    // Start is called before the first frame update
    void Awake()
    {
        isReal = false;
    }

    void Start() {
        isReady = true;
        isReadyFake = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsReal(bool _bool) {
        isReal = _bool;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "PlayerMelee") {
            if (isReal) {
                if (isReady) {
                    StartCoroutine(IsReady());
                    float _x = transform.localScale.x;
                    transform.localScale = new Vector3(-_x, 1, 1);
                    GameObject.Find("Bulb").GetComponent<Bulb1>().IsReady();
                }
            } else {
                if (isReadyFake) {
                    StartCoroutine(IsReadyFake());
                    float _x = transform.localScale.x;
                    transform.localScale = new Vector3(-_x, 1, 1);
                }
            }
        }
    }

    public void TurnOff() {
        GetComponent<SpriteRenderer>().flipX = false;
    }

    IEnumerator IsReady() {
        isReady = false;
        yield return new WaitForSeconds(GetComponentInParent<Levers1>().delay);
        isReady = true;
    }

    IEnumerator IsReadyFake() {
        isReadyFake = false;
        yield return new WaitForSeconds(0.1f);
        isReadyFake = true;
    }
}

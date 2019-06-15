using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorFanButton1 : MonoBehaviour
{
    private bool isReady;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "PlayerMelee") {
            if (isReady) {
                StartCoroutine(IsReady());
                GetComponentInParent<MotorFan1>().Change();
            }
        }
    }

    IEnumerator IsReady() {
        isReady = false;
        yield return new WaitForSeconds(delay);
        isReady = true;
    }
}

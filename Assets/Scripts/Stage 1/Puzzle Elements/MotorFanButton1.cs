using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorFanButton1 : MonoBehaviour
{
    private bool isReady;
    public float delay;

    public GameObject edge;
    public Sprite onEdgeSprite;
    private Sprite offEdgeSprite;

    // Start is called before the first frame update
    void Start()
    {
        isReady = true;
        isOn = false;

        offEdgeSprite = edge.GetComponent<SpriteRenderer>().sprite;
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
                SpriteChange();
            }
        }
    }

    private bool isOn;

    void SpriteChange() {
        isOn = !isOn;
        if (isOn) {
            edge.GetComponent<SpriteRenderer>().sprite = onEdgeSprite;
        } else {
            edge.GetComponent<SpriteRenderer>().sprite = offEdgeSprite;
        }
    }

    IEnumerator IsReady() {
        isReady = false;
        yield return new WaitForSeconds(delay);
        isReady = true;
    }
}

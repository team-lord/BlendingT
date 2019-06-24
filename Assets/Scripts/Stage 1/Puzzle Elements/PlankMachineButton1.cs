using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankMachineButton1 : MonoBehaviour
{
    public bool isLeft; // true = left, false = right;

    public Sprite onSprite;
    private Sprite offSprite;

    public GameObject edge;

    public float delay; // 버튼이 눌리는 시간

    // Start is called before the first frame update
    void Start()
    {
        offSprite = GetComponent<SpriteRenderer>().sprite;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "PlayerBullet") {
            Destroy(collision.gameObject);
            if (isLeft) {
                GetComponentInParent<PlankMachine1>().ChangePrevious();
            } else {
                GetComponentInParent<PlankMachine1>().ChangeNext();
            }            
        }
    }

    public void Change() {
        StartCoroutine(WaitChange());
    }

    IEnumerator WaitChange() {
        GetComponent<SpriteRenderer>().sprite = onSprite;
        edge.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(delay);
        GetComponent<SpriteRenderer>().sprite = offSprite;
        edge.GetComponent<SpriteRenderer>().enabled = true;

    }
}

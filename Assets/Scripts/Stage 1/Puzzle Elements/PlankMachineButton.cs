using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankMachineButton : MonoBehaviour
{
    public bool isLeft; // true = left, false = right;

    public Sprite onSprite;
    private Sprite offSprite;

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

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "PlayerBullet") {
            if (isLeft) {
                GetComponentInParent<PlankMachine>().ChangePrevious();
            } else {
                GetComponentInParent<PlankMachine>().ChangeNext();
            }            
        }
    }

    public void Change() {
        StartCoroutine(WaitChange());
    }

    IEnumerator WaitChange() {
        GetComponent<SpriteRenderer>().sprite = onSprite;
        yield return new WaitForSeconds(delay);
        GetComponent<SpriteRenderer>().sprite = offSprite;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankMachineButton : MonoBehaviour
{
    public bool isLeftQ; // true = left, false = right;

    public Sprite onSpriteQ;
    private Sprite offSprite;

    public float delayQ; // 버튼이 눌리는 시간

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
            if (isLeftQ) {
                GetComponentInParent<PlankMachine>().ChangePrevious();
            } else {
                GetComponentInParent<PlankMachine>().ChangeNext();
            }            
        }
    }

    public void ChangeSprite() {
        StartCoroutine(WaitChangeSprite(delayQ));
    }

    IEnumerator WaitChangeSprite(float time) {
        GetComponent<SpriteRenderer>().sprite = onSpriteQ;
        yield return new WaitForSeconds(time);
        GetComponent<SpriteRenderer>().sprite = offSprite;
    }
}

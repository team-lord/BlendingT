using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackP : MonoBehaviour
{
    Animator animator;

    private GameObject cursor;
    private GameObject player;

    private bool isOdd;

    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
               
        cursor = GameObject.Find("Cursor");
        player = GameObject.Find("Player");

        isOdd = false;
    }

    IEnumerator Location() {
        transform.localPosition = Vector3.zero;
        animator.SetBool("meleeAttackOn", true);
        yield return new WaitForSeconds(0.15f);
        transform.localPosition = new Vector3(0, 64, 0);
        animator.SetBool("meleeAttackOn", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationStart() {
        StartCoroutine(Location());

        SetCursorDirection();
        
        animator.SetBool("isOdd", isOdd);
        isOdd = !isOdd;
    }

    void SetCursorDirection() {
        direction = (cursor.transform.position - player.transform.position).normalized;
        animator.SetFloat("cursorDirectionX", direction.x);
        animator.SetFloat("cursorDirectionY", direction.y);
    }
}

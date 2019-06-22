using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackP : MonoBehaviour
{
    // Animator animator;

    private GameObject cursor;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // animator = GetComponent<Animator>();   

        cursor = GameObject.Find("Cursor");
        player = GameObject.Find("Player");

        SetCursorDirection();

        // animator.SetTrigger("meleeAttack");
        // animator.SetBool("isOdd", !animator.GetBool("isOdd")); - isOdd 를 받아오고 뒤집어서 다시 보내주는 줄

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCursorDirection() {
        Vector2 _direction = (cursor.transform.position - player.transform.position).normalized;
        // animator.SetFloat("cursorDirectionX", _direction.x);
        // animator.SetFloat("cursorDirectionY", _direction.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackP : MonoBehaviour
{
    private GameObject cursor;
    private GameObject player;

    private bool isOdd;

    private Vector2[] directions = { new Vector2(1, 0), new Vector2(0.707f, 0.707f), new Vector2(0, 1), new Vector2(-0.707f, 0.707f), new Vector2(-1, 0), new Vector2(-0.707f, -0.707f), new Vector2(0, -1), new Vector2(0.707f, -0.707f) };

    Animator animator;

    // Start is called before the first frame update
    void Start() {
        cursor = GameObject.Find("Cursor");
        player = GameObject.Find("Player");

        isOdd = false;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void Attack() {
        CursorDirection();
        StartCoroutine(Image());

        animator.SetBool("isOdd", isOdd);
        isOdd = !isOdd;
    }

    void CursorDirection() {
        Vector2 _cursorDirection = (cursor.transform.position - player.transform.position).normalized;
        float _max = -1;
        int _maxIndex = -1;
        for (int i = 0; i < directions.Length; i++) {
            float _dot = Vector2.Dot(directions[i], _cursorDirection);
            if (_dot > _max) {
                _max = _dot;
                _maxIndex = i;
            }
        }
        animator.SetFloat("cursorDirectionX", directions[_maxIndex].x);
        animator.SetFloat("cursorDirectionY", directions[_maxIndex].y);
    }

    IEnumerator Image() {
        transform.localPosition = Vector3.zero;
        animator.SetBool("meleeAttackOn", true);
        yield return new WaitForSeconds(0.15f);
        transform.localPosition = new Vector3(0, 64, 0);
        animator.SetBool("meleeAttackOn", false);
    }
}

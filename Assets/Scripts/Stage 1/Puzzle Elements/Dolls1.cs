using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolls1 : MonoBehaviour
{
    public Collider2D[] colliders = new Collider2D[5];

    private int currentDoll;
    private GameObject puzzleBall;

    private bool isReady;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        puzzleBall = GameObject.Find("2ndPuzzleBall");

        currentDoll = 3;

        animator = GetComponent<Animator>();

        animator.SetFloat("current", 3);
        animator.SetFloat("next", 0);

        foreach(Collider2D collider in colliders) {
            collider.enabled = false;
        }
        colliders[4].enabled = true;

        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
        
    public void Change(int number) {

        animator.SetFloat("next", number);
        animator.SetTrigger("on");
        animator.SetFloat("current", number);

        currentDoll = number;
        
    }

    public void PuzzleStart() {
        colliders[currentDoll].enabled = true;
    }

    public void Initialize() {
        colliders[currentDoll].enabled = false;
        colliders[4].enabled = true;
    }

}

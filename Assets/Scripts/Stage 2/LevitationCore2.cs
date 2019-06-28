using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevitationCore2 : MonoBehaviour
{
    private GameObject player;

    public Image levitationCore;

    Animator playerAnimator;
    Animator animator;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");

        animator = GetComponent<Animator>();

        playerAnimator = player.GetComponent<Animator>();

        StartCoroutine(BecomingLevitationCore());
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            StartCoroutine(PlayAnimationGetCore());

            animator.SetTrigger("playerGetCore");

            // player.GetComponent<BlanketP2>().GetBlanket();
            player.GetComponent<LevitationP2>().GetLevitationCore();

            gameObject.GetComponent<CircleCollider2D>().enabled = false;

            StartCoroutine(SceneChange());
        }
    }

    IEnumerator SceneChange() {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator PlayAnimationGetCore() {
        player.GetComponent<MoveTumbleP2>().CanMoveTumble(false);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        playerAnimator.SetTrigger("getLevitation");
        yield return new WaitForSeconds(1f);
        player.GetComponent<MoveTumbleP2>().CanMoveTumble(true);
    }

    IEnumerator BecomingLevitationCore()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.6f);
        GetComponent<CircleCollider2D>().enabled = true;
    }
}

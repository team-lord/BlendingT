using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevitationCore2 : MonoBehaviour
{
    private GameObject player;

    public Sprite corePlate;

    public Image levitationCore;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            StartCoroutine(PlayAnimationGetCore());

            GetComponent<SpriteRenderer>().sprite = corePlate;

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
        yield return new WaitForSeconds(1.4f);
        player.GetComponent<MoveTumbleP2>().CanMoveTumble(true);
    }
}

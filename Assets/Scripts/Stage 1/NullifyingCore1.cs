 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NullifyingCore1 : MonoBehaviour
{
    private GameObject player;

    public GameObject smoke;

    public Sprite blanketPlate;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            StartCoroutine(PlayAnimationGetBlanket());
            Instantiate(smoke, transform.position, Quaternion.identity);
            
            GetComponent<SpriteRenderer>().sprite = blanketPlate;

            player.GetComponent<BlanketP1>().GetBlanket();

            gameObject.GetComponent<CircleCollider2D>().enabled = false;

            StartCoroutine(SceneChange());
        }
    }

    IEnumerator SceneChange() {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator PlayAnimationGetBlanket()
    {
        player.GetComponent<MoveTumbleP1>().CanMoveTumble(false);
        yield return new WaitForSeconds(1.4f);
        player.GetComponent<MoveTumbleP1>().CanMoveTumble(true);
    }
}

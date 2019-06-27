using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorePlate : MonoBehaviour
{
    public Sprite corePlate;
    private GameObject player;

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
        if (collision.tag == "Player") {            
            GetComponent<SpriteRenderer>().sprite = corePlate;

            // player.GetComponent< ...

            StartCoroutine(SceneChange());
        }
    }

    IEnumerator SceneChange() {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Main Menu");
    }
}

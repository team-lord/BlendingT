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
            Instantiate(smoke, transform.position, Quaternion.identity);
            
            GetComponent<SpriteRenderer>().sprite = blanketPlate;

            player.GetComponent<BlanketP1>().GetBlanket();

            StartCoroutine(SceneChange());
        }
    }

    IEnumerator SceneChange() {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Main Menu");
    }
}

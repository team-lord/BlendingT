using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[6];

    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Animation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Animation() {
        yield return new WaitForSeconds(delay);
        GetComponent<Image>().sprite = sprites[1];
        yield return new WaitForSeconds(delay);
        GetComponent<Image>().sprite = sprites[2];
        yield return new WaitForSeconds(delay);
        GetComponent<Image>().sprite = sprites[3];
        yield return new WaitForSeconds(delay);
        GetComponent<Image>().sprite = sprites[4];
        yield return new WaitForSeconds(delay);
        GetComponent<Image>().sprite = sprites[5];
    }
}

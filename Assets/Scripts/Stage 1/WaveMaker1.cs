using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMaker1 : MonoBehaviour
{
    Animator animator;

    private float time;
    public float delay;

    private bool isReady;

    public GameObject wave;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady) {
            time += Time.deltaTime;
            if (time > delay) {
                time = 0;
                isReady = false;
                Fire();
            }
        }
    }

    public void Fire() {
        animator.SetTrigger("change");
        Instantiate(wave, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Error");
        if(collision.tag== "Wall") {
            Destroy(gameObject);
        }
    }
}

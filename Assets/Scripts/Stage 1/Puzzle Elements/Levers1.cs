using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levers1 : MonoBehaviour
{
    public GameObject[] levers = new GameObject[12];
    public Sprite[] sprites = new Sprite[12];

    public float delay;

    // Start is called before the first frame update
    void Start() {
        levers[Random.Range(0, levers.Length)].GetComponent<Lever1>().IsReal(true);
        Shuffle();
        for(int i=0; i<12; i++) {
            levers[i].GetComponent<SpriteRenderer>().sprite = sprites[i];
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shuffle() {
        Sprite _sprite;
        int _a, _b;
        for(int i=0; i<50; i++) {
            _a = Random.Range(0, 12);
            _b = Random.Range(0, 12);
            _sprite = sprites[_a];
            sprites[_a] = sprites[_b];
            sprites[_b] = _sprite;            
        }
    }
}

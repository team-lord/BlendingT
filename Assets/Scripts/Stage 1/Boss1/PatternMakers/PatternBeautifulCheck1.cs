using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternBeautifulCheck1 : MonoBehaviour
{
    private GameObject audienceManager;

    // Start is called before the first frame update
    void Start()
    {
        audienceManager = GameObject.Find("AudienceManager");

        audienceManager.GetComponent<AudienceManager1>().PatternStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

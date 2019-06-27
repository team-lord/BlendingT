using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevitationP2 : MonoBehaviour
{
    public Image levitationCore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetLevitationCore() {
        levitationCore.GetComponent<LevitationCore>().GetLevitationCore();
    }

}

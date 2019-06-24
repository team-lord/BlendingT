using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthT : MonoBehaviour {
    
    // 피격시 무적 딜레이
    public float invincibleTime;
    private bool isInvincible;

    // Start is called before the first frame update
    void Start()
    {        
        isInvincible = false;
    }

    // Update is called once per frame
    void Update() {

    }

    public void Hit() {
        if (!isInvincible) {
            transform.Translate(new Vector3(-10, 0, 0));
            
            StartCoroutine(IsInvincible());
        }
    }
    
    IEnumerator IsInvincible() {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }

    public void IsInvincible(bool _bool) {
        isInvincible = _bool;
    }

    public bool GetIsInvincible() {
        return isInvincible;
    }
}

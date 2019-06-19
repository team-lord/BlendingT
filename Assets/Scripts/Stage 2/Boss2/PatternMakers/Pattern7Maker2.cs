using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern7Maker2 : MonoBehaviour
{
    // TODO
    // 일정 간격을 두고 1열로 전진하는 벌(탄알 / B타입)들과 1자형 꿀 탄알들의 교차 - 꿀, 벌 - 맵 크기 
    
    public GameObject honeyBullets;
    public GameObject beeBBullets;

    private GameObject boss;

    public float range;

    // Start is called before the first frame update
    void Start() {
        transform.position = Vector3.zero;

        boss = GameObject.Find("Boss");

        int _degree = Random.Range(0, 360);
        Vector2 _direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * _degree), Mathf.Sin(Mathf.Deg2Rad * _degree));
        Instantiate(honeyBullets, range * _direction, Quaternion.Euler(new Vector3(0, 0, _degree - 180)));

        _degree = Random.Range(0, 360);
        _direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * _degree), Mathf.Sin(Mathf.Deg2Rad * _degree));
        Instantiate(beeBBullets, range * _direction, Quaternion.Euler(new Vector3(0, 0, _degree - 180)));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckAlive() {
        boss.GetComponent<PatternB2>().PatternEnd();
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeeB : MonoBehaviour
{
    public float moveSpeedQ;
    public float fastMoveSpeedQ;

    public bool isHoneyAttached;

    private GameObject boss;
    private GameObject player;

    public float randomRangeQ;

    // Start is called before the first frame update
    void Start()
    {
        isHoneyAttached = false;

        boss = GameObject.Find("Boss");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isHoneyAttached) {
            Turn();
        }

        Move();
    }

    void Turn() {
        Vector3 _newDirection = (player.transform.position + RandomVector() - transform.position).normalized;

        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.rotation = Quaternion.LookRotation(Vector3.up, _newDirection);

        isHoneyAttached = false;
    }

    Vector3 RandomVector() {
        float _x = Random.Range(0, randomRangeQ) * Mathf.Sin(Random.Range(0, 2 * Mathf.PI));
        float _y = Random.Range(0, randomRangeQ) * Mathf.Cos(Random.Range(0, 2 * Mathf.PI));
        return new Vector3(_x, _y);
    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeedQ * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Blanket") {
            Destroy(gameObject);
        }

        if (collider.tag == "Player") { // 이 GameObject의 태그는 EnemyBullet이 아님!
            if (!collider.GetComponent<Player>().isInvicible) {

                collider.GetComponent<Player>().health--;
                collider.GetComponent<Player>().CheckAlive();

                Destroy(gameObject);
            }
        }
    }
}

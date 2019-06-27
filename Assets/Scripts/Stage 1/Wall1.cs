using System.Collections;
using UnityEngine;

public class Wall1 : MonoBehaviour
{
    private GameObject audienceManager;
    private GameObject player;

    private bool isReady;
    public float pushDelay;

    public Vector3 normalVector;

    public GameObject audienceBullet;

    // Start is called before the first frame update
    void Start()
    {
        audienceManager = GameObject.Find("AudienceManager");
        player = GameObject.Find("Player");

        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isReady) {
            if (collision.tag == "Player") {
                StartCoroutine(IsReady());
                audienceManager.GetComponent<AudienceManager1>().WallHit();
                Instantiate(audienceBullet, player.transform.position - 1.5f * normalVector, Quaternion.FromToRotation(Vector3.up, normalVector));
                player.GetComponent<PushBAudienceP1>().PushStart(normalVector);
            }
        }        
    }

    IEnumerator IsReady() {
        isReady = false;
        yield return new WaitForSeconds(pushDelay);
        isReady = true;
    }
}

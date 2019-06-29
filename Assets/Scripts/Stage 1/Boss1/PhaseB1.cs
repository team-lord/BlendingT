using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseB1 : MonoBehaviour
{
    public GameObject smoke;
    public GameObject blanket;

    public GameObject nullifyingCore;

    private GameObject curtain;
    private GameObject player;

    private GameObject platformA;
    AudioSource platformAaudio;

    private GameObject platformB;
    AudioSource platformBaudio;

    private GameObject platformC;
    AudioSource platformCaudio;

    private GameObject platformEnd;
    AudioSource platformEndaudio;

    private GameObject platformStart;
    AudioSource platformStartaudio;

    GameObject old;
    AudioSource oldaudio;

    // Start is called before the first frame update
    void Start()
    {
        curtain = GameObject.Find("Curtain");
        player = GameObject.Find("Player");

        platformA = GameObject.Find("PlatformA");
        platformAaudio = platformA.GetComponent<AudioSource>();

        platformB = GameObject.Find("PlatformB");
        platformBaudio = platformB.GetComponent<AudioSource>();

        platformC = GameObject.Find("PlatformC");
        platformCaudio = platformC.GetComponent<AudioSource>();

        platformEnd = GameObject.Find("PlatformEnd");
        platformEndaudio = platformEnd.GetComponent<AudioSource>();

        platformStart = GameObject.Find("PlatformStart");
        platformStartaudio = platformStart.GetComponent<AudioSource>();

        old = GameObject.Find("Old");
        oldaudio = old.GetComponent<AudioSource>();

        StartCoroutine(PlatformStartOff());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Phase1() {

        player.transform.position = new Vector3(-12, 12, 0);
        //StartCoroutine(ChangeBGM(platformAaudio, platformBaudio));

        GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject enemyBullet in enemyBullets) {
            Destroy(enemyBullet);
        }

        GameObject[] playerBullets = GameObject.FindGameObjectsWithTag("PlayerBullet");
        foreach (GameObject playerBullet in playerBullets) {
            Destroy(playerBullet);
        }

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("SurpriseBox");
        foreach(GameObject box in boxes) {
            Destroy(box);
        }

        //Instantiate(blanket, Vector3.zero, Quaternion.identity);
        Instantiate(smoke, transform.position, Quaternion.identity);
        transform.position = new Vector3(64, 0, 0);

        curtain.GetComponent<Curtain1>().Change();

        GetComponent<MoveFireB1>().IsMove2(false);
        GetComponent<PatternB1>().IsPatternPhase(false);
        GetComponent<PuzzleB1>().IsPuzzlePhase(true);

        Camera.main.GetComponent<CameraMove1>().WatchPlayerCenter();
    }

    public void Phase2() {
        
        //StartCoroutine(ChangeBGM(oldaudio, platformCaudio));

        //Instantiate(blanket, Vector3.zero, Quaternion.identity);
        Instantiate(smoke, Vector3.zero, Quaternion.identity);
        transform.position = Vector3.zero;

        curtain.GetComponent<Curtain1>().Change();

        GetComponent<PatternB1>().CPatternStart();

        GetComponent<MoveFireB1>().IsMove2(true);
        GetComponent<PatternB1>().IsPatternPhase(true);
        GetComponent<PuzzleB1>().IsPuzzlePhase(false);
        GetComponent<PatternB1>().PatternForge();
        GetComponent<HealthB1>().Phase2();

        Camera.main.GetComponent<CameraMove1>().WatchPlayer();

    }

    public void Phase3() {
        //Instantiate(blanket, Vector3.zero, Quaternion.identity);
        // Camera.main.GetComponent<CameraMove1>().WatchPlayerCenter();

        StartCoroutine(Phase3Camera());

        GetComponent<MoveFireB1>().IsMove2(false);
        GetComponent<PatternB1>().IsPatternPhase(false);

        curtain.GetComponent<Curtain1>().Change();

        Instantiate(nullifyingCore, transform.position, Quaternion.identity);
        Instantiate(smoke, transform.position, Quaternion.identity);

        transform.position = new Vector3(64, 0, 0);


    }

    IEnumerator Phase3Camera() {
        Camera.main.GetComponent<CameraMove1>().WatchCore(transform.position);
        yield return new WaitForSeconds(2f);
        Camera.main.GetComponent<CameraMove1>().WatchPlayerCenter();
    }
    

    IEnumerator PlatformStartOff()
    {
        yield return new WaitForSeconds(12.5f);
        StartCoroutine(ChangeBGM(platformStartaudio, platformAaudio));
    }
    IEnumerator ChangeBGM(AudioSource offAudio, AudioSource onAudio)
    {
        offAudio.volume = 0.9f;
        yield return new WaitForSeconds(0.3f);
        offAudio.volume = 0.8f;
        yield return new WaitForSeconds(0.3f);
        offAudio.volume = 0.7f;
        yield return new WaitForSeconds(0.3f);
        offAudio.volume = 0.6f;
        yield return new WaitForSeconds(0.3f);
        offAudio.volume = 0.5f;
        yield return new WaitForSeconds(0.3f);
        offAudio.volume = 0.4f;
        yield return new WaitForSeconds(0.3f);
        offAudio.volume = 0.3f;
        yield return new WaitForSeconds(0.3f);
        offAudio.volume = 0.2f;
        yield return new WaitForSeconds(0.3f);
        offAudio.volume = 0.1f;
        onAudio.Play();
        yield return new WaitForSeconds(0.3f);
        offAudio.Stop();
    }
}

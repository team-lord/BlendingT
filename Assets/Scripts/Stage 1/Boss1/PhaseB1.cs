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

    // Start is called before the first frame update
    void Start()
    {
        curtain = GameObject.Find("Curtain");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Phase1() {
        Instantiate(blanket, Vector3.zero, Quaternion.identity);
        Instantiate(smoke, transform.position, Quaternion.identity);
        transform.position = new Vector3(64, 0, 0);

        curtain.GetComponent<Curtain1>().Change();

        GetComponent<MoveFireB1>().IsMove(false);
        GetComponent<PatternB1>().IsPatternPhase(false);
        GetComponent<PuzzleB1>().IsPuzzlePhase(true);

        Camera.main.GetComponent<CameraMove1>().WatchPlayerCenter();
    }

    public void Phase2() {
        Destroy(GameObject.Find("Puzzle"));

        Instantiate(blanket, Vector3.zero, Quaternion.identity);
        Instantiate(smoke, Vector3.zero, Quaternion.identity);
        transform.position = Vector3.zero;

        curtain.GetComponent<Curtain1>().Change();

        GetComponent<MoveFireB1>().IsMove(true);
        GetComponent<PatternB1>().IsPatternPhase(true);
        GetComponent<PuzzleB1>().IsPuzzlePhase(false);
        GetComponent<PatternB1>().PatternForge();

        Camera.main.GetComponent<CameraMove1>().WatchPlayer();

    }

    public void Phase3() {
        Instantiate(blanket, Vector3.zero, Quaternion.identity);
        Camera.main.GetComponent<CameraMove1>().WatchPlayerCenter();

        GetComponent<MoveFireB1>().IsMove(false);
        GetComponent<PatternB1>().IsPatternPhase(false);

        curtain.GetComponent<Curtain1>().Change();

        Instantiate(nullifyingCore, transform.position, Quaternion.identity);
        Instantiate(smoke, transform.position, Quaternion.identity);

        transform.position = new Vector3(64, 0, 0);


    }
}

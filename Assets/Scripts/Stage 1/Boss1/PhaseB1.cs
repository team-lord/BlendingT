using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseB1 : MonoBehaviour
{
    public GameObject smoke;

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
        Instantiate(smoke, transform.position, Quaternion.identity);
        transform.position = new Vector3(64, 0, 0);

        curtain.GetComponent<Curtain1>().Change();

        GetComponent<MoveFireB1>().IsMove(false);
        GetComponent<PatternB1>().IsPatternPhase(false);
        GetComponent<PuzzleB1>().IsPuzzlePhase(true);
    }

    public void Phase2() {
        Destroy(GameObject.Find("Puzzle"));

        Instantiate(smoke, Vector3.zero, Quaternion.identity);
        transform.position = Vector3.zero;

        curtain.GetComponent<Curtain1>().Change();

        GetComponent<MoveFireB1>().IsMove(true);
        GetComponent<PatternB1>().IsPatternPhase(true);
        GetComponent<PuzzleB1>().IsPuzzlePhase(false);
        GetComponent<PatternB1>().PatternForge();
    }

    public void Phase3() {
        curtain.GetComponent<Curtain1>().Change();

        SceneManager.LoadScene("Main Menu");

        // TODO - 이벤트 씬
        // 데모버전 보류
    }
}

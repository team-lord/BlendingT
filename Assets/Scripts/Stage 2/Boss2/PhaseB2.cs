using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseB2 : MonoBehaviour
{
    public GameObject special0Maker;
    public GameObject special1Maker;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Phase1() {
        GetComponent<PatternB2>().PatternArray(new int[] { 0, 1, 4, 2, 6, 5, 8, 3, 7 });
        GetComponent<HealthB2>().Phase(1);
    }

    public void Phase2() {
        GetComponent<PatternB2>().PatternPhase(false);
        GetComponent<MoveB2>().IsMove(false);
        GetComponent<HealthB2>().Phase(2);

        // 필살기 1
        Instantiate(special0Maker, Vector3.zero, transform.rotation);
    }

    public void Phase3() {
        GetComponent<PatternB2>().PatternPhase(true);
        GetComponent<MoveB2>().IsMove(true);
        GetComponent<HealthB2>().Phase(3);


        GetComponent<PatternB2>().PatternForge(0);
        GetComponent<PatternB2>().PatternForge(1);

        GetComponent<MakeBeeB2>().IsReady(true);
        GetComponent<FireBulletB2>().IsReady(true);        
    }

    public void Phase4() {
        GetComponent<HealthB2>().Phase(4);
        GetComponent<PatternB2>().PatternForge(4);
        GetComponent<MakeBeeB2>().Forge();
    }

    public void Phase5() {
        GetComponent<HealthB2>().Phase(5);
        GetComponent<PatternB2>().PatternPhase(false);
        GetComponent<MoveB2>().IsMove(true);

        GetComponent<MakeBeeB2>().IsReady(false);
        GetComponent<FireBulletB2>().IsReady(false);
        // 필살기 2

        Instantiate(special1Maker, Vector3.zero, transform.rotation);
    }

    public void Phase6() {
        GetComponent<HealthB2>().Phase(6);
        // TODO - 이벤트 씬
    }
}

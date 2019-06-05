using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour {
    // 페이즈
    public int phase; // 1, 2, 3(필살기), 4, 5, 6(필살기), 7;

    // 플레이어
    private GameObject player;

    // 체력
    public int maxHealthQ;
    public int health;
    public bool isAlive;

    // 공격 및 이동
    public float fireDelayQ;
    public bool canFire;

    public Vector3 direction;
    public float moveSpeedQ;
    public bool isMoving; // 움직이는 동안에는 기본 공격을 하고, 움직임이 멈추면 패턴이 나온다.

    // 패턴
    public float patternDelayLowerLimitQ;
    public float patternDelayUpperLimitQ;
    public bool isProgressingPattern;
    private int[][] patternArray = new int[7][];

    private int recentPattern;

    // 탄알
    public GameObject bulletQ;
    public GameObject honeyBulletQ;
    public GameObject posionBulletQ;
    public GameObject bigPosionBulletQ;
    public GameObject beeBulletAQ;
    public GameObject beeBulletBQ;

    // 패턴 1 : 육각형을 이루는 탄알들
    public GameObject bullet1Q;
    public GameObject bullet1ForgedQ;
    public bool pattern1IsForged;
    public int pattern1RepetitionQ;
    public float pattern1DelayQ;

    // 패턴 2 : 빠르게 회전하며 독침형태의 탄을 전방위로 랜덤하게 난사
    public int pattern2RepetitionQ; // 12
    public float pattern2DelayQ;
    public bool pattern2IsForged;

    // 패턴 3 : 보스 주변 6방향으로 큰 탄알 발사 - 각 탄알이 6방향으로 쪼개짐
    public GameObject bullet3Q;
    public float pattern3DelayQ; // 애니메이션 시간

    // 패턴 4 : 부채꼴 형태로 6개의 꿀탄알과 벌 탄알을 번갈아 빠르게 발사
    public int pattern4RepetitionQ;
    public float pattern4DelayQ;
    public int pattern4AngleQ;
    private bool isHoneyBullet; // true: Honey Bullet, false: Bee Bullet
    private GameObject pattern4Bullet;

    // 패턴 5:
    public bool pattern5IsForged;

    // 패턴 10:
    public bool pattern10IsForged;


    // Start is called before the first frame update
    void Start() {
        phase = 1;

        player = GameObject.Find("Player");
        pattern1IsForged = false;
        pattern2IsForged = false;
        pattern5IsForged = false;
        pattern10IsForged = false;

        health = maxHealthQ;
        isAlive = true;

        isMoving = false;

        isProgressingPattern = false;

        patternArray[0] = new int[] { 1, 2, 5, 3, 7, 6, 9 };
        patternArray[1] = new int[] { 1, 2, 5, 3, 7, 6, 9, 4, 8 };
        // patternArray[2]=null, 필살기 1; 
        patternArray[3] = new int[] { 1, 2, 5, 3, 7, 6, 9, 4, 8, 10 }; // pattern1IsForged = true, pattern2IsForged = true; 
        patternArray[4] = new int[] { 1, 2, 5, 3, 7, 6, 9, 4, 8, 10 }; // pattern10IsForged = true; pattern5IsForged = true;
                                                                       // patternArray[5]=null, 필살기 2;
                                                                       // patternArray[6]=null, 특수

        recentPattern = 0;

    }

    private void FixedUpdate() {
        FixRotate();
    }

    void FixRotate() {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update() { // 페이즈 별로 다름
        switch (phase) {
            case 1:
                if (!isProgressingPattern) {
                    if (isMoving) {
                        Move();
                        if (canFire) {
                            Fire();
                        }
                    } else {
                        PatternInArray();
                    }
                }
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            default:
                Debug.Log("Error");
                break;
        }

        if (!isProgressingPattern) {
            CheckPhase();
        }
    }

    void Move() {
        direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * moveSpeedQ * Time.deltaTime);
    }

    void Fire() {
        StartCoroutine(WaitFire(fireDelayQ));
        Instantiate(bulletQ, transform.position, Quaternion.FromToRotation(Vector3.up, direction));
    }

    IEnumerator WaitFire(float time) {
        canFire = false;
        yield return new WaitForSeconds(time);
        canFire = true;
    }

    void PatternInArray() {

        int _number;
        do {
            _number = Random.Range(0, patternArray[phase - 1].Length);
        } while (patternArray[phase - 1][_number] == recentPattern);

        switch (patternArray[phase - 1][_number]) {
            case 1:
                Pattern1();
                break;
            case 2:
                Pattern2();
                break;
            case 3:
                if (Pattern3IsPossible()) {
                    Pattern3();
                } else {
                    PatternInArray();
                }
                break;
            case 4:
                Pattern4();
                break;
            case 5:
                Pattern5();
                break;
            case 6:
                Pattern6();
                break;
            case 7:
                Pattern7();
                break;
            case 8:
                Pattern8();
                break;
            case 9:
                Pattern9();
                break;
            case 10:
                Pattern10();
                break;
            case 11:
                Pattern11();
                break;
            case 12: // To be or not to be, that is the question...
                break;
            default:
                PatternInArray(); // 아마 Pattern3에서 쓸 일이 있을 듯
                break;
        }

        recentPattern = patternArray[phase - 1][_number];

    }

    void PatternEnd() { // 패턴이 끝나면 이 함수를 호출하고 몇초동안 isMoving을 true로 할건지 정함.
        StartCoroutine(WaitPatternEnd(Random.Range(patternDelayLowerLimitQ, patternDelayUpperLimitQ)));
    }

    IEnumerator WaitPatternEnd(float time) {
        isMoving = true;
        yield return new WaitForSeconds(time);
        isMoving = false;
    }

    IEnumerator WaitPatternProgressing(float time) {
        isProgressingPattern = true;
        yield return new WaitForSeconds(time);
        PatternEnd();
        isProgressingPattern = false;
    }

    void Pattern1() {
        StartCoroutine(WaitPatternProgressing(pattern1DelayQ * (pattern1RepetitionQ - 1)));
        for (int i = 0; i < pattern1RepetitionQ; i++) {
            StartCoroutine(WaitPattern1(pattern1DelayQ * i));
        }
    }

    IEnumerator WaitPattern1(float time) {
        yield return new WaitForSeconds(time);
        Pattern1FireBullet();
    }

    void Pattern1FireBullet() {
        DeterminePattern1Direction();
        if (pattern1IsForged) {
            Instantiate(bullet1ForgedQ, transform.position, Quaternion.LookRotation(Vector3.up, bullet1Q.GetComponent<Bullet1Move2>().direction));
        } else {
            Instantiate(bullet1Q, transform.position, Quaternion.LookRotation(Vector3.up, bullet1Q.GetComponent<Bullet1Move2>().direction));
        }
    }
    

    void DeterminePattern1Direction() {
        bullet1Q.GetComponent<Bullet1Move2>().direction = (player.transform.position - transform.position).normalized;
        bullet1ForgedQ.GetComponent<Bullet1Move2>().direction = (player.transform.position - transform.position).normalized;
    }

    void Pattern2() {
        StartCoroutine(WaitPatternProgressing(pattern2DelayQ * (pattern2RepetitionQ - 1)));
        for (int i = 0; i < pattern2RepetitionQ; i++) {
            StartCoroutine(WaitPattern2(pattern2DelayQ * i));
        }
    }

    IEnumerator WaitPattern2(float time) {
        yield return new WaitForSeconds(time);
        Pattern2Fire();
    }

    void Pattern2Fire() {
        if (pattern2IsForged) {
            for (int i = 0; i < 12; i++) {
                Pattern2FireBullet(Random.Range(0, 30) + 30 * i);
            }
        } else {
            for (int i = 0; i < 6; i++) {
                Pattern2FireBullet(Random.Range(0, 60) + 60 * i);
            }
        }
    }

    void Pattern2FireBullet(int degree) {      

        Instantiate(posionBulletQ, transform.position, Quaternion.Euler(0, 0, degree));
    }

    bool Pattern3IsPossible() {
        if (null == GameObject.FindGameObjectsWithTag("EnemyBulletMine")) {
            return true;
        } else {
            return false;
        }
    }

    void Pattern3() {
        
        StartCoroutine(WaitPatternProgressing(pattern3DelayQ));
        for(int i=0; i<6; i++) {
            Pattern3FireBullet(60 * i);
        }
    }

    void Pattern3FireBullet(int degree) {
        Quaternion _rotation = Quaternion.Euler(0, 0, degree);

        Instantiate(bullet3Q, transform.position, _rotation);
    }


    void Pattern4() {
        isHoneyBullet = Random.value > 0.5f;

        pattern4Bullet = isHoneyBullet ? honeyBulletQ : beeBulletBQ;

        StartCoroutine(WaitPatternProgressing(pattern4DelayQ * (pattern4RepetitionQ - 1)));
        for(int i=0; i<pattern4RepetitionQ; i++) {
            StartCoroutine(WaitPattern4(pattern4DelayQ * i));
        }
    }

    IEnumerator WaitPattern4(float time) {
        yield return new WaitForSeconds(time);
        Pattern4ChangeBullet();
        Pattern4Fire();
    }

    void Pattern4ChangeBullet() {
        isHoneyBullet = !isHoneyBullet;
        pattern4Bullet = isHoneyBullet ? honeyBulletQ : beeBulletBQ;
    }

    void Pattern4Fire() {
        for(int i=0; i<6; i++) {
            Pattern4FireBullet((int)((i - 2.5f) * pattern4AngleQ));
        }
    }   

    void Pattern4FireBullet(int degree) {
        Pattern4ChangeBullet();

        Vector3 _direction = (player.transform.position - transform.position).normalized;
        Quaternion _rotation = Quaternion.LookRotation(Vector3.up, _direction);
        Quaternion _degree = Quaternion.Euler(0, 0, degree);

        Instantiate(pattern4Bullet, transform.position, _rotation * _degree);
        
    }

    void Pattern5() {
        // TODO
        // 예측샷 때문에 보류
    }
    void Pattern6() {
           
    }
    void Pattern7() { }
    void Pattern8() { }
    void Pattern9() { }
    void Pattern10() { }
    void Pattern11() { }

    void CheckPhase() {
        // TODO, 체력 및 상태에 따라서 phase 변경. isForged도 이넘이 변경
    }
}

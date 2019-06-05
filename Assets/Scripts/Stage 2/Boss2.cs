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

    public int phase2HealthQ; // 1 -> 2
    public int phase3HealthQ; // 2 -> 3
    public int phase5HealthQ; // 5 -> 6
    public int phase6HealthQ; // 6 -> 7

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
    private int[] patternArray;

    private int recentPattern;

    // 탄알
    public GameObject bulletQ;
    public GameObject honeyBulletQ;
    public GameObject posionBulletQ;
    public GameObject bigPosionBulletQ;
    public GameObject beeBulletAQ;
    public GameObject beeBulletBQ;

    public GameObject beeAQ;
    public GameObject beeBQ;

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
    public GameObject bullet5FastQ;
    public GameObject bullet5MiddleQ;
    public GameObject bullet5SlowQ;
    private float pattern5SlowMoveSpeed;

    // 패턴 9:
    public float pattern9MinimumDistanceQ;
    public float pattern9MaximumDistanceQ;
    private int pattern9Index; // 0: Skip, 1: Fly, 2: Sweep

    public float pattern9FlyDealyQ;

    public float pattern9SweepAngleQ;
    public float pattern9SweepingTimeQ;

    // 패턴 10:
    public bool pattern10IsForged;
    public bool pattern10IsPossible; // start in phase 4

    // 패턴 11
    public bool pattern11IsPossible; // start in phase 4
    public float pattern11DelayQ;
    private float time;

    // 필살기 1
    public bool special1Start;
    public bool special1End;

    // 필살기 2
    public bool special2Start;
    public bool special2End;
    
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

        patternArray = new int[] { 1, 2, 5, 3, 7, 6, 9 };
        
        recentPattern = 0;

        pattern5SlowMoveSpeed = bullet5SlowQ.GetComponent<Bullet5SlowMove2>().slowMoveSpeedQ;

        pattern9Index = 0;

        pattern10IsPossible = false; // phase 바꾸면서 바꾸기
        pattern11IsPossible = false; // phase 바꾸면서 바꾸기

        time = 0;

        special1Start = false;
        special1End = false;
        special2Start = false;
        special2End = false;
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

        if (pattern11IsPossible) {
            Pattern11();
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
            _number = Random.Range(0, patternArray.Length);
        } while (patternArray[_number] == recentPattern);

        switch (patternArray[_number]) {
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
                    PatternInArray(); // skip
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
                int _index = Pattern9IsPossible();
                if (_index == 0) { // sklp
                    PatternInArray();
                } else {
                    Pattern9(_index);
                }
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

        recentPattern = patternArray[_number];

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
        if (pattern10IsPossible) {
            Pattern10();
        }
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
        StartCoroutine(WaitPatternProgressing(0));

        Pattern5Fire();
    }

    void Pattern5Fire() {
        Vector3 _directionSlow = player.transform.position - transform.position;
        float _time = _directionSlow.magnitude / pattern5SlowMoveSpeed;
        Vector3 _playerMovement =  Pattern5PlayerMovement();

        Vector3 _directionFast = _directionSlow + _playerMovement;
        Vector3 _directionMiddle = (_directionSlow + _directionFast) / 2;

        Instantiate(bullet5SlowQ, transform.position, Quaternion.LookRotation(Vector3.up, _directionSlow.normalized));
        Instantiate(bullet5MiddleQ, transform.position, Quaternion.LookRotation(Vector3.up, _directionMiddle.normalized));
        Instantiate(bullet5FastQ, transform.position, Quaternion.LookRotation(Vector3.up, _directionFast.normalized));

        if (pattern5IsForged) {

            _directionFast = _directionSlow - _playerMovement;
            _directionMiddle = (_directionSlow + _directionFast) / 2;

            Instantiate(bullet5MiddleQ, transform.position, Quaternion.LookRotation(Vector3.up, _directionMiddle.normalized));
            Instantiate(bullet5FastQ, transform.position, Quaternion.LookRotation(Vector3.up, _directionFast.normalized));
        }
    }

    Vector3 Pattern5PlayerMovement() {
        int _h = player.GetComponent<Player>().h;
        int _v = player.GetComponent<Player>().v;
        float _speed = player.GetComponent<Player>().moveSpeedQ;

        return new Vector3(_h * _speed, _v * _speed, 0);
    }

    void Pattern6() {
           
    }
    void Pattern7() { }
    void Pattern8() { }

    void Pattern9(int index) {
        if (index == 1) {
            Pattern9Fly();
        } else if (index == 2) {
            Pattern9Sweep();
            
        }
    }

    int Pattern9IsPossible() { 
        float _distance = (player.transform.position - transform.position).magnitude;
        if(_distance < pattern9MinimumDistanceQ) {
            return 2;
        } else if (pattern9MaximumDistanceQ < _distance) {
            return 1;
        } else {
            return 0;
        }
    }

    void Pattern9Fly() {
        // TODO
    }

    void Pattern9Sweep() {
        // TODO
    }

    void Pattern10() {
        Instantiate(beeAQ, transform.position, transform.rotation);
        if (pattern10IsForged) {
            Instantiate(beeBQ, transform.position, transform.rotation);
        }
    }

    void Pattern11() {
        time += Time.deltaTime;
        if(time > pattern11DelayQ) {
            Pattern11Fire();
            time = 0;
        }
    }

    void Pattern11Fire() {
        Vector3 _direction = (player.transform.position - transform.position).normalized;

        Instantiate(honeyBulletQ, transform.position, Quaternion.LookRotation(Vector3.up, _direction));
    }

    void CheckPhase() {
        // TODO, 체력 및 상태에 따라서 phase 변경. isForged도 이넘이 변경
        switch (phase) {
            case 1:
                if (health <= phase2HealthQ) {
                    phase = 2;
                    patternArray = new int[] { 1, 2, 5, 3, 7, 6, 9, 4, 8 };
                }
                break;
            case 2:
                if (health <= phase3HealthQ) {
                    phase = 3;
                    patternArray = null;
                    special1Start = true;
                }
                break;
            case 3:
                if (special1End) {
                    phase = 4;
                    pattern10IsPossible = true;
                    pattern11IsPossible = true;
                    pattern1IsForged = true;
                    pattern2IsForged = true;
                    patternArray = new int[] { 1, 2, 5, 3, 7, 6, 9, 4, 8 };
                }
                break;
            case 4:
                if(health <= phase5HealthQ) {
                    phase = 5;
                    pattern5IsForged = true;
                    pattern10IsForged = true;
                    patternArray = new int[] { 1, 2, 5, 3, 7, 6, 9, 4, 8 };
                }
                break;
            case 5:
                if(health <= phase6HealthQ) {
                    phase = 6;
                    patternArray = null;
                    special2Start = true;
                }
                break;
            case 6:
                if (special2End) {
                    phase = 7;
                }
                break;
            case 7: // 다음 Scene 호출
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collider) {
        
    }
    */
}


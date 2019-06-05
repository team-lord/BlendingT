using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour {

    // 페이즈
    public int phase; // 1: 전투, 2: 퍼즐, 3: 전투

    // 플레이어
    private GameObject player;

    // 체력
    public int maxHealthQ;
    public int health;
    public bool isAlive;

    // 공격 및 이동
    public GameObject bullet0Q;
    public float fireDelayQ;
    public bool canFire;

    public Vector3 direction;
    public float moveSpeedQ;
    public bool isMoving; // 움직이는 동안에는 기본 공격을 하고, 움직임이 멈추면 패턴이 나온다.

    // 패턴
    public float patternDelayLowerLimitQ;
    public float patternDelayUpperLimitQ;
    public bool isProgressingPattern;

    private int recentPattern;

    // 패턴 1
    public GameObject cardSpadeQ; // bullet0Q
    public GameObject cardDiamondQ;
    public GameObject cardHeartQ;
    public GameObject cardClubQ;
    public int pattern1RepetitionQ;
    public float pattern1DelayQ;

    // 패턴 2
    public GameObject pigeonQ; // bullet2
    public int pattern2RepetitionQ;
    public float pattern2DelayQ;

    // 패턴 3
    public GameObject surpriseBoxQ; // surpriseBox
    public int maxSurpriseBoxQ;
    public int currentSurpriseBox;
    public bool canDuplicate;
    public float minimumRangeQ;
    public float maximumRangeQ;
    public Vector2 location;

    // 패턴 4
    public GameObject bullet4Q; // bullet4
    public int pattern4RepetitionQ;
    public float pattern4DelayQ;

    // 패턴 5
    public GameObject bullet5Q; // bullet5
    public int pattern5NumberQ;
    public float pattern5DelayQ; // bullet들 간의 Delay

    // 패턴 6
    public GameObject laserQ;
    public float pattern6DelayQ; // 마술봉을 뒤로 당긴 후 레이저를 날릴때까지의 Delay

    // 패턴 7
    public GameObject clubQ;
    public float pattern7StartNumberQ;
    public float pattern7StartDelayQ; // 대각선 탄환 Delay
    public float pattern7DelayQ; // 동서남북 가까운 곳까지 찍는 Delay
    public float sweepAngleVelocityQ;
    public float sweepingTimeQ;
    public Vector3 orthogonalDirection;

    // 패턴 8
    // TODO

    // Start is called before the first frame update
    void Start() {
        phase = 1;

        player = GameObject.Find("Player");

        health = maxHealthQ;
        isAlive = true;

        isMoving = false;

        isProgressingPattern = false;

        recentPattern = 0;

    }

    private void FixedUpdate() {
        FixRotate();
    }

    // Update is called once per frame
    void Update() {
        
        if (phase == 1 || phase == 3) {
            if (!isProgressingPattern) {
                if (isMoving) {
                    Move();
                    if (canFire) {
                        Fire();
                    }
                } else {
                    PatternByNumber();
                }
            }
        } else if (phase == 2) {
            // 퍼즐모드. 보스는 체력을 서서히 회복함
        }

        if (!isProgressingPattern) {
            CheckPhase();
        }
    }

    void FixRotate() {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    void Move() {
        direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * moveSpeedQ * Time.deltaTime);
    }

    void Fire() {
        StartCoroutine(WaitFire(fireDelayQ));
        Instantiate(bullet0Q, transform.position, Quaternion.FromToRotation(Vector3.up, direction));
    }

    IEnumerator WaitFire(float time) {
        canFire = false;
        yield return new WaitForSeconds(time);
        canFire = true;
    }
    
    void PatternByNumber() {
        isProgressingPattern = true; // 필요없는데 혹시 몰라서 씀
        int _number;

        do {
            _number = Random.Range(1, 9);
        } while (_number == recentPattern);
        
        switch (_number) {
            case 1:
                Pattern1();
                break;
            case 2:
                Pattern2();
                break;
            case 3:
                Pattern3();
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
            default:
                Debug.Log("Error");
                break;
        }

        recentPattern = _number;
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

    IEnumerator WaitPattern1 (float time) {
        yield return new WaitForSeconds(time);
        Pattern1Fire();
    }

    void Pattern1Fire() {
        GameObject _bullet = cardSpadeQ;
        for (int i = 0; i < 5; i++) {
            switch (Random.Range(0, 4)) {
                case 0:
                    _bullet = cardSpadeQ;
                    break;
                case 1:
                    _bullet = cardDiamondQ;
                    break;
                case 2:
                    _bullet = cardHeartQ;
                    break;
                case 3:
                    _bullet = cardClubQ;
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
            Pattern1FireBullet(_bullet, -30 + i * 15);
        }
    }

    void Pattern1FireBullet(GameObject bullet, float degree) {
        Vector3 _direction = (player.transform.position - transform.position).normalized;

        Quaternion _rotation = Quaternion.Euler(0, 0, degree);
        Vector3 _newDirection = _rotation * _direction;       

        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, _newDirection));
    }

    void Pattern2() {
        StartCoroutine(WaitPatternProgressing(pattern2DelayQ * (pattern2RepetitionQ - 1)));
        for(int i=0; i< pattern2RepetitionQ; i++) {
            StartCoroutine(WaitPattern2(pattern2DelayQ * i));
        }
    }

    IEnumerator WaitPattern2 (float time) {
        yield return new WaitForSeconds(time);
        Pattern2Fire();
    }

    void Pattern2Fire() {
        for(int i=0; i<18; i++) {
            Pattern2FireBullet(20 * i);
        }
    }

    void Pattern2FireBullet(int degree) {
        Vector3 _direction = Vector3.up;

        Quaternion _rotation = Quaternion.Euler(0, 0, degree);
        Vector3 _newDirection = _rotation * _direction;

        Instantiate(pigeonQ, transform.position, Quaternion.FromToRotation(Vector3.up, _newDirection));
    }

    void Pattern3() {
        if(currentSurpriseBox != 0) {
            return;
        }
        StartCoroutine(WaitPatternProgressing(0));
        DetermineBoxLocation();
        Instantiate(surpriseBoxQ, location, Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    void DetermineBoxLocation() {
        surpriseBoxQ.GetComponent<SpriteRenderer>().enabled = false;
        do {
            float _range = Random.Range(minimumRangeQ, maximumRangeQ);
            float _theta = Random.Range(0, 2 * Mathf.PI);

            location = _range * new Vector2(Mathf.Cos(_theta), Mathf.Sin(_theta));
        } while (surpriseBoxQ.GetComponent<SurpriseBox>().collided);
        surpriseBoxQ.GetComponent<SpriteRenderer>().enabled = true;

    }

    void Pattern4() {
        StartCoroutine(WaitPatternProgressing(pattern4DelayQ * (pattern4RepetitionQ - 1)));
        for(int i=0; i< pattern4RepetitionQ; i++) {
            StartCoroutine(WaitPattern4(pattern4DelayQ * i, i));
        }
    }

    IEnumerator WaitPattern4 (float time, int i) {
        yield return new WaitForSeconds(time);
        
        if (i % 2 == 0) {
            bullet4Q.GetComponent<Bullet4Move1>().isFollowing = true; // 짝수는 유도
        } else {
            bullet4Q.GetComponent<Bullet4Move1>().isFollowing = false; // 홀수는 정직
        } 
        Pattern4FireBullet();
    }

    void Pattern4FireBullet() {

        Vector3 _direction = (player.transform.position - transform.position).normalized;

        bullet4Q.GetComponent<Bullet4Move1>().direction = _direction;

        Instantiate(bullet4Q, transform.position, Quaternion.FromToRotation(Vector3.up, _direction));

    }

    void Pattern5() {
        StartCoroutine(WaitPatternProgressing(pattern5DelayQ * (pattern5NumberQ - 1)));
        for (int i = 0; i < pattern5NumberQ; i++) {
            StartCoroutine(WaitPattern5(pattern5DelayQ * i));
        }
    }

    IEnumerator WaitPattern5(float time) {
        yield return new WaitForSeconds(time);
        Pattern5Fire();
    }

    void Pattern5Fire() {
        for(int i=0; i<12; i++) {
            //Pattern5FireBullet(30 * i);
            Pattern5FireBullet(30 * i + 15);
        }
    }

    void Pattern5FireBullet(int degree) {
        Quaternion _rotation = Quaternion.Euler(0, 0, degree);

        Instantiate(bullet5Q, transform.position, _rotation);
    }

    void Pattern6() {
        StartCoroutine(WaitPatternProgressing(pattern6DelayQ + laserQ.GetComponent<Laser>().delayQ));
        StartCoroutine(WaitPattern6(pattern6DelayQ));
    }

    IEnumerator WaitPattern6(float time) {
        yield return new WaitForSeconds(time); // 애니메이션 선딜레이
        Pattern6Fire();
    }

    void Pattern6Fire() {
        Vector3 _direction = (player.transform.position - transform.position).normalized;

        Quaternion _rotation = Quaternion.LookRotation(Vector3.up, _direction);
        Instantiate(laserQ, transform.position, _rotation);
    }

    void Pattern7() {
        StartCoroutine(WaitPatternProgressing(pattern7DelayQ + sweepingTimeQ));
        StartCoroutine(WaitPattern7(pattern7DelayQ));
        for(int i=0; i< pattern7StartNumberQ; i++) {
            StartCoroutine(WaitPattern7Start(i * pattern7StartDelayQ));
        }
    }

    IEnumerator WaitPattern7Start(float time) {
        yield return new WaitForSeconds(time);

        Pattern7StartFire();
    }

    void Pattern7StartFire() {
        for(int i=0; i<4; i++) {
            Quaternion _rotation = Quaternion.Euler(0, 0, 45 + 90 * i);
            Instantiate(bullet0Q, transform.position, _rotation);
        }
    }

    IEnumerator WaitPattern7(float time) {
        yield return new WaitForSeconds(time);

        Instantiate(clubQ, transform.position, Quaternion.LookRotation(Vector3.up, orthogonalDirection));
    }
    
    void Pattern7Direction() {
        orthogonalDirection = Vector3.zero;
        Vector3 _direction = (player.transform.position - transform.position).normalized;

        float _max = Vector3.Dot(_direction, Vector3.up);
        orthogonalDirection = Vector3.up;
        if(Vector3.Dot(_direction, Vector3.right)> _max) {
            _max = Vector3.Dot(_direction, Vector3.right);
            orthogonalDirection = Vector3.right;
        }
        if (Vector3.Dot(_direction, Vector3.down) > _max) {
            _max = Vector3.Dot(_direction, Vector3.down);
            orthogonalDirection = Vector3.down;
        }
        if (Vector3.Dot(_direction, Vector3.left) > _max) {
            _max = Vector3.Dot(_direction, Vector3.left);
            orthogonalDirection = Vector3.left;
        }
    }

    void Pattern8() {
        // TODO
    }

    void CheckPhase() {
        // TODO, 체력에 따라서 Phase를 바꿀 예정
    }

    /*
    private void OnTriggerEnter2D(Collider2D collider) {
        
    }
    */
}

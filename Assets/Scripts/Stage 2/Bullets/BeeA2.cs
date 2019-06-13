using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeA2 : MonoBehaviour
{
    // TODO - 벌 (A타입)

    /* 1. 원거리 공격을 통해 공격이 가능하나 무력화까지만 가능하고 반드시 근접공격을 통해 마무리해야한다
       2. 시간이 지날수록 공격이 강화된다
       3. 무력화 상태에서 마무리를 하지 못한 채 지속시간이 다 될 경우 즉시 공격이 강화된다
       4. 필드 바깥 공간에서 생성되어 필드로 이동함

    일반 탄알 공격을 하며 시간이 지날수록 공격이 강화됨
        1. 플레이어 위치로 1발씩 끊어서 발사
        2. 플레이어 움직임을 따라서 흩뿌리듯이 3발씩 발사
        3. 플레이어 움직임을 따라서 흩뿌리듯이 6발씩 발사
    */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

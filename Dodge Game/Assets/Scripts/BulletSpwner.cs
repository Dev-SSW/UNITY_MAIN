﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpwner : MonoBehaviour
{

    public GameObject bulletPrefab; // 생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f; // 최소 생성 주기
    public float spawnRateMax = 3f; // 최대 생성 주기


    private Transform target; // 발사할 대상
    private float spawnRate;  // 생성주기
    private float timeAfterSpawn; //최근 생성 지점에서 지난 시간

    // Start is called before the first frame update
    void Start()
    {
        //최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;
        // 탄알 생성 간격을 spawnRatemin과 spawnratermax사이에서 랜덤지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //playerController컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //timerafterspawn  수정
        //deltatime 프레임 제한
        timeAfterSpawn += Time.deltaTime;

        //최근 생성 지점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if( timeAfterSpawn >= spawnRate)
        {
            //누적된 시간을 리셋
            timeAfterSpawn = 0f;

            //bullet prefab의 복제본을 
            //transform.position위치와 transform.ratation 회전으로 생성
            GameObject bullet =
                 Instantiate(bulletPrefab, transform.position, transform.rotation);
            //생성된 bullet게임 오브젝트의 정면 방향이  targer를 향하도록 회전
            bullet.transform.LookAt(target);
            //다음 번 생성 간격을 spawnratermin. spawnratemax사이에서 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);



        }

    }
}

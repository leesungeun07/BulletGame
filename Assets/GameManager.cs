using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UI 관련 라이브러리
using UnityEngine.SceneManagement;  // 씬 관련 라이브러리

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;  //게임 오버 시 활성화 텍스트
    public Text timeText;            //생존 시간 표시
    public Text recordText;          //최고 기록 표시

    private float surviveTime;       //생존 시간
    private bool isGameover;         //게임 오버 상태

    void Start()
    {
        surviveTime = 0;                         //생존 시간과 게임오버 상태 초기화
        isGameover = false;
    }

    void Update()
    {   //게임 오버가 아닌 동안
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;               //생존 시간 갱신
            timeText.text = "Time: " + (int)surviveTime; //갱신한 생존시간을 표시

        }
        else
        {
            if (Input.GetKey(KeyCode.R))
            {     //게임 오버 상태에서 R키를 누른 경우
                SceneManager.LoadScene("SampleScene");  // SampleScene 로드
                                                        //씬 이름이 Cartoon Cat이면 “Cartoon Cat”을 쓰세요.
            }
        }
    }

    // 현재 게임을 게임오버 상태로 변경하는 함수
    public void EndGame()
    {

        isGameover = true;            //현재 상태를 게임 오버 상태로 전환
        gameoverText.SetActive(true); //게임 오버 텍스트 활성화
                                      //BestTime 키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");
        //이전까지의 최고 기록보다 현재 생존 시간이 더 크면
        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;   //최고 기록을 현재 생존 시간 값으로 변경
                                      //변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        //최고 기록을 recordText 텍스트 컴포넌트 이용해 표시
        recordText.text = "Best Time: " + (int)bestTime;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SingletoneMake
    public static GameManager instance = null;
    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@GameManager");
            instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }
    #endregion

    [HideInInspector] public int totalEnergy = 100;     //전체 에너지
    [HideInInspector] public int curEnergy;             //현재 에너지

    [HideInInspector] public float runningTime;         //어플 진행 시간

    public int point = 0;                               //게임 내 포인트
    public int gameMoney = 0;                           //게임 머니

    public bool isEnegyZero;                            //에너지 제로 판별 여부

    private void Update()
    {
        runningTime += Time.realtimeSinceStartup;
        PlusCurEnergy();
        CurEnergyZero();
    }

    public void PlusCurEnergy()                    //5분마다 에너지 채워지는 함수(5분마다 1씩)
    {
        if (runningTime > 20)                 //에너지 채워지는 시간(일단은 20초로) 개발 완료후 300초로 변경
        {
            curEnergy += 1;
            runningTime = 0;
        }
        else
            return;
    }

    public void CurEnergyZero()              //에너지 제로시 물주기, 영양제, 수확, 칭찬하기 불가
    {
        if (curEnergy <= 0)
        {
            isEnegyZero = true;
        }
        else
            return;
    }
}

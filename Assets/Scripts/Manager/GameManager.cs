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
     public int curEnergy = 100;             //현재 에너지

    public int runningTime;         //어플 진행 시간

    public int curPoint = 0;                               //게임 내 포인트
    public int curGameMoney = 1000;                           //게임 머니

    public bool isEnegyZero;                            //에너지 제로 판별 여부

    public WaitForSecondsRealtime waitFor20Seconds = new WaitForSecondsRealtime(20.0f);

    MyPlantManager myPlantManager = MyPlantManager.GetInstance();

    private void Start()
    {
        StartCoroutine("PlusCurEnergy");
    }

    private void Update()
    {
        runningTime = (int)Time.realtimeSinceStartup;


        CurEnergyZero();
    }

/*    public void PlusCurEnergy()                    //5분마다 에너지 채워지는 함수(5분마다 1씩)
    {
        if (runningTime % 20 == 0)                 //에너지 채워지는 시간(일단은 20초로) 개발 완료후 300초로 변경
        {
            if (curEnergy > totalEnergy)
            {
                curEnergy = totalEnergy;
            }
            else
            {
                curEnergy += 1;
            }
        }
        else
            return;
    }*/

    IEnumerator PlusCurEnergy()                      //5분마다 에너지 채워지는 함수(5분마다 1씩)
    {
        while (true)
        {
            yield return waitFor20Seconds;          //에너지 채워지는 시간(일단은 20초로) 개발 완료후 300초로 변경

            if (curEnergy > totalEnergy)
            {
                curEnergy = totalEnergy;
            }
            else
            {
                curEnergy += 1;
            }
        }
    }

    public void CurEnergyZero()              //에너지 제로시 물주기, 영양제, 수확, 칭찬하기 불가
    {
        if (curEnergy <= 0)
        {
            curEnergy = 0;
            isEnegyZero = true;
        }
        else
            isEnegyZero = false;
    }

    public bool SpendGameMoney(int priceGM)   //현재 소지금과 가격을 비교해서 구매 가능 여부 판단 함수
    {
        if(curGameMoney >= priceGM)
        {
            curGameMoney -= priceGM;
            return true;
        }

        return false;
    }

    public bool SpendPoint(int price_Point)   //현재 소지 포인트와 가격을 비교해서 구매 가능 여부 판단 함수
    {
        if (curPoint >= price_Point)
        {
            curPoint -= price_Point;
            return true;
        }

        return false;
    }

}

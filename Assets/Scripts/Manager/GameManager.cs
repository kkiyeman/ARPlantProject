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

    [HideInInspector] public int totalEnergy = 100;     //��ü ������
     public int curEnergy = 100;             //���� ������

    public int runningTime;         //���� ���� �ð�

    public int curPoint = 0;                               //���� �� ����Ʈ
    public int curGameMoney = 1000;                           //���� �Ӵ�

    public bool isEnegyZero;                            //������ ���� �Ǻ� ����

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

/*    public void PlusCurEnergy()                    //5�и��� ������ ä������ �Լ�(5�и��� 1��)
    {
        if (runningTime % 20 == 0)                 //������ ä������ �ð�(�ϴ��� 20�ʷ�) ���� �Ϸ��� 300�ʷ� ����
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

    IEnumerator PlusCurEnergy()                      //5�и��� ������ ä������ �Լ�(5�и��� 1��)
    {
        while (true)
        {
            yield return waitFor20Seconds;          //������ ä������ �ð�(�ϴ��� 20�ʷ�) ���� �Ϸ��� 300�ʷ� ����

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

    public void CurEnergyZero()              //������ ���ν� ���ֱ�, ������, ��Ȯ, Ī���ϱ� �Ұ�
    {
        if (curEnergy <= 0)
        {
            curEnergy = 0;
            isEnegyZero = true;
        }
        else
            isEnegyZero = false;
    }

    public bool SpendGameMoney(int priceGM)   //���� �����ݰ� ������ ���ؼ� ���� ���� ���� �Ǵ� �Լ�
    {
        if(curGameMoney >= priceGM)
        {
            curGameMoney -= priceGM;
            return true;
        }

        return false;
    }

    public bool SpendPoint(int price_Point)   //���� ���� ����Ʈ�� ������ ���ؼ� ���� ���� ���� �Ǵ� �Լ�
    {
        if (curPoint >= price_Point)
        {
            curPoint -= price_Point;
            return true;
        }

        return false;
    }

}

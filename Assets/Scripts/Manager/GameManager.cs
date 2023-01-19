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
    [HideInInspector] public int curEnergy;             //���� ������

    [HideInInspector] public float runningTime;         //���� ���� �ð�

    public int point = 0;                               //���� �� ����Ʈ
    public int gameMoney = 0;                           //���� �Ӵ�

    public bool isEnegyZero;                            //������ ���� �Ǻ� ����

    private void Update()
    {
        runningTime += Time.realtimeSinceStartup;
        PlusCurEnergy();
        CurEnergyZero();
    }

    public void PlusCurEnergy()                    //5�и��� ������ ä������ �Լ�(5�и��� 1��)
    {
        if (runningTime > 20)                 //������ ä������ �ð�(�ϴ��� 20�ʷ�) ���� �Ϸ��� 300�ʷ� ����
        {
            curEnergy += 1;
            runningTime = 0;
        }
        else
            return;
    }

    public void CurEnergyZero()              //������ ���ν� ���ֱ�, ������, ��Ȯ, Ī���ϱ� �Ұ�
    {
        if (curEnergy <= 0)
        {
            isEnegyZero = true;
        }
        else
            return;
    }
}

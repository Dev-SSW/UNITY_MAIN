using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool canPlayerMove = true; //�÷��̾��� ������ ����

    public static bool isOpenInventory = false; //�κ��丮 Ȱ��ȭ

    public static bool isOpenCraftManual = false; //����޴�â Ȱ��ȭ

    public static bool isBuilding = false;

    public static bool isNight = false;
    public static bool isWater = false;

    private WeaponManager theWM;
    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        theWM = FindObjectOfType<WeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpenInventory || isOpenCraftManual)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            canPlayerMove = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            canPlayerMove = true;
        }

        if (isWater)
        {
            if (flag == false)
            {
                StopAllCoroutines();
                StartCoroutine(theWM.WeaponInCoroutine());
                flag = true;
            }
        }
        else
        {
            if (flag == true)
            {
                flag = false;
                theWM.WeaponOut();
            }
        }
    }
}
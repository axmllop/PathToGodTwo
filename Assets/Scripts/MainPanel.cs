using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    Button btn_start;

    Button btn_shop;
    Button btn_rank;
    Button btn_sound;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        btn_start = transform.Find("Btn_Start").GetComponent<Button>();
        btn_start.onClick.AddListener(OnStartButtonClik);
        btn_shop = transform.Find("Btns/Btn_Shop").GetComponent<Button>();
        btn_shop.onClick.AddListener(OnShopButtonClik);
        btn_rank = transform.Find("Btns/Btn_Rank").GetComponent<Button>();
        btn_rank.onClick.AddListener(OnRankButtonClik);
        btn_sound = transform.Find("Btns/Btn_Sound").GetComponent<Button>();
        btn_sound.onClick.AddListener(OnSoundButtonClik);

    }
    /// <summary>
    /// 开始点击按钮
    /// </summary>
    private void OnStartButtonClik()
    {
        GameMananger.Intance.isGameStart = true;
        EventCenter.Broadcast(EventDefine.ShowGamePanel);
        gameObject.SetActive(false);
    }
    /// <summary>
    /// 商店点击按钮
    /// </summary>
    private void OnShopButtonClik()
    {

    }
    /// <summary>
    /// 排名点击按钮
    /// </summary>
    private void OnRankButtonClik()
    {

    }
    /// <summary>
    /// 音效点击按钮
    /// </summary>
    private void OnSoundButtonClik()
    {

    }

}

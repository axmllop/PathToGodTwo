using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePanel : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        
    }
    Text txt_Score;
    Text txt_Diamond;
    Button btn_Play;
    Button btn_Pause;

    private void Awake()
    {
        EventCenter.AddListener(EventDefine.ShowGamePanel, Show);
        Init();
    }
    void Init()
    {

        txt_Score = transform.Find("txt_Score").GetComponent<Text>();
        txt_Diamond = transform.Find("Diamond/txt_Diamond").GetComponent<Text>();
        btn_Play = transform.Find("Btn_Play").GetComponent<Button>();
        btn_Play.onClick.AddListener(OnPlayButtonClick);
        btn_Play.gameObject.SetActive(false);
        btn_Pause = transform.Find("Btn_Pause").GetComponent<Button>();
        btn_Pause.onClick.AddListener(OnPauseButtonClik);
        gameObject.SetActive(false);

    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventDefine.ShowGamePanel, Show);

    }
    void Show()
    {
        gameObject.SetActive(true);
    }
    /// <summary>
    /// 开始点击按钮
    /// </summary>
    private void OnPlayButtonClick()
    {
        btn_Pause.gameObject.SetActive(true);
        btn_Play.gameObject.SetActive(false);
    }
    /// <summary>
    /// 暂停点击按钮
    /// </summary>
    private void OnPauseButtonClik()
    {
        btn_Pause.gameObject.SetActive(false);
        btn_Play.gameObject.SetActive(true);
    }
}

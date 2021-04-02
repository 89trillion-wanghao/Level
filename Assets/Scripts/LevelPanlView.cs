using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 段位奖励窗口
/// </summary>
public class LevelPanlView : MonoBehaviour
{
    public Text scoreText;
    public Text levelText;
    public Text coinText;
    public GameObject contentGO;
    
    private RewardPrefabItem rewardItem;                // 奖励Item
    private List<RewardPrefabItem> rewardItemList;      // 奖励Item列表               
    
    // 初始化界面
    public void InitItem(int coin, int[] array)
    {
        rewardItem = Resources.Load<RewardPrefabItem>(Constant.REWARDPREFAB_PATH);
        rewardItemList = new List<RewardPrefabItem>();
        for (int i = 0; i < array.Length; i++)
        {
            RewardPrefabItem tempGO = Instantiate<RewardPrefabItem>(rewardItem, contentGO.transform);
            tempGO.levelTxt.text = array[i].ToString();
            tempGO.getBtn.onClick.AddListener(() =>
            {
                OnGetButtonClick(tempGO.getBtn,tempGO.btnTxt, coin);
            });
            tempGO.gameObject.SetActive(false);
            rewardItemList.Add(tempGO);
        }
    }
    
    // 段位界面
    public void InitPanel(int scoreNum, string levelString, int startIndex, int endIndex)
    {
        levelText.text = levelString;
        scoreText.text = scoreNum.ToString();
        ShowItem(startIndex, endIndex);
    }

    // 重置界面
    public void ResetPanel(int scoreNum, string levelString, int index)
    {
        levelText.text = levelString;
        scoreText.text = scoreNum.ToString();
        ResetItem(index);
    }
    
    // 展示奖励Item
    private void ShowItem(int startIndex,int endIndex)
    {
        for (int i = startIndex; i < endIndex; i++)
        {
            rewardItemList[i].gameObject.SetActive(true);
            rewardItemList[i].transform.SetSiblingIndex(0);
        }
    }
    
    // 重置奖励Item
    private void ResetItem(int Index)
    {
        for (int i =0; i < Index; i++)
        {
            rewardItemList[i].gameObject.SetActive(true);
            ResetButton(rewardItemList[i].getBtn,rewardItemList[i].btnTxt);
            rewardItemList[i].transform.SetSiblingIndex(0);
        }

        for (int i = Index; i < 8; i++)
        {
            ResetButton(rewardItemList[i].getBtn,rewardItemList[i].btnTxt);
            rewardItemList[i].gameObject.SetActive(false);
        }
    }
    
    // 领取奖励按钮响应
    private void OnGetButtonClick(Button tempBtn,Text btnTxt,int coin)
    {
        coinText.text = (Int32.Parse(coinText.text) + coin).ToString();
        btnTxt.text = Constant.BUTTON_GETED;
        tempBtn.interactable = false;
    }

    // 重置奖励按钮
    private void ResetButton(Button tempBtn,Text tempTxt)
    {
        tempTxt.text =Constant.BUTTON_GET;
        tempBtn.interactable = true;
    }
}

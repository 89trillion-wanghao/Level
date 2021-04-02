using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 控制监听,控制层
/// </summary>
public class GameControl : MonoBehaviour
{
    public Text scoreText;
    public Button plusBtn;
    public Button refreshBtn;
    public Button levelBtn;
    public LevelPanlView level; 
    
    private int score;                              // 分数
    private int currentScore;                       // 保存现在的分数
    private int startIndex;                         // 开始索引                         
    private int endIndex;                           // 结束索引
    
    void Start()
    {
        // 初始化段位窗口
        level.InitItem(Model.Instance().CoinNum,Model.Instance().GetRewardArray());
        // 为按钮添加监听
        plusBtn.onClick.AddListener(OnPlusScoreBtnClick);
        refreshBtn.onClick.AddListener(OnRefreshBtnClick);
        levelBtn.onClick.AddListener(OnLevelButtonClick);
    }
    
    // 加分按钮监听
    private void OnPlusScoreBtnClick()
    {
        scoreText.text = Model.Instance().PlusScore().ToString();
    }
    
    // 刷新按钮监听
    private void OnRefreshBtnClick()
    {

        int refreshedScore = Model.Instance().RefreshMode();
        scoreText.text = refreshedScore.ToString();
        level.gameObject.SetActive(true);
        
        level.ResetPanel(refreshedScore,Model.Instance().CalculateLevel(),CalculateIndex(refreshedScore));
        currentScore=refreshedScore;
    }
    
    // 段位按钮监听
    private void OnLevelButtonClick()
    {
        level.gameObject.SetActive(true);
        score = Model.Instance().Score;
        CalculateStartEndIndex();
        level.InitPanel(score,Model.Instance().CalculateLevel(),startIndex,endIndex);
        currentScore = score;
    }

    // 计算段位的起止索引
    private void CalculateStartEndIndex()
    {
        startIndex = (currentScore-4000) / 200-(currentScore - 4000) / 1000;
        if (startIndex < 0)
        {
            startIndex = 0;
        }
        endIndex = (score - 4000) / 200-(score - 4000) / 1000;
    }
    
    // 计算重置后段位索引
    private int CalculateIndex(int num)
    {
        return (num - 4000) / 200 - (num - 4000) / 1000;
    }
    
}

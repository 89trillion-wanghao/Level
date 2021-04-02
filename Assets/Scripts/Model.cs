/// <summary>
/// 段位数据
/// </summary>
public class Model
{
    private int score=3666;                 // 当前分数
    private int maxScore = 6000;            // 最大分数
    private int passScore = 4000;           // 起始奖励分数
    private int coinNum=100;                // 金币奖励
    private int smallLevel;                 // 段位水平
    private int[] rewardArray;              // 奖励数组
    
    private static Model model;             // 单例
    public static Model Instance()
    {
        if (model == null)
        {
            model = new Model();
        }
        return model;
    }
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
    public int CoinNum
    {
        get
        {
            return coinNum;
        }
        set
        {
            coinNum = value;

        }
    }
    
    // 计算段位
    public string CalculateLevel()
    {
        if (Score >= 5000)
        {
            smallLevel = (Score - 5000) / 200+1;
            return  "钻石"+smallLevel;
        }
        else if(Score>=4000&&Score<5000)
        {
            smallLevel = (Score - 4000) / 200+1;
            return  "黄金"+smallLevel;
        }
        else
        {
            return "";
        }
        
    }
    
    // 分数增加
    public int PlusScore()
    {
        int num = Score + 100;
        if (num > 6000)
        {
            return Score=6000;
        }
        else
        {
            return Score=num;
        }
    }
    
    // 赛季更新数据
    public int RefreshMode()
    {
        if (Score > 4000)
        {
           return Score=4000 + (Score - 4000) / 2;
        }
        else
        {
            return Score;
        }
    }
    
    // 获取奖励数组
    public int[] GetRewardArray()
    {
        int length = (maxScore - passScore) / 200 - (maxScore - passScore) / 1000;
        rewardArray = new int[length];
        int num = passScore;
        for (int i = 0; i < rewardArray.Length; i++)
        {
            num = num + 200;
            if (num % 1000 == 0)
            {
                num = num + 200;
            }
            rewardArray[i] = num;
        }
        return rewardArray;
    }
    
}

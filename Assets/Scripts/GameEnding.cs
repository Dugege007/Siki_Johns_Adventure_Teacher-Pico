using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    //游戏胜利时，图片淡入淡出的时间
    public float fadeDuration = 1f;
    //显示的时间
    public float displayDuration = 1f;
    //游戏人物
    public GameObject player;
    //游戏胜利时画布背景
    public CanvasGroup exitBG;
    //游戏失败时画布背景
    public CanvasGroup failBG;

    //游戏是否胜利
    private bool isExit;
    //游戏是否失败
    private bool isFail;

    //定义计时器用于图片的渐变和完全显示
    public float timer;

    //音频组件
    public AudioSource winAudio;
    public AudioSource failAudio;

    //控制音效只播放一次
    private bool isPlay = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //检测到玩家
            isExit = true;
        }
    }

    private void Update()
    {
        //游戏胜利
        if (isExit)
        {
            //显示游戏胜利图片
            EndLevel(exitBG, false, winAudio);
        }
        else if (isFail)
        {
            //显示游戏失败图片
            EndLevel(failBG, true, failAudio);
        }
    }

    public void Caught()
    {
        isFail = true;
    }

    // 游戏胜利或失败时执行的方法
    private void EndLevel(CanvasGroup canvasGroup, bool doRestart, AudioSource audioSource)
    {
        //音效播放
        if (!isPlay)
        {
            audioSource.Play();
            isPlay = true;
        }

        //计时器开始计时
        timer += Time.deltaTime;
        //控制CanvasGroup的不透明度
        canvasGroup.alpha = timer / fadeDuration;

        //游戏胜利或失败图片渐变、显示一段时间后，游戏结束
        if (timer > fadeDuration + displayDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else if (!doRestart)
            {
                Application.Quit();
            }
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    //��Ϸʤ��ʱ��ͼƬ���뵭����ʱ��
    public float fadeDuration = 1f;
    //��ʾ��ʱ��
    public float displayDuration = 1f;
    //��Ϸ����
    public GameObject player;
    //��Ϸʤ��ʱ��������
    public CanvasGroup exitBG;
    //��Ϸʧ��ʱ��������
    public CanvasGroup failBG;

    //��Ϸ�Ƿ�ʤ��
    private bool isExit;
    //��Ϸ�Ƿ�ʧ��
    private bool isFail;

    //�����ʱ������ͼƬ�Ľ������ȫ��ʾ
    public float timer;

    //��Ƶ���
    public AudioSource winAudio;
    public AudioSource failAudio;

    //������Чֻ����һ��
    private bool isPlay = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //��⵽���
            isExit = true;
        }
    }

    private void Update()
    {
        //��Ϸʤ��
        if (isExit)
        {
            //��ʾ��Ϸʤ��ͼƬ
            EndLevel(exitBG, false, winAudio);
        }
        else if (isFail)
        {
            //��ʾ��Ϸʧ��ͼƬ
            EndLevel(failBG, true, failAudio);
        }
    }

    public void Caught()
    {
        isFail = true;
    }

    // ��Ϸʤ����ʧ��ʱִ�еķ���
    private void EndLevel(CanvasGroup canvasGroup, bool doRestart, AudioSource audioSource)
    {
        //��Ч����
        if (!isPlay)
        {
            audioSource.Play();
            isPlay = true;
        }

        //��ʱ����ʼ��ʱ
        timer += Time.deltaTime;
        //����CanvasGroup�Ĳ�͸����
        canvasGroup.alpha = timer / fadeDuration;

        //��Ϸʤ����ʧ��ͼƬ���䡢��ʾһ��ʱ�����Ϸ����
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

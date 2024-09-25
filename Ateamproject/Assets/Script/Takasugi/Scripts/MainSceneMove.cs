using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


// タイトル画面の進行を制御します。
public class MainSceneMove: MonoBehaviour
{
    private bool isLoadable = false;// 次のシーンを読み込み可能な場合はtrue、それ以外はfalse
    private bool isTimeUp = false;
    private bool isStart = false;
    private TimeCount timeCount;
    [SerializeField] private MultiPlay multiPlay;
    private CharactorRoot charactorRoot;
    GameObject charRootObj;

    private void Start()
    {
        charRootObj = GameObject.Find("Charactors");
        charactorRoot = charRootObj.GetComponent<CharactorRoot>();
        
        isStart = true;
        timeCount = GetComponent<TimeCount>();
        
    }

    // ２秒待機後に次のシーンを読込み可能にします。
    IEnumerator OnStart()
    {
        yield return new WaitForSeconds(2);
        isLoadable = true;
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            StartCoroutine(OnStart());
        }

        if (timeCount.InGameTime() <= 0)
        {
            isTimeUp = true;
        }

        if (isLoadable|| isTimeUp)
        {
            SceneManager.LoadScene("ResultScene");
        }

        if (multiPlay.IsFinish)
        {
            SceneManager.LoadScene("Result3PScene");
        }
    }
}

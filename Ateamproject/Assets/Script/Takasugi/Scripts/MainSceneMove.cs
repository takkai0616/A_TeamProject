using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


// タイトル画面の進行を制御します。
public class MainSceneMove: MonoBehaviour
{

    // 次のシーンを読み込み可能な場合はtrue、それ以外はfalse
    private bool isLoadable = false;

    private bool isTimeUp = false;

    public bool isStart = false;

    private TimeCount timeCount;

    private void Start()
    {
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
    }
}

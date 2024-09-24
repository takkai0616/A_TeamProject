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
    private GameObject charactorObject;
    private Transform charactorTrans;
    private Player[] players;



    private void Start()
    {
        charactorObject = GameObject.Find("Charactors");
        charactorTrans = charactorObject.GetComponent<Transform>();
        players = new Player[charactorTrans.childCount];
        for (int i = 0; i < charactorTrans.childCount; i++)
        {
            Transform child = charactorTrans.GetChild(i);
            players[i] = child.GetComponent<Player>();
        }
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

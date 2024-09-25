using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
// タイトル画面の進行を制御します。
public class ResultSceneMove: MonoBehaviour
{

    [SerializeField]
    private Animator animator;
    // 次のシーンを読み込み可能な場合はtrue、それ以外はfalse
    private  bool isLoadable = false;

    private bool isSelect = true;

    [SerializeField]
    private GameObject[] selectArrow;

   

    // ２秒待機後に次のシーンを読込み可能にします。
    IEnumerator OnStart()
    {
        yield return new WaitForSeconds(2);
        isLoadable = true;
    }


    private void Update()
    {
        if (isSelect)
        {   //ゲーム開始

            //選択の表示変えたい
            selectArrow[0].SetActive(true);
            selectArrow[1].SetActive(false);

            if (isLoadable)
            {
                SceneManager.LoadScene("MainScene");
            }

            if (Input.GetKey(KeyCode.RightArrow))
            { isSelect = false; }
        }

        if (!isSelect)
        {   //終了

            //選択の表示変えたい
            selectArrow[0].SetActive(false);
            selectArrow[1].SetActive(true);

            if (isLoadable)
            {
                SceneManager.LoadScene("TitleScene");
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            { isSelect = true; }
        }


        //決定
        if (Input.GetKey(KeyCode.Return))
        {
            StartCoroutine(OnStart());
            animator.SetTrigger("PushResult");
          
        }


    }
}

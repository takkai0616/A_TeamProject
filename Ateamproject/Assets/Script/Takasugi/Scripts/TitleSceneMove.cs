using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

// タイトル画面の進行を制御します。
public class TitleSceneMove : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    // 次のシーンを読み込み可能な場合はtrue、それ以外はfalse
    private bool isLoadable = false;

    private bool isSelect = true;

    private bool isPush = false;

    [SerializeField]
    private GameObject[] selectArrow;


    // ２秒待機後に次のシーンを読込み可能にします。
    IEnumerator OnStart()
    {
        yield return new WaitForSeconds(2);
        isLoadable = true;
    }
    private void Start()
    {
       isPush = false;
    }

    private void Update()
    {
        var leftStickValue = Gamepad.all[0].leftStick.ReadValue();//スティックを倒した度合い

        if (isSelect)
        {   //ゲーム開始

            //選択の表示変えたい
            selectArrow[0].SetActive(true);
            selectArrow[1].SetActive(false);

            if (isLoadable)
            {
                SceneManager.LoadScene("SelectScene");
            }
                if (leftStickValue.y < 0&&!isPush)
                { isSelect = false; }

        }

        if (!isSelect)
        {   //終了

            //選択の表示変えたい
            selectArrow[0].SetActive(false);
            selectArrow[1].SetActive(true);

            if (isLoadable)
            {
                Application.Quit();
            }
            else
            {
                if (leftStickValue.y > 0 && !isPush)
                { isSelect = true; }
            }
        }



        //決定
        if (Gamepad.all[0].bButton.wasPressedThisFrame)
        {
            StartCoroutine(OnStart());
            animator.SetTrigger("Push");
            isPush = true;
        }
        
        
    }
}

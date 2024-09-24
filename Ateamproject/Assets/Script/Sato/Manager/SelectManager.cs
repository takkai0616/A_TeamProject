using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private CharactorRoot charactorRoot;

    private bool[] isDicision;//決定したかどうか
    private bool pressStart;//スタートボタンを押したか

    private void Start()
    {
        charactorRoot.OnStart();
        isDicision = new bool[charactorRoot.ChildCount];
        pressStart = false;

        for (int i = 0; i < isDicision.Length; ++i)
        {
            isDicision[i] = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (!Gamepad.all[i].aButton.wasPressedThisFrame) continue;//Aボタンが押されていない

            if (isDicision[i]) continue;//すでに決定されている

            CommonData.useCharactorNum[i] = charactorRoot.GetCharactorNum();
            isDicision[i] = true;
            break;
        }

        //全てのコントローラーが決定し終わったら
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (!isDicision[i]) return;
        }

        //始めるボタンを押したか判定
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (!Gamepad.all[i].bButton.wasPressedThisFrame) continue;
            pressStart = true;
        }

        if (!pressStart) return;  //スタートフラグが立っているか

        charactorRoot.InitializationChildTrans();//キャラクターのTransformを初期化
        charactorRoot.OnDontDestroyScene();  //キャラクターをDontDestroyに上げる
        SceneManager.LoadScene("MainScene");//シーン遷移
    }
}
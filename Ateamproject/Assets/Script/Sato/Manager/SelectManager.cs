using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    [SerializeField] CharactorRoot charactorRoot;
    //キャラクターオブジェクト
    [SerializeField] PlayerNumber[] charObj;

    bool[] isDicision;//決定したかどうか
    bool pressStart;//スタートボタンを押したか

    void Start()
    {
        isDicision = new bool[charObj.Length];
        pressStart = false;

        for (int i = 0; i < isDicision.Length; ++i)
        {
            isDicision[i] = false;
        }       
    }

    // Update is called once per frame
    void Update()
    {
        

        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (!Gamepad.all[i].aButton.wasPressedThisFrame) continue;//Aボタンが押されていない

            if (isDicision[i]) continue;//すでに決定されている

            charObj[i].Number = i;//キャラクタにコントローラーの番号を記録
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

        //キャラクターの傾きと位置を調整
        Transform parentTrans = charactorRoot.transform;
        for(int i = 0; i < parentTrans.childCount; ++i)
        {
            Transform childTrans = parentTrans.GetChild(i);
            Transform grandChild = childTrans.GetChild(0);
            grandChild.localPosition = Vector3.zero;
            grandChild.localRotation = Quaternion.identity;
        }

        charactorRoot.OnDontDestroyScene();  //キャラクターをDontDestroyに上げる
        SceneManager.LoadScene("MainScene");//シーン遷移
    }
}
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    //キャラクターオブジェクト
    [SerializeField] PlayerNumber[] charObj;

    bool[] isDicision;

    void Start()
    {
        isDicision = new bool[charObj.Length];

        for (int i = 0; i < isDicision.Length; ++i)
        {
            isDicision[i] = false;
        }       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = 0; i < charObj.Length; i++)
            {
                Debug.Log(i + "は" + CommonData.useCharactorNum[i]);
            }
        }

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

        SceneManager.LoadScene("SatoScene");
    }
}
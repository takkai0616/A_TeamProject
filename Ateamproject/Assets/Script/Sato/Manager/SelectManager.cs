using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private CharactorRoot charactorRoot;//プレイヤーキャラクターの親
    [SerializeField] private Image[] preDecisionInfoImage;//選択する前のテキストイメージ
    [SerializeField] private Image[] oKImage;//OKを表示するイメージ
    [SerializeField] private Sprite[] oKSprite;//OK/NO スプライト

    private bool[] isDecision;//決定したかどうか
    private bool[] pressStart;//スタートボタンを押したか

    private void Start()
    {
        charactorRoot.OnStart();
        isDecision = new bool[charactorRoot.ChildCount];
        pressStart = new bool[charactorRoot.ChildCount];

        for (int i = 0; i < isDecision.Length; ++i)
        {
            isDecision[i] = false;
            pressStart[i] = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        SelectCharactor();
        CancelCharactor();

        //全てのコントローラーが決定し終わったら
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (!isDecision[i]) return;
        }

        //始めるボタンを押したか判定
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (!Gamepad.all[i].startButton.wasPressedThisFrame) continue;
            pressStart[i] = true;
        }

        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (!pressStart[i]) return;
        }
        charactorRoot.OnDontDestroyScene();  //キャラクターをDontDestroyに上げる
        SceneManager.LoadScene("MainScene");//シーン遷移
    }

    private void SelectCharactor()
    {
        //ToDoマジックナンバー削除
     
        int _num = -1;

        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (Gamepad.all[i].bButton.wasPressedThisFrame)
            {
                _num = 0;
            }
            else if (Gamepad.all[i].aButton.wasPressedThisFrame)
            {
                _num = 1;
            }
            else if (Gamepad.all[i].yButton.wasPressedThisFrame)
            {
                _num = 2;
            }
            else if (Gamepad.all[i].xButton.wasPressedThisFrame)
            {
                _num = 3;
            }
            else
            {
                continue;
            }

            if (!JudgeAvailability(_num, i)) return;

            preDecisionInfoImage[_num].enabled = false;
            charactorRoot.ActivateSelectPlayer(_num);
            CommonData.useCharactorNum[i] = _num;
            charactorRoot.SetIsDecidion(_num, true);
            isDecision[i] = true;
            break;
        }
    }

    private void CancelCharactor()
    {
        //キャンセル
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (!Gamepad.all[i].selectButton.wasPressedThisFrame) continue;
            if (!isDecision[i]) continue;
            preDecisionInfoImage[CommonData.useCharactorNum[i]].enabled = true;
            charactorRoot.InActivateSelectPlayer(CommonData.useCharactorNum[i]);
            charactorRoot.SetIsDecidion(CommonData.useCharactorNum[i], false);
            CommonData.useCharactorNum[i] = -1;
            isDecision[i] = false;
        }
    }

    //
    private bool JudgeAvailability(int _num, int _controllerNum)
    {
        if (charactorRoot.GetIsDecision(_num)) return false;
        if (isDecision[_controllerNum]) return false;

        return true;
    }
}
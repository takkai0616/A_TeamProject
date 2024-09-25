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
    [SerializeField] private AudioSource audioSource;

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
            oKImage[i].sprite = oKSprite[0];
        }
    }

    // Update is called once per frame
    private void Update()
    {
        PressedSelectButton();
        CancelCharactor();

        ////全てのコントローラーが決定し終わったら
        //for (int i = 0; i < Gamepad.all.Count; i++)
        //{
        //    if (!isDecision[i]) return;
        //}

        //始めるボタンを押したか判定
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (!Gamepad.all[i].startButton.wasPressedThisFrame) continue;
            if(!isDecision[i]) continue;
            SEManager.instance.DecisionSEPlaying(audioSource);
            pressStart[i] = true;
            oKImage[CommonData.useCharactorNum[i]].sprite = oKSprite[1];
        }

        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (!pressStart[i]) return;
        }
        charactorRoot.OnDontDestroyScene();  //キャラクターをDontDestroyに上げる
        SceneManager.LoadScene("MainScene");//シーン遷移
    }

    private void PressedSelectButton()
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

            //animationを再生
            if (isDecision[i] && (CommonData.useCharactorNum[i] == _num))//コントローラーが決定済みかつ登録されたボタンの番号と入力されたボタンが一致していたら
            {
                return;
            }

            if (!JudgeAvailability(_num, i)) return;//コントローラーとキャラクターが未決定か判定

            SEManager.instance.DecisionSEPlaying(audioSource);
            preDecisionInfoImage[_num].enabled = false;//ボタンを押してくださいを表示するImageを消す
            charactorRoot.ActivateSelectPlayer(_num);//キャラクターのMeshRendererをアクティブにする
            CommonData.useCharactorNum[i] = _num;//コントローラーの番号の配列の位置にボタンの番号を登録
            charactorRoot.SetIsDecidion(_num, true);//キャラクター自身が決められていると設定
            isDecision[i] = true;//コントローラーが決められていると設定
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
            SEManager.instance.CancelSEPlaying(audioSource);
            preDecisionInfoImage[CommonData.useCharactorNum[i]].enabled = true;
            charactorRoot.InActivateSelectPlayer(CommonData.useCharactorNum[i]);
            charactorRoot.SetIsDecidion(CommonData.useCharactorNum[i], false);
            oKImage[CommonData.useCharactorNum[i]].sprite = oKSprite[0];
            CommonData.useCharactorNum[i] = -1;
            pressStart[i] = false;
            isDecision[i] = false;
        }
    }
    
    /// <summary>
    /// キャラクターとコントローラーが未設定か確認
    /// </summary>
    /// <param name="_num"></param>
    /// <param name="_controllerNum"></param>
    /// <returns></returns>
    private bool JudgeAvailability(int _num, int _controllerNum)
    {
        if (charactorRoot.GetIsDecision(_num)) return false;
        if (isDecision[_controllerNum]) return false;

        return true;
    }
}
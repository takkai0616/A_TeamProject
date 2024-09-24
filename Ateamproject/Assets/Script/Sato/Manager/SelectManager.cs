using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private CharactorRoot charactorRoot;//�v���C���[�L�����N�^�[�̐e
    [SerializeField] private Image[] preDecisionInfoImage;//�I������O�̃e�L�X�g�C���[�W
    [SerializeField] private Image[] oKImage;//OK��\������C���[�W
    [SerializeField] private Sprite[] oKSprite;//OK/NO �X�v���C�g

    private bool[] isDecision;//���肵�����ǂ���
    private bool[] pressStart;//�X�^�[�g�{�^������������

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

        //�S�ẴR���g���[���[�����肵�I�������
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (!isDecision[i]) return;
        }

        //�n�߂�{�^����������������
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (!Gamepad.all[i].startButton.wasPressedThisFrame) continue;
            pressStart[i] = true;
        }

        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (!pressStart[i]) return;
        }
        charactorRoot.OnDontDestroyScene();  //�L�����N�^�[��DontDestroy�ɏグ��
        SceneManager.LoadScene("MainScene");//�V�[���J��
    }

    private void SelectCharactor()
    {
        //ToDo�}�W�b�N�i���o�[�폜
     
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
        //�L�����Z��
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
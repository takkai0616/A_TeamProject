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
        PressedSelectButton();
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

    private void PressedSelectButton()
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

            //animation���Đ�
            if (isDecision[i] && (CommonData.useCharactorNum[i] == _num))//�R���g���[���[������ς݂��o�^���ꂽ�{�^���̔ԍ��Ɠ��͂��ꂽ�{�^������v���Ă�����
            {
                return;
            }

            if (!JudgeAvailability(_num, i)) return;//�R���g���[���[�ƃL�����N�^�[�������肩����

            preDecisionInfoImage[_num].enabled = false;//�{�^���������Ă���������\������Image������
            charactorRoot.ActivateSelectPlayer(_num);//�L�����N�^�[��MeshRenderer���A�N�e�B�u�ɂ���
            CommonData.useCharactorNum[i] = _num;//�R���g���[���[�̔ԍ��̔z��̈ʒu�Ƀ{�^���̔ԍ���o�^
            charactorRoot.SetIsDecidion(_num, true);//�L�����N�^�[���g�����߂��Ă���Ɛݒ�
            isDecision[i] = true;//�R���g���[���[�����߂��Ă���Ɛݒ�
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
    
    /// <summary>
    /// �L�����N�^�[�ƃR���g���[���[�����ݒ肩�m�F
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
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private CharactorRoot charactorRoot;

    private bool[] isDicision;//���肵�����ǂ���
    private bool pressStart;//�X�^�[�g�{�^������������

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
            if (!Gamepad.all[i].aButton.wasPressedThisFrame) continue;//A�{�^����������Ă��Ȃ�

            if (isDicision[i]) continue;//���łɌ��肳��Ă���

            CommonData.useCharactorNum[i] = charactorRoot.GetCharactorNum();
            isDicision[i] = true;
            break;
        }

        //�S�ẴR���g���[���[�����肵�I�������
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (!isDicision[i]) return;
        }

        //�n�߂�{�^����������������
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (!Gamepad.all[i].bButton.wasPressedThisFrame) continue;
            pressStart = true;
        }

        if (!pressStart) return;  //�X�^�[�g�t���O�������Ă��邩

        charactorRoot.InitializationChildTrans();//�L�����N�^�[��Transform��������
        charactorRoot.OnDontDestroyScene();  //�L�����N�^�[��DontDestroy�ɏグ��
        SceneManager.LoadScene("MainScene");//�V�[���J��
    }
}
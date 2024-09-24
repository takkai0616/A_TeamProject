using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    [SerializeField] CharactorRoot charactorRoot;
    //�L�����N�^�[�I�u�W�F�N�g
    [SerializeField] PlayerNumber[] charObj;

    bool[] isDicision;//���肵�����ǂ���
    bool pressStart;//�X�^�[�g�{�^������������

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
            if (!Gamepad.all[i].aButton.wasPressedThisFrame) continue;//A�{�^����������Ă��Ȃ�

            if (isDicision[i]) continue;//���łɌ��肳��Ă���

            charObj[i].Number = i;//�L�����N�^�ɃR���g���[���[�̔ԍ����L�^
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

        //�L�����N�^�[�̌X���ƈʒu�𒲐�
        Transform parentTrans = charactorRoot.transform;
        for(int i = 0; i < parentTrans.childCount; ++i)
        {
            Transform childTrans = parentTrans.GetChild(i);
            Transform grandChild = childTrans.GetChild(0);
            grandChild.localPosition = Vector3.zero;
            grandChild.localRotation = Quaternion.identity;
        }

        charactorRoot.OnDontDestroyScene();  //�L�����N�^�[��DontDestroy�ɏグ��
        SceneManager.LoadScene("MainScene");//�V�[���J��
    }
}
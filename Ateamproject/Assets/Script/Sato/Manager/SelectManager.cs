using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    //�L�����N�^�[�I�u�W�F�N�g
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
                Debug.Log(i + "��" + CommonData.useCharactorNum[i]);
            }
        }

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

        SceneManager.LoadScene("SatoScene");
    }
}
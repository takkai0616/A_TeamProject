using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

// �^�C�g����ʂ̐i�s�𐧌䂵�܂��B
public class TitleSceneMove : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    // ���̃V�[����ǂݍ��݉\�ȏꍇ��true�A����ȊO��false
    private bool isLoadable = false;

    private bool isSelect = true;

    private bool isPush = false;

    [SerializeField]
    private GameObject[] selectArrow;


    // �Q�b�ҋ@��Ɏ��̃V�[����Ǎ��݉\�ɂ��܂��B
    IEnumerator OnStart()
    {
        yield return new WaitForSeconds(2);
        isLoadable = true;
    }
    private void Start()
    {
       isPush = false;
    }

    private void Update()
    {
        var leftStickValue = Gamepad.all[0].leftStick.ReadValue();//�X�e�B�b�N��|�����x����

        if (isSelect)
        {   //�Q�[���J�n

            //�I���̕\���ς�����
            selectArrow[0].SetActive(true);
            selectArrow[1].SetActive(false);

            if (isLoadable)
            {
                SceneManager.LoadScene("SelectScene");
            }
                if (leftStickValue.y < 0&&!isPush)
                { isSelect = false; }

        }

        if (!isSelect)
        {   //�I��

            //�I���̕\���ς�����
            selectArrow[0].SetActive(false);
            selectArrow[1].SetActive(true);

            if (isLoadable)
            {
                Application.Quit();
            }
            else
            {
                if (leftStickValue.y > 0 && !isPush)
                { isSelect = true; }
            }
        }



        //����
        if (Gamepad.all[0].bButton.wasPressedThisFrame)
        {
            StartCoroutine(OnStart());
            animator.SetTrigger("Push");
            isPush = true;
        }
        
        
    }
}

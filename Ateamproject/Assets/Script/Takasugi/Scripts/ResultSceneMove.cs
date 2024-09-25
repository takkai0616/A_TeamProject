using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
// �^�C�g����ʂ̐i�s�𐧌䂵�܂��B
public class ResultSceneMove: MonoBehaviour
{

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject[] selectArrow;
    // ���̃V�[����ǂݍ��݉\�ȏꍇ��true�A����ȊO��false
    private  bool isLoadable = false;
    private bool isSelect = true;
    private bool isPush = false;

    private GameObject charObj;
    private CharactorRoot charactorRoot; 

    private void Start()
    {
        isPush = false;
        charObj = GameObject.Find("Charactors");
        charactorRoot = charObj.GetComponent<CharactorRoot>();
        charactorRoot.SetResultPosition();
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
                charactorRoot.OnActiceScene();
                SceneManager.LoadScene("MainScene");
            }
            
            if (leftStickValue.x > 0 && !isPush)
            {
                isSelect = false; 
            }
        }

        if (!isSelect)
        {   //�I��

            //�I���̕\���ς�����
            selectArrow[0].SetActive(false);
            selectArrow[1].SetActive(true);

            if (isLoadable)
            {
                SceneManager.LoadScene("TitleScene");
            }
            if (leftStickValue.x < 0 && !isPush)
            { 
                isSelect = true; 
            }
        }

        //����
        if (Gamepad.all[0].bButton.wasPressedThisFrame)
        {
            StartCoroutine(OnStart());
            animator.SetTrigger("PushResult");
            isPush = true;
        }
    }

    // �Q�b�ҋ@��Ɏ��̃V�[����Ǎ��݉\�ɂ��܂��B
    IEnumerator OnStart()
    {
        yield return new WaitForSeconds(2);
        isLoadable = true;
    }
}

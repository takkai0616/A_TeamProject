using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

// �^�C�g����ʂ̐i�s�𐧌䂵�܂��B
public class TitleSceneScript : MonoBehaviour
{
    // ���̃V�[����ǂݍ��݉\�ȏꍇ��true�A����ȊO��false
    private bool isLoadable = false;

    private bool isSelect = true;

    [SerializeField]
    private GameObject[] selectArrow;


    // �Q�b�ҋ@��Ɏ��̃V�[����Ǎ��݉\�ɂ��܂��B
    IEnumerator OnStart()
    {
        yield return new WaitForSeconds(2);
        isLoadable = true;
    }


    private void Update()
    {
        if (isSelect)
        {   //�Q�[���J�n

            //�I���̕\���ς�����
            selectArrow[0].SetActive(true);
            selectArrow[1].SetActive(false);

            if (isLoadable)
            {
                SceneManager.LoadScene("MainScene");
            }

            if (Input.GetKey(KeyCode.DownArrow))
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

            if (Input.GetKey(KeyCode.UpArrow))
            { isSelect = true; }
        }



        //����
        if (Input.GetKey(KeyCode.Return))
        {
            StartCoroutine(OnStart());
        }
        
        
    }
}

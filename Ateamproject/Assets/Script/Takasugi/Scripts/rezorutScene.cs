using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// �^�C�g����ʂ̐i�s�𐧌䂵�܂��B
public class rezorutScene: MonoBehaviour
{
    // ���̃V�[����ǂݍ��݉\�ȏꍇ��true�A����ȊO��false
    bool isLoadable = false;

    bool Serect = true;

    [SerializeField]
    GameObject serect;

    [SerializeField]
    GameObject serect2;

    // Start is called before the first frame update
    void Start()
    {

      
    }

    // �Q�b�ҋ@��Ɏ��̃V�[����Ǎ��݉\�ɂ��܂��B
    IEnumerator OnStart()
    {
        yield return new WaitForSeconds(2);
        isLoadable = true;
    }

    // ����{�^������̍ۂɌĂяo����A���̃V�[����ǂݍ��݂܂��B
    public void LoadNextScene()
    {
        
    }

    private void Update()
    {
        if (Serect == true)
        {   //�Q�[���J�n

            //�I���̕\���ς�����
            serect.SetActive(true);
            serect2.SetActive(false);

            if (isLoadable)
            {
                SceneManager.LoadScene("MainScene");
            }

            if (Input.GetKey(KeyCode.RightArrow))
            { Serect = false; }
        }

        if (Serect == false)
        {   //�I��

            //�I���̕\���ς�����
            serect.SetActive(false);
            serect2.SetActive(true);

            if (isLoadable)
            {
                SceneManager.LoadScene("Title Scene");
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            { Serect = true; }
        }


        //����
        if (Input.GetKey(KeyCode.Return))
        {
            StartCoroutine(OnStart());
        }


    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// �^�C�g����ʂ̐i�s�𐧌䂵�܂��B
public class MainScene : MonoBehaviour
{
    // ���̃V�[����ǂݍ��݉\�ȏꍇ��true�A����ȊO��false
    bool isLoadable = false;

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
        if (Input.GetKey(KeyCode.Return))
        {
            StartCoroutine(OnStart());
        }

        if (isLoadable)
        {
            SceneManager.LoadScene("rezorutScene");
        }
    }
}

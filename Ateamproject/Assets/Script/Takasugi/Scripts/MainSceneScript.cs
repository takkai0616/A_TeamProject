using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


// �^�C�g����ʂ̐i�s�𐧌䂵�܂��B
public class MainSceneScript: MonoBehaviour
{
    // ���̃V�[����ǂݍ��݉\�ȏꍇ��true�A����ȊO��false
    bool isLoadable = false;

   [SerializeField]
    float time = 0;

    int timeup = 0;
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

        if(time >= 30)
        {
            timeup = 1;
        }

        if (isLoadable|| timeup == 1)
        {
            SceneManager.LoadScene("rezorutScene");
        }

        

        time += 1 * Time.deltaTime;
    }
}

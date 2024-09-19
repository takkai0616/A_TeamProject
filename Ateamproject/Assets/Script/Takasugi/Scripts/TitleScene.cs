using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


// タイトル画面の進行を制御します。
public class TitleScene : MonoBehaviour
{
    // 次のシーンを読み込み可能な場合はtrue、それ以外はfalse
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

    // ２秒待機後に次のシーンを読込み可能にします。
    IEnumerator OnStart()
    {
        yield return new WaitForSeconds(2);
        isLoadable = true;
    }

    // 決定ボタン操作の際に呼び出され、次のシーンを読み込みます。
    public void LoadNextScene()
    {
        
    }

    private void Update()
    {
        




        if (Serect == true)
        {   //ゲーム開始

            //選択の表示変えたい
            serect.SetActive(true);
            serect2.SetActive(false);

            if (isLoadable)
            {
                SceneManager.LoadScene("MainScene");
            }

            if (Input.GetKey(KeyCode.DownArrow)) 
            { Serect = false; }
        }

        if (Serect == false)
        {   //終了

            //選択の表示変えたい
            serect.SetActive(false);
            serect2.SetActive(true);

            if (isLoadable)
            {
                Application.Quit();
            }

            if (Input.GetKey(KeyCode.UpArrow))
            { Serect = true; }
        }



        //決定
        if (Input.GetKey(KeyCode.Return))
        {
            StartCoroutine(OnStart());
        }

        
    }
}

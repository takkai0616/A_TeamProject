using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMMainSelect : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void OnActiveScene()
    {
        SceneManager.MoveGameObjectToScene(gameObject,SceneManager.GetActiveScene());
    }
}

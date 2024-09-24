using UnityEngine;

public class Hoge : MonoBehaviour
{
    public void OnDontDestroyScene()
    {
        DontDestroyOnLoad(gameObject);
    }
}

using UnityEngine;

public class CharactorRoot : MonoBehaviour
{
    public void OnDontDestroyScene()
    {
        DontDestroyOnLoad(gameObject);
    }
}

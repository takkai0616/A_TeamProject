using UnityEngine;

public class MainManager : MonoBehaviour
{  
    void Start()
    {
        for(int i = 0; i < CommonData.charactorObj.Length; ++i)
        {
            Instantiate(CommonData.charactorObj[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

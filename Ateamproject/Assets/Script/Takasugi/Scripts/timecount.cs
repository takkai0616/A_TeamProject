using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timecount : MonoBehaviour
{
    [SerializeField]
 TextMeshProUGUI textMeshProUGUI;

    //�\���������^�C��
    [SerializeField]
    float time = 31;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     

        time -= 1 * Time.deltaTime;

        int timeb = (int)time;

        string character = timeb.ToString();

        textMeshProUGUI.text = character;
    }
}

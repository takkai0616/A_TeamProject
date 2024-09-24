using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeCount : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;

    //•\Ž¦‚µ‚½‚¢ƒ^ƒCƒ€
    [SerializeField]
   private float time = 31;

    // Update is called once per frame
    private void Update()
    {
        time -= 1 * Time.deltaTime;

        textMeshProUGUI.text = ((int)time).ToString();
    }

    public float InGameTime()
    {  
        return time; 
    }
}

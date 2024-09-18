using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        Vector3 vec = new Vector3();

        if (Input.GetKeyDown(KeyCode.W))
        {
            vec.z += 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.A)) 
        {
            vec.x -= 1.0f;
        }
        
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            vec.z -= 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            vec.x += 1.0f;
        }

        transform.position += vec;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GearsCounter : MonoBehaviour
{
    static public int fixedGears = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fixedGears == 3)
        {
            SceneManager.LoadSceneAsync("Store");
        }
    }
}

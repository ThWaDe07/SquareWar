using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("end", 2.0f);
    }

    void end()
    {
        SceneManager.LoadScene("game");
    }
}

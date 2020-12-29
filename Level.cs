using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    //parameters
    [SerializeField] int breakableBlocks; //Serialized for debugging

    // cached reference
    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
            breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0 && SceneManager.GetActiveScene().buildIndex != 8)
        {
            sceneloader.LoadNextScene();
        }
        else if (breakableBlocks <= 0 && SceneManager.GetActiveScene().buildIndex >= 8)
        {
            SceneManager.LoadScene("Win Screen");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonScripts : MonoBehaviour
{
    [SerializeField] int numberLvl;

    public void LoadLvl()
    {
        SceneManager.LoadScene(numberLvl);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}

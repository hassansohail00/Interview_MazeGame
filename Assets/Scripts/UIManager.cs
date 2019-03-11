using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject StartScreen;
    public KnightController knightScript;
    public CharacterController CharScript;
    public Timer timeScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void RestartGame() {
        SceneManager.LoadScene("Gameplay");
    }

    public void PlatBtn()
    {
        StartScreen.SetActive(false);
        knightScript.enabled = true;
        CharScript.enabled = true;
        timeScript.enabled = true;
      //  SceneManager.LoadScene("Gameplay");
    }
}

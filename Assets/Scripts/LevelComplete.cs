using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject LevelCompletePanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kinght"))
        {
            GameObject.Find("LevelComplete").GetComponent<AudioSource>().Play();

            LevelCompletePanel.SetActive(true);
            this.gameObject.GetComponent<Timer>().Finish();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] int LevelToLoad;

    private bool isLoading = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Body")){
            loadNewLevel();
        }
    }

    public void loadNewLevel(){
        if(isLoading) return;
        
        isLoading = true;

        SceneManager.LoadScene(LevelToLoad);
    }
}

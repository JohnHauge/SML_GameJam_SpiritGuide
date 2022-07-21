using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StartMenu_Button : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite idle;
    [SerializeField] private Sprite OnMouseOver;
    [SerializeField] private Sprite onPressed;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private bool loadingNewScene = false;

    public UnityEvent ButtonClicked = new UnityEvent();

    private void OnMouseEnter() {
        if (loadingNewScene) return;
        spriteRenderer.sprite = OnMouseOver;
        
    }

    private void OnMouseExit() {
        if (loadingNewScene) return;
        spriteRenderer.sprite = idle;
    }

    private void OnMouseDown() {
        loadingNewScene = true;
        spriteRenderer.sprite = onPressed;
        ButtonClicked.Invoke();
        Invoke("LoadNewScene", 2f);
    }

    private void LoadNewScene()
    {
        SceneManager.LoadScene(1);
    }
}

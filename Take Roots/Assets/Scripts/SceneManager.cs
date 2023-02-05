using System;
using System.Collections;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : Singleton<SceneManager>
{
    [SerializeField] private int day;
    [SerializeField] private string nextScene;
    [SerializeField, Min(0)] private float changeSceneDelay;

    public event Action<bool> OnStartDay;

    protected override void Awake()
    {
        GameManager.Instance.Day = day;
        base.Awake();
    }

    private void Start()
    {
        OnStartDay?.Invoke(true);
    }

    public void ReturnMenu()
    {
        LoadScene("Menu");
    }

    public void ChangeScene()
    {
        StartCoroutine(ChangeSceneDelay());
    }

    private IEnumerator ChangeSceneDelay()
    {
        yield return new WaitForSeconds(changeSceneDelay);
        LoadScene(nextScene);
    }

    private void LoadScene(string scene)
    {
        UnitySceneManager.LoadScene(scene);
    }
}

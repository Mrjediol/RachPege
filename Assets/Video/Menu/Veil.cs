using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Veil : MonoBehaviour
{

    private static Veil _instance;
    public static Veil instance
    {
        get
        {
            if (_instance != null)
                return _instance;
            _instance = FindObjectOfType<Veil>();
            if (_instance == null)
            {
                GameObject prefab = Resources.Load("Veil") as GameObject;
                GameObject go = GameObject.Instantiate(prefab);
                _instance = go.GetComponent<Veil>();
            }
            return _instance;
        }
    }

    public CanvasGroup canvasGroup;
    public float animationTime = 0.5f;
    public bool fadeOutOnAwake;

        //private void Start()
        //{
        //    SceneManager.sceneLoaded += OnSceneLoaded;
        //}
    
    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        if (fadeOutOnAwake)
        {
            StartCoroutine(Fade(0));
        }
    }
    
    //private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    if (scene.name == "Menu")
    //    {
    //        StartCoroutine(Fade(0));
    //        Time.timeScale = 1f;
    //    }
    //}
    IEnumerator Fade(float to)
    {
      
        canvasGroup.blocksRaycasts =  to == 1;
        float elapsedTime = 0;
        float from = canvasGroup.alpha;
        while (elapsedTime < animationTime)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsedTime / animationTime);
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
        }
        canvasGroup.alpha = to;
    }

    public void LoadScene(string nextScene)
    {
        StartCoroutine(DoLoadScene(nextScene));
    }

    IEnumerator DoLoadScene(string nextScene)
    {
        yield return StartCoroutine(Fade(1));
        //SceneManager.LoadScene(nextScene);
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {



            yield return 0;
        }
            op.allowSceneActivation = true;
            yield return StartCoroutine(Fade(0));
        
    }

}

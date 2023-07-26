using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject loadPanel;
    [SerializeField] TextMeshProUGUI percentText;
    [SerializeField] Slider sliderBar;
    [SerializeField] List<GameObject> objectsToHide;

    public void Load(int index)
    {
        loadPanel.SetActive(true);
        StartCoroutine(LoadAsyncScene(index));
        if (objectsToHide.Count > 0)
        {
            foreach (GameObject obj in objectsToHide)
            {
                obj.SetActive(false);
            }
        }
    }

    private IEnumerator LoadAsyncScene(int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            sliderBar.value = progress;
            percentText.text = $"{progress * 100f}%";
            yield return null;
        }
    }
}

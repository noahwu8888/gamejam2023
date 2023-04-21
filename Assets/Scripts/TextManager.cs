using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

/// <summary>
/// Manages text.
/// </summary>
public class TextManager : MonoBehaviour
{
    // Singleton pattern
    private static TextManager s_singleton;
    /// <summary>
    /// The singleton refernce for <cref>TextManager</cref>.
    /// </summary>
    public static TextManager Singleton
    {
        get => s_singleton;
        private set
        {
            if (s_singleton is null)
                s_singleton = value;
            else if (s_singleton != value)
                Destroy(value);
        }
    }

    [SerializeField]
    private GameObject _canvas;

    [SerializeField]
    private float _timeTillFullyVisible;
    [SerializeField]
    private float _delay;
    [SerializeField]
    private float _longDelay;
    [SerializeField]
    private float _longLongDelay;
    [SerializeField]
    private int _hasCutscenePlayed = 0;

    private void Awake()
    {
        Singleton = this;
        DontDestroyOnLoad(this);
        if (_hasCutscenePlayed == 0)
            StartCoroutine(RunStartSequence());
        else
        {
            Transform poemText = _canvas.transform.GetChild(1);
            for (int i = 0; i < poemText.childCount; i++)
            {
                TextMeshProUGUI text = poemText.GetChild(i).GetComponent<TextMeshProUGUI>();
                for (float j = 0; j < _timeTillFullyVisible; j += Time.deltaTime)
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
                Transform panel = _canvas.transform.GetChild(0);
                Image image = panel.GetComponent<Image>();
                image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
            }
        }
    }

    // Displays the poem and then provides instrutions to the player.
    private IEnumerator RunStartSequence()
    {
        for (float i = 0; i < _delay; i += Time.deltaTime)
            yield return new WaitForEndOfFrame();

        // Displays the poem
        Transform poemText = _canvas.transform.GetChild(1);
        for (int i = 0; i < poemText.childCount; i++)
        {
            TextMeshProUGUI text = poemText.GetChild(i).GetComponent<TextMeshProUGUI>();
            for (float j = 0; j < _timeTillFullyVisible; j+= Time.deltaTime)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, j / _timeTillFullyVisible);
                yield return new WaitForEndOfFrame();
            }
            for (float j = 0; j < _delay; j += Time.deltaTime)
                yield return new WaitForEndOfFrame();
        }

        for (float i = 0; i < _longDelay; i += Time.deltaTime)
            yield return new WaitForEndOfFrame();
        for (float i = 0; i < _timeTillFullyVisible; i += Time.deltaTime)
        {
            for (int j = 0; j < poemText.childCount; j++)
            {
                TextMeshProUGUI text = poemText.GetChild(j).GetComponent<TextMeshProUGUI>();
                text.color = new Color(text.color.r, text.color.g, text.color.b, 1 - i / _timeTillFullyVisible);
            }
            yield return new WaitForEndOfFrame();
        }

        // Provides instructions.
        Transform panel = _canvas.transform.GetChild(0);
        Image image = panel.GetComponent<Image>();
        Transform instructions = _canvas.transform.GetChild(2);
        TextMeshProUGUI instructionsText = instructions.GetComponent<TextMeshProUGUI>();
        for (float i = 0; i < _timeTillFullyVisible; i += Time.deltaTime)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1 - i / 4 / _timeTillFullyVisible);
            yield return new WaitForEndOfFrame();
        }
        for (float i = 0; i < _timeTillFullyVisible; i += Time.deltaTime)
        {
            instructionsText.color = new Color(instructionsText.color.r, instructionsText.color.g, instructionsText.color.b, i / _timeTillFullyVisible);
            yield return new WaitForEndOfFrame();
        }

        for (float i = 0; i < _longLongDelay; i += Time.deltaTime)
            yield return new WaitForEndOfFrame();

        for (float i = 0; i < _timeTillFullyVisible; i += Time.deltaTime)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1 - (3f * i + _timeTillFullyVisible) / 4 / _timeTillFullyVisible);
            instructionsText.color = new Color(instructionsText.color.r, instructionsText.color.g, instructionsText.color.b, 1 - i / _timeTillFullyVisible);
            yield return new WaitForEndOfFrame();
        }
        _hasCutscenePlayed = 1;
    }

    /*public IEnumerator DisableGun()
    {
        Transform panel = _canvas.transform.GetChild(0);
        Image image = panel.GetComponent<Image>();
        Transform disabledText = _canvas.transform.GetChild(3);
        TextMeshProUGUI text = disabledText.GetComponent<TextMeshProUGUI>();

        for (float i = 0; i < _timeTillFullyVisible; i += Time.deltaTime)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 3f * i / 4f / _timeTillFullyVisible);
            print(3f * i / 4f / _timeTillFullyVisible + "rar");
            text.color = new Color(text.color.r, text.color.g, text.color.b, i / _timeTillFullyVisible);
            yield return new WaitForEndOfFrame();
        }

        for (float i = 0; i < _longDelay; i += Time.deltaTime)
            yield return new WaitForEndOfFrame();

        for (float i = 0; i < _timeTillFullyVisible; i += Time.deltaTime)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1 - (3 * i + _timeTillFullyVisible) / 4 / _timeTillFullyVisible);
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1 - i / _timeTillFullyVisible);
            yield return new WaitForEndOfFrame();
        }
    }*/
}
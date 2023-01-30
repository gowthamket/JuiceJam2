using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window_CharacterPortrait : MonoBehaviour
{
    private static Dictionary<Player, Window_CharacterPortrait> windowDictionary;

    private Transform cameraTransform;
    private Transform followTransform;

    private Player character;

    private void Awake()
    {
        cameraTransform = transform.Find("camera");

        transform.Find("closeBtn").GetComponent<Button>().onClick.AddListener(DestroyWindow);
    }

    private void Update()
    {
        cameraTransform.position = new Vector3(followTransform.position.x, followTransform.position.y, Camera.main.transform.position.z);
    }

    private void Show(Player player)
    {
        this.character = player;
        followTransform = character.transform;

        RenderTexture renderTexture = new RenderTexture(512, 512, 16);
        transform.Find("camera").GetComponent<Camera>().targetTexture = renderTexture;
        transform.Find("rawImage").GetComponent<RawImage>().texture = renderTexture;    
    }

    private void DestroyWindow()
    {
        windowDictionary.Remove(character);
    }

    public static void Show_Static(Player character)
    {
        if (windowDictionary == null)
        {
            windowDictionary = new Dictionary<Player, Window_CharacterPortrait>();
        }

        if (!windowDictionary.ContainsKey(character))
        {
            Transform windowCharacterPortraitTransform = Instantiate(GameHandler.instance.pfWindow_CharacterPortrait);
            windowCharacterPortraitTransform.SetParent(GameHandler.instance.canvas.transform, false);
            windowCharacterPortraitTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(UnityEngine.Random.Range(-500, 500), UnityEngine.Random.Range(-500, 500));

            Window_CharacterPortrait windowCharacterPortrait = windowCharacterPortraitTransform.GetComponent<Window_CharacterPortrait>();
            windowCharacterPortrait.Show(character);

            windowDictionary[character] = windowCharacterPortrait;
        }
    }
}

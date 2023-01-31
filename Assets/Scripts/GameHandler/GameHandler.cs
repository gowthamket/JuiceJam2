using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using CodeMonkey.MonoBehaviours;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;
    public Canvas canvas;
    public Transform pfWindow_CharacterPortrait;

    [SerializeField] private CameraFollow cameraFollow;
    private Vector3 cameraFollowPosition = new Vector3(-134, 150);

    [SerializeField] private Transform characterTransform;
    [SerializeField] private Transform secondCharacterTransform;

    private Player rifleCharacter;
    private Player swordCharacter;

    private void Awake()
    {
        instance = this;
        cameraFollow.Setup(() => cameraFollowPosition, () => 80f, true, true);
        SetupCharacters();
    }

    private void Start()
    {
        characterTransform.GetComponent<Button_Sprite>().ClickFunc = () => { Window_CharacterPortrait.Show_Static(rifleCharacter); };

        secondCharacterTransform.GetComponent<Button_Sprite>().ClickFunc = () => { Window_CharacterPortrait.Show_Static(swordCharacter); };
    }

    private void Update()
    {
        HandleCameraMovement();
    }

    private void SetupCharacters()
    {

    }

    private void HandleCameraMovement()
    {

    }
}

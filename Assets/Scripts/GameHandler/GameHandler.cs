using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;
    public Canvas canvas;
    public Transform pfWindow_CharacterPortrait;

    //[SerializeField] private CameraFollow cameraFollow;
    private Vector3 cameraFollowPosition = new Vector3(-134, 150);

    [SerializeField] private Transform characterTransform;
    [SerializeField] private Transform secondCharacterTransform;

    private Player rifleCharacter;
    private Player swordCharacter;

    private void Awake()
    {
        instance = this;
        //cameraFollow.Setup(() => cameraFollowPosition, () => 80f);
        SetupCharacters();
    }

    private void Start()
    {
        //characterTransform.GetComponent<Button>().onClick.AddListener(Window_CharacterPortrait.Show_Static(characterTransform));

        //secondCharacterTransform.GetComponent<Button>().onClick.AddListener(Window_CharacterPortrait.Show_Static(secondCharacterTransform));
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public GameObject baseObject;

    private void Start()
    {
        Instantiate(baseObject);
    }
}

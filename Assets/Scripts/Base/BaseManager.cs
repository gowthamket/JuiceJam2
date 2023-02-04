using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public GameObject baseObject;

    private void Start()
    {
        Instantiate(baseObject, new Vector2(baseObject.transform.position.x, baseObject.transform.position.y), Quaternion.identity);
    }
}

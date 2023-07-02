using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    void Awake()
    {
        transform.SetParent(GameObject.Find("Human").transform);
    }


}

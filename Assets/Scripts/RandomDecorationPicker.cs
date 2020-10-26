using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDecorationPicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>(true);

        int randPick = Random.Range(0, children.Length + 1);

        if (randPick == children.Length)
        {
            return;
        }

        children[randPick].gameObject.SetActive(true);
    }
}

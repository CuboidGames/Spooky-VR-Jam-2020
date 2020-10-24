using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KidsInstantiator : MonoBehaviour
{
    [SerializeField]
    public int groupSize = 3;

    [SerializeField]
    public GameObject kidPrefab;

    public UnityEvent OnKidsInstantiated;

    public void InstantiateKids()
    {
        float distance = groupSize / 2;

        for (int i = 0; i < groupSize; i++)
        {
            // Get offset position in circle
            float angleOffset = GetAngleOffset(i, groupSize);
            Vector3 position = new Vector3(Mathf.Sin(angleOffset), 0, Mathf.Cos(angleOffset)) * distance;

            Instantiate(kidPrefab, transform.position + position, Quaternion.identity, transform);
        }

        OnKidsInstantiated.Invoke();
    }

    private float GetAngleOffset(float index, float max)
    {
        return (index / max) * Mathf.PI * 2;
    }
}

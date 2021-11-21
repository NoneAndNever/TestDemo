using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour
{
    public static ShadowPool instance;
    public GameObject shadowPrefab;
    private int shadowCount =10;
    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    private void Awake()
    {
        instance = this;


        //��ʼ�������
        FillPool();
    }

    void FillPool()
    {
        for (int i = 0; i < shadowCount; i++)
        {
            var newShadow = Instantiate(shadowPrefab);
            newShadow.transform.SetParent(transform);
            ReturnPool(newShadow);
        }
    }

    public void ReturnPool(GameObject gameobject)
    {
        gameObject.SetActive(false);
        availableObjects.Enqueue(gameObject);
    }

    public GameObject GetFromPool()
    {
        if(availableObjects.Count == 0)
        {
            FillPool();
        }
        
        var outShadow = availableObjects.Dequeue();
        
        outShadow.SetActive(true);
        
        return outShadow;
    }
}

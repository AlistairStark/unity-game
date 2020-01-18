using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public delegate void OnWordScanned();
    public OnWordScanned onWordScannedCallback;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance found!");
        }
        instance = this;
    }

    public List<Item> words = new List<Item>();

    public void Scan(Item item)
    {
        words.Add(item);
        onWordScannedCallback.Invoke();
    }
}

// random comment

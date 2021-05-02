using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnObject : MonoBehaviour
{
    public void DespawnObj()
    {
        ObjectPool.Despawn(gameObject);
    }
}

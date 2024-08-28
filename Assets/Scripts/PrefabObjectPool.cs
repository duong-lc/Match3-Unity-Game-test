using System.Collections.Generic;
using UnityEngine;
using Unity;
using System.Collections;

public class PrefabObjectPool : MonoBehaviour
{
    private Dictionary<string, Queue<GameObject>> m_poolDictionary;
    public List<string> prefabNameList;
    public int poolSize = 10;

    private void InitPrefabList(){
        prefabNameList = new List<string>();

        prefabNameList.Add(Constants.PREFAB_CELL_BACKGROUND);

        prefabNameList.Add(Constants.PREFAB_NORMAL_TYPE_ONE);
        prefabNameList.Add(Constants.PREFAB_NORMAL_TYPE_TWO);
        prefabNameList.Add(Constants.PREFAB_NORMAL_TYPE_THREE);
        prefabNameList.Add(Constants.PREFAB_NORMAL_TYPE_FOUR);
        prefabNameList.Add(Constants.PREFAB_NORMAL_TYPE_FIVE);
        prefabNameList.Add(Constants.PREFAB_NORMAL_TYPE_SIX);
        prefabNameList.Add(Constants.PREFAB_NORMAL_TYPE_SEVEN);

        prefabNameList.Add(Constants.PREFAB_BONUS_HORIZONTAL);
        prefabNameList.Add(Constants.PREFAB_BONUS_VERTICAL);
        prefabNameList.Add(Constants.PREFAB_BONUS_BOMB);
    }
    private void Awake()
    {
        m_poolDictionary = new Dictionary<string, Queue<GameObject>>();
        InitPrefabList();

        foreach (string name in prefabNameList){
            Queue<GameObject> objectPool = new Queue<GameObject>();
            var obj1 = Resources.Load<GameObject>(name);
            if (obj1 == null)
            {
                Debug.LogWarning($"Prefab not found at path: {name}");
                continue;
            }
            for (int i = 0; i < poolSize; i++){
                GameObject obj = Instantiate(obj1, transform);
                obj.transform.localScale = Vector3.one;
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            m_poolDictionary.Add(name, objectPool);
        }
    }

    public GameObject GetObject(string name)
    {
        if (m_poolDictionary.ContainsKey(name))
        {
            Queue<GameObject> objectPool = m_poolDictionary[name];
            GameObject prefab = Resources.Load<GameObject>(name);
            if (objectPool.Count > 0) {
                GameObject obj = objectPool.Dequeue();
                obj.SetActive(true);
                return obj;
            }
            else {
                GameObject obj = Instantiate(prefab, transform);
                obj.transform.localScale = Vector3.one;
                obj.SetActive(true);
                return obj;
            }
        }

        Debug.LogWarning("Prefab not found in pool!");
        return null;
    }

    public void ReturnObject(string name, GameObject obj)
    {
        if (m_poolDictionary.ContainsKey(name))
        {
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            m_poolDictionary[name].Enqueue(obj);
        }
        else
        {
            Debug.LogWarning("name not found in pool!");
            Destroy(obj);
        }
    }
}

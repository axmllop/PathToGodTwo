using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    public int initSpawnCount = 5;
    private List<GameObject> normalPlatFormList = new List<GameObject>();
    private List<GameObject> commonPlatFormList = new List<GameObject>();
    private List<GameObject> grassPlatFormList = new List<GameObject>();
    private List<GameObject> winterPlatFormList = new List<GameObject>();
    private List<GameObject> spikePlatFormLeftList = new List<GameObject>();
    private List<GameObject> spikePlatFormRightList = new List<GameObject>();
    private List<GameObject> deathEffectList = new List<GameObject>(); 
         
    ManagerVars vars;

    public static ObjectPool Instance;
    private void Awake()
    {
        Instance = this;
        vars = ManagerVars.GetManagerVars();
        Init();
    }
    private void Init()
    {
        for (int i = 0; i < initSpawnCount; i++)
        {
            InstantiateObject(vars.NormalPlatFormPre, ref normalPlatFormList);
        }
        for (int i = 0; i < initSpawnCount; i++)
        {
            for (int j = 0; j < vars.commonPlatFormGroup.Count; j++)
            {
                InstantiateObject(vars.commonPlatFormGroup[j], ref commonPlatFormList);
            }
        }
        for (int i = 0; i < initSpawnCount; i++)
        {
            for (int j = 0; j < vars.grassPlatFormGroup.Count; j++)
            {
                InstantiateObject(vars.grassPlatFormGroup[j], ref grassPlatFormList);
            }
        }
        for (int i = 0; i < initSpawnCount; i++)
        {
            for (int j = 0; j < vars.winterPlatFormGroup.Count; j++)
            {
                InstantiateObject(vars.winterPlatFormGroup[j], ref winterPlatFormList);
            }
        }
        for (int i = 0; i < initSpawnCount; i++)
        {
            InstantiateObject(vars.spikePlatFormLeft, ref spikePlatFormLeftList);
        }
        for (int i = 0; i < initSpawnCount; i++)
        {
            InstantiateObject(vars.spikePlatFormRight, ref spikePlatFormRightList);
        }
        for (int i = 0; i < 1; i++)
        {
            InstantiateObject(vars.deathEffect, ref deathEffectList);
        }
    }
    private GameObject InstantiateObject(GameObject prefab, ref List<GameObject> addList)
    {
        GameObject go = Instantiate(prefab, transform);
        go.SetActive(false);
        addList.Add(go);
        return go;
    }
    /// <summary>
    /// 获取死亡特效
    /// </summary>
    /// <returns></returns>
    public GameObject GetDeathEffect()
    {
        for (int i = 0; i < deathEffectList.Count; i++)
        {
            if (deathEffectList[i].activeInHierarchy == false)
            {
                return deathEffectList[i];
            }
        }
        return InstantiateObject(vars.deathEffect, ref deathEffectList);
    }
    /// <summary>
    /// 获取单个平台
    /// </summary>
    /// <returns></returns>
    public GameObject GetNomalPlatForm()
    {
        for (int i = 0; i < normalPlatFormList.Count; i++)
        {
            if (normalPlatFormList[i].activeInHierarchy == false)
            {
                return normalPlatFormList[i];
            }
        }
       return InstantiateObject(vars.NormalPlatFormPre, ref normalPlatFormList);

    }
    /// <summary>
    /// 获取通用组合平台
    /// </summary>
    /// <returns></returns>
    public GameObject GetCommonPlatForm()
    {
        for (int i = 0; i < commonPlatFormList.Count; i++)
        {
            if (commonPlatFormList[i].activeInHierarchy == false)
            {
                return commonPlatFormList[i];
            }
        }
        int ran = Random.Range(0, vars.commonPlatFormGroup.Count);
        return InstantiateObject(vars.commonPlatFormGroup[ran], ref commonPlatFormList);

    }
    /// <summary>
    /// 获取草地组合平台
    /// </summary>
    /// <returns></returns>
    public GameObject GetGrassPlatForm()
    {
        for (int i = 0; i < grassPlatFormList.Count; i++)
        {
            if (grassPlatFormList[i].activeInHierarchy == false)
            {
                return grassPlatFormList[i];
            }
        }
        int ran = Random.Range(0, vars.commonPlatFormGroup.Count);
        return InstantiateObject(vars.grassPlatFormGroup[ran], ref grassPlatFormList);

    }
    /// <summary>
    /// 获取冬季组合平台
    /// </summary>
    /// <returns></returns>
    public GameObject GetWinterPlatForm()
    {
        for (int i = 0; i < winterPlatFormList.Count; i++)
        {
            if (winterPlatFormList[i].activeInHierarchy == false)
            {
                return winterPlatFormList[i];
            }
        }
        int ran = Random.Range(0, vars.winterPlatFormGroup.Count);
        return InstantiateObject(vars.winterPlatFormGroup[ran], ref winterPlatFormList);
    }
    /// <summary>
    /// 获取钉子左边的组合平台
    /// </summary>
    /// <returns></returns>
    public GameObject GetLeftSpikePlatForm()
    {
        for (int i = 0; i < spikePlatFormLeftList.Count; i++)
        {
            if (spikePlatFormLeftList[i].activeInHierarchy == false)
            {
                return spikePlatFormLeftList[i];
            }
        }
      
        return InstantiateObject(vars.spikePlatFormLeft, ref spikePlatFormLeftList);
    }
    /// <summary>
    /// 获取钉子右边的组合平台
    /// </summary>
    /// <returns></returns>
    public GameObject GetRightSpikePlatForm()
    {
        for (int i = 0; i < spikePlatFormRightList.Count; i++)
        {
            if (spikePlatFormRightList[i].activeInHierarchy == false)
            {
                return spikePlatFormRightList[i];
            }
        }

        return InstantiateObject(vars.spikePlatFormRight, ref spikePlatFormRightList);
    }
}

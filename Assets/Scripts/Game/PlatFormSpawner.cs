using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlatFormGroupType
{
    Grass,
    Winter,
}
public class PlatFormSpawner : MonoBehaviour {

    public Vector3 startSpawnPos;
    private Vector3 platFormSpawnPostion;
    private int spawnPlatFormCount = 5;
    
    bool isLeftSpawn;
    ManagerVars vars;

    PlatFormGroupType groupType;
    /// <summary>
    /// 选择的平台图
    /// </summary>
    private Sprite selectPlatFormSprite;

    private void Awake()
    {
        EventCenter.AddListener(EventDefine.DecidePath, DecidePath);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventDefine.DecidePath, DecidePath);
    }
    private void Start()
    {
        platFormSpawnPostion = startSpawnPos;
        vars = ManagerVars.GetManagerVars();
        RandomPlatFormTheme();
        for (int i = 0; i < 5; i++)
        {
            spawnPlatFormCount = 5;
            DecidePath();
        }
        GameObject go = Instantiate(vars.characterPre);
        go.transform.position = new Vector3(0.06f, -35f, 0);
    }
    /// <summary>
    /// 随机生成平台主题
    /// </summary>
    private void RandomPlatFormTheme()
    {
        int ran = Random.Range(0,vars.platFormThemeSpriteList.Count);
        
        selectPlatFormSprite = vars.platFormThemeSpriteList[ran];
        if (ran == 2)
        {
            groupType = PlatFormGroupType.Winter;
        }
        else
        {
            groupType = PlatFormGroupType.Grass;

        }
    }

    /// <summary>
    /// 确定路径
    /// </summary>
    private void DecidePath()
    {
        
        if (spawnPlatFormCount > 0)
        {
            spawnPlatFormCount--;
            SpawnPlatForm();
        }
        else
        {
            
            isLeftSpawn = !isLeftSpawn;
            spawnPlatFormCount = Random.Range(1, 4);
            SpawnPlatForm();
        }
    }
    /// <summary>
    /// 生成平台
    /// </summary>
    private void SpawnPlatForm()
    {
        int ranObstacleDir = Random.Range(0, 2);
        //生成单个平台
        if (spawnPlatFormCount >= 1)
        {
            SpawnNormalPlatForm(ranObstacleDir);
        }
        else if (spawnPlatFormCount == 0)
        {
            //生成组合平台
            int ran = Random.Range(0, 3);
            //生成通用平台
            if (ran == 0)
            {
                SpawnCommonPlatFormGroup(ranObstacleDir);
            }
            //生成主题
            else if (ran == 1)
            {
                switch (groupType)
                {
                    case PlatFormGroupType.Grass:

                        SpawnGrassPlatFormGroup(ranObstacleDir);
                        break;
                    case PlatFormGroupType.Winter:
                        SpawnWinterPlatFormGroup(ranObstacleDir);
                        break;
                    default:
                        break;
                }
            }
            else 
            {
                int value = -1;
                if (isLeftSpawn)
                {
                    value = 0;//生成右边方向的钉子



                }
                else
                {
                    value = 1;//sc左边方向的钉子
                }
                SpawnSpikePlatForm(value,ranObstacleDir);
            }

        }
        
        if (isLeftSpawn)
        {
            platFormSpawnPostion = new Vector3(platFormSpawnPostion.x - vars.nextXPos, platFormSpawnPostion.y + vars.nextYPos, 0);

        }
        else
        {
            platFormSpawnPostion = new Vector3(platFormSpawnPostion.x + vars.nextXPos, platFormSpawnPostion.y + vars.nextYPos, 0);
        }
    }
   
    /// <summary>
    /// 生成单个平台
    /// </summary>
    private void SpawnNormalPlatForm(int ranObjstacleDir)
    {
        GameObject go = Instantiate(vars.NormalPlatFormPre, transform);
        go.transform.position = platFormSpawnPostion;
        go.GetComponent<PlatFormScript>().Init(selectPlatFormSprite,ranObjstacleDir);
    }
    /// <summary>
    /// 生成通用平台
    /// </summary>
    private void SpawnCommonPlatFormGroup(int ranObjstacleDir)
    {
        int ran = Random.Range(0, vars.commonPlatFormGroup.Count);
        GameObject go = Instantiate(vars.commonPlatFormGroup[ran], transform);
        go.transform.position = platFormSpawnPostion;
        go.GetComponent<PlatFormScript>().Init(selectPlatFormSprite,ranObjstacleDir);
    }
    /// <summary>
    /// 生成草地平台
    /// </summary>
    private void SpawnGrassPlatFormGroup(int ranObjstacleDir)
    {
        int ran = Random.Range(0, vars.grassPlatFormGroup.Count);
        GameObject go = Instantiate(vars.grassPlatFormGroup[ran], transform);
        go.transform.position = platFormSpawnPostion;
        go.GetComponent<PlatFormScript>().Init(selectPlatFormSprite,ranObjstacleDir);
    }
    /// <summary>
    /// 生成冬季平台
    /// </summary>
    private void SpawnWinterPlatFormGroup(int ranObjstacleDir)
    {
        int ran = Random.Range(0, vars.winterPlatFormGroup.Count);
        GameObject go = Instantiate(vars.winterPlatFormGroup[ran], transform);
        go.transform.position = platFormSpawnPostion;
        go.GetComponent<PlatFormScript>().Init(selectPlatFormSprite,ranObjstacleDir);
    }
    /// <summary>
    /// 生成钉子平台
    /// </summary>
    /// <param name="dir"></param>
    private void SpawnSpikePlatForm(int dir, int ranObjstacleDir)
    {
        GameObject temp;
        if (dir == 0)
        {
              temp = Instantiate(vars.spikePlatFormRight,transform);
        }
        else
        {
             temp = Instantiate(vars.spikePlatFormLeft, transform);
        }
        temp.transform.position = platFormSpawnPostion;
        temp.GetComponent<PlatFormScript>().Init(selectPlatFormSprite,dir);

    }
}

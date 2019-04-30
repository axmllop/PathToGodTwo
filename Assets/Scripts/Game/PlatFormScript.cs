using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormScript : MonoBehaviour {

    public SpriteRenderer[] spriteRenderers;
    public GameObject obstacles;
	public void Init(Sprite sprite,int obstacleDir)
    {
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].sprite = sprite;
        }
        if (obstacleDir == 0)//朝右边
        {
            if (obstacles != null)
            {
                obstacles.transform.position = new Vector3(-obstacles.transform.position.x,obstacles.transform.position.y, obstacles.transform.position.z);

            }
        }
    }
}

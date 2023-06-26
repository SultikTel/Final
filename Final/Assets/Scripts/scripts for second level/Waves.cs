using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Waves : MonoBehaviour
{
    public GameObject[] teams_enemy;
    int index;
    int numsEnemiesRightNow;
    public Text tasks;
    //public GameObject[] all_enemies;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        teams_enemy[1].SetActive(false);
        numsEnemiesRightNow = teams_enemy[index].transform.childCount;
    }

    public void Enemy_death()
    {
        numsEnemiesRightNow--;
        if(numsEnemiesRightNow == 0)
        {
            if(index < teams_enemy.Length - 1)
            {
               index++;
               teams_enemy[index].SetActive(true);
               tasks.text = index + " wave is passed.";
               numsEnemiesRightNow = teams_enemy[index].transform.childCount;
            }else {
               tasks.text = " All wave is passed.";
               StartCoroutine(nextScene());
            }
        }
    }
    IEnumerator nextScene()
    {
        Cursor.visible = true;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MovieCredits");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_1 : MonoBehaviour
{
    public void Save(float hp, Transform transform_fps, int numberOfScene)
    {
        PlayerPrefs.SetFloat("Hp_onfirstSave", hp);
        PlayerPrefs.SetFloat("SceneOfFirstSave", numberOfScene);

        PlayerPrefs.SetFloat("X_onfirstSave", transform_fps.position.x);
        PlayerPrefs.SetFloat("Y_onfirstSave", transform_fps.position.y);
        PlayerPrefs.SetFloat("Z_onfirstSave", transform_fps.position.z);

    }
}

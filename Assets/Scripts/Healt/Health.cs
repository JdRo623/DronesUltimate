using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public interface Health{
    void ReciveDamage(float damage);
    void InitHealt();
    float GetCurrentHealt();
    void Died();
}


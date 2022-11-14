using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScenePlayerDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject _aosPlayer;
    private SceneChanger _sceneChanger;
    private void Awake()
    {
        _sceneChanger = FindObjectOfType<SceneChanger>();
    }
    private void OnEnable()
    {
            
    }
    private void OnDisable()
    {
        
    }
    
    private void OnDestroyPlayer()
    {
        Destroy(_aosPlayer);
    }
}

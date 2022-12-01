using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllersHandler : MonoBehaviour
{
    public static ControllersHandler Instance;
    [SerializeField] private AOSColliderActivator _aosColliderActivator;
    [SerializeField] private BackButtonsHandler _backButtonsHandler;
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private AOSImageContainer _aosImageContainer;
    [SerializeField] private HtmlToText _htmlToText;
    private ControllersHandler() { }
   
    private void Awake()
    {
        if(Instance==null)
            Instance = this;
    }
    public AOSColliderActivator GetAOSColliderActivator() =>  _aosColliderActivator;
    public BackButtonsHandler GetBackButtonsHandler() =>  _backButtonsHandler;
    public SceneChanger GetSceneChanger() => _sceneChanger;
    public AOSImageContainer GetAOSImageContainer()  => _aosImageContainer;
    public HtmlToText GetHtmlToText() => _htmlToText;
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScreenChanger : MonoBehaviour
{
    [SerializeField] private BaseScreenView[] _screens;
    private BaseScreenView _baseScreenView;
    public void EnableScreen(string name)
    {
        foreach (var screen in _screens)
        {
            screen.ActivateScreen(false);
        }
 
      BaseScreenView temp = _screens.FirstOrDefault(n => n.GetScreenName == name);
        if (temp != null)
        {
            temp.ActivateScreen(true);
            _baseScreenView= temp;
        }
            
    }
    public BaseScreenView GetCurrentBaseScreen()
    {
        if(_baseScreenView!=null)
        return _baseScreenView;
        else return null;
    }
}

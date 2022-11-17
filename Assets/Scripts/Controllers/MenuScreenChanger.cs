using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuScreenChanger : MonoBehaviour
{
    [SerializeField] private BaseScreenView[] _screens;
    public void EnableScreen(string name)
    {
        foreach (var screen in _screens)
        {
            screen.ActivateScreen(false);
        }
 
      BaseScreenView temp = _screens.FirstOrDefault(n => n.GetScreenName == name);
        if(temp!=null)
            temp.ActivateScreen(true);
    }
}

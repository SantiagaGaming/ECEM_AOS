using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OtkazUIButton : MonoBehaviour
{
    private Button _button;
    private void Start()
    {
        _button= GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }
    private void OnButtonClick()
    {
        API api = FindObjectOfType<API>();
        api.OnReasonInvoke(gameObject.name);
        _button.enabled = false;
        StartCoroutine(ButtonEnabler());
    }
    private IEnumerator ButtonEnabler()
    {
        yield return new WaitForSeconds(0.5f);
        _button.enabled = true;
    }

}

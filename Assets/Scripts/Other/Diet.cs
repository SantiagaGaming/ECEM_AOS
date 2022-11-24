using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diet : MonoBehaviour
{
    [SerializeField] private GameObject _diet;
    [SerializeField] private GameObject _buttonPlus;
    [SerializeField] private GameObject _buttonMinus;
    [SerializeField] private GameObject _buttonIndication;
    [SerializeField] private StrelkaButton _strelkaMinus;
    [SerializeField] private StrelkaButton _strelkaPlus;
    [SerializeField] private StrelkaButton _indication;
    [SerializeField] private RadioButtonsContainer _radioContainer;

    private SceneAosObject _minusID;
    private SceneAosObject _plusID;
    private SceneAosObject _indicationID;

    public static Diet Instance;
    private void Awake()
    {
        if(Instance ==null)
        Instance = this;
    }

    public void EnableDiet(bool value, Transform position)
    {
        if (value)
        {
            _strelkaMinus.GetComponent<Collider>().enabled = true;
            _strelkaPlus.GetComponent<Collider>().enabled = true;
            _indication.GetComponent<Collider>().enabled = true;
            _diet.transform.position = position.position;
            _diet.transform.rotation = position.rotation;
        }
        StartCoroutine(DietMover(value));
    }
    private IEnumerator DietMover(bool value)
    {
        if (value)
        {

            _buttonMinus.SetActive(false);
            _buttonPlus.SetActive(false);
            _buttonIndication.SetActive(false);
        }

        int x = 0;
        while (x <= 32)
        {
            if (value)
            {
                _diet.SetActive(true);
                _diet.transform.position += new Vector3(0, 0.0125f, 0);
            }
            else
            {
                _buttonPlus.SetActive(false);
                _buttonMinus.SetActive(false);
                _buttonIndication.SetActive(false);
                _diet.transform.position -= new Vector3(0, 0.0125f, 0);
            }
            yield return new WaitForSeconds(0.02f);
            x++;
        }
        if (!value)
        {
            _diet.SetActive(false);
        }


    }
    public void EnablePlusOrMinus(string button)
    {
        Debug.Log(button);
        if (button == "d_dsp_workplace_radio_c3" ||
           button == "d_dsp_shvu_radio_c3" ||
            button == "d_uvk_cpu_radio_c3" ||
             button == "d_uvk_uso1_radio_c3" ||
              button == "d_uvk_uso2_radio_c3" ||
               button == "d_uvk_kp1_radio_c3" ||
                button == "d_uvk_kp2_radio_c3" ||
                 button == "d_shn_workplace_radio_c3" ||
                  button == "d_relay_radio_c3" ||
                   button == "d_relay_221_radio_c3" ||
            button == "d_relay_231_radio_c3" ||
            button == "d_cross_211_radio_c3" ||
            button == "d_feed_tsch_radio_c3" ||
            button == "d_feed_rsch_radio_c3"||
            button == "d_dga_device_radio_c3"||
            button == "d_dga_control_radio_c3" ||
            button == "d_dga_fueltanks_radio_c3" ||
            button == "d_field_pointed_witl_radio_c3" ||
            button == "d_field_pointed_witd_radio_c3" ||
            button == "d_field_pointed_draft_radio_c3" ||
            button == "d_field_pointed_boot_radio_c3")
        {

            _plusID = _radioContainer.GetRadioButton(button);
            _buttonPlus.SetActive(true);

        }
        if (button == "d_dsp_workplace_radio_c2" ||
           button == "d_dsp_shvu_radio_c2" ||
            button == "d_uvk_cpu_radio_c2" ||
             button == "d_uvk_uso1_radio_c2" ||
              button == "d_uvk_uso2_radio_c2" ||
               button == "d_uvk_kp1_radio_c2" ||
                button == "d_uvk_kp2_radio_c2" ||
                 button == "d_shn_workplace_radio_c2" ||
                  button == "d_relay_radio_c2" ||
                   button == "d_relay_221_radio_c2" ||
            button == "d_relay_231_radio_c2" ||
            button == "d_cross_211_radio_c2" ||
            button == "d_feed_tsch_radio_c2" ||
            button == "d_feed_rsch_radio_c2" ||
            button == "d_dga_device_radio_c2" ||
            button == "d_dga_control_radio_c2" ||
            button == "d_dga_fueltanks_radio_c2" ||
            button == "d_field_pointed_witl_radio_c2" ||
            button == "d_field_pointed_witd_radio_c2" ||
            button == "d_field_pointed_draft_radio_c2" ||
            button == "d_field_pointed_boot_radio_c2"
            )
        {

            _minusID = _radioContainer.GetRadioButton(button);
            _buttonMinus.SetActive(true);

        }
        if (button == "d_dsp_workplace_radio_c1" ||
    button == "d_dsp_shvu_radio_c1" ||
     button == "d_uvk_cpu_radio_c1" ||
      button == "d_uvk_uso1_radio_c1" ||
       button == "d_uvk_uso2_radio_c1" ||
        button == "d_uvk_kp1_radio_c1" ||
         button == "d_uvk_kp2_radio_c1" ||
          button == "d_shn_workplace_radio_c1" ||
           button == "d_relay_radio_c1" ||
            button == "d_relay_221_radio_c1" ||
            button == "d_relay_231_radio_c1" ||
            button == "d_cross_211_radio_c1" ||
            button == "d_feed_tsch_radio_c1" ||
            button == "d_feed_rsch_radio_c1" ||
            button == "d_dga_device_radio_c1" ||
            button == "d_dga_control_radio_c1" ||
            button == "d_dga_fueltanks_radio_c1" ||
            button == "d_field_pointed_witl_radio_c1"||
            button == "d_field_pointed_witd_radio_c1"||
            button == "d_field_pointed_draft_radio_c1"||
            button == "d_field_pointed_boot_radio_c1"
     )
        {
            _indicationID = _radioContainer.GetRadioButton(button);
            _buttonIndication.SetActive(true);
        }
        else if (button == null)
        {
            _buttonMinus.SetActive(false);
            _buttonPlus.SetActive(false);
            _buttonIndication.SetActive(false);
        }

    }
public SceneAosObject GetPlusID()
    {
        return _plusID;
    }
    public SceneAosObject GetMinusID()
    {
        return _minusID;
    }
    public SceneAosObject GetIndicationID()
    {
        return _indicationID;
    }

}

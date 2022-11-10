using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diet : MonoBehaviour
{
    [SerializeField] private GameObject _diet;
    [SerializeField] private GameObject _buttonPlus;
    [SerializeField] private GameObject _buttonMinus;
    [SerializeField] private StrelkaButton _strelkaMinus;
    [SerializeField] private StrelkaButton _strelkaPlus;

    public bool Side;
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
                _diet.transform.position -= new Vector3(0, 0.0125f, 0);
            }
            yield return new WaitForSeconds(0.02f);
            x++;
        }
        if (!value)
        {
            _diet.SetActive(false);
        }
        else
        {
            if (Side)
            {
                _buttonPlus.SetActive(true);
            }
            else
                _buttonMinus.SetActive(true);
        }

    }
    public void EnablePlusOrMinus(string button)
    {

        if (button == "d_clutch_radio_c2" ||
           button == "d_e_drive_radio_c2" ||
            button == "d_apron_radio_c2" ||
             button == "d_rod_radio_c2" ||
              button == "d_hollow_left_radio_c2" ||
               button == "d_hollow_right_radio_c2" ||
                button == "d_board_front_radio_c2" ||
                 button == "d_board_back_radio_c2" ||
                  button == "d_stativ_front_radio_c2" ||
                   button == "d_stativ_back_radio_c2")
        {
            Side = true;
            _buttonPlus.SetActive(true);
        }
        else if (button == "d_clutch_radio_c1" ||
           button == "d_e_drive_radio_c1" ||
            button == "d_apron_radio_c1" ||
             button == "d_rod_radio_c1" ||
              button == "d_hollow_left_radio_c1" ||
               button == "d_hollow_right_radio_c1" ||
                button == "d_board_front_radio_c1" ||
                 button == "d_board_back_radio_c1" ||
                  button == "d_stativ_front_radio_c1" ||
                   button == "d_stativ_back_radio_c1"
            )
        {
            Side = false;
            _buttonMinus.SetActive(true);
        }
        else if (button == null)
        {
            _buttonMinus.SetActive(false);
            _buttonPlus.SetActive(false);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    public bool isTransform = false;
    private GameObject transformObject; //Перемещаемый объект
    private GameObject mainObject; //Главный объект, с которым функционируем
    private float positon_y;
    private float positon_x;
    private void Update()
    {
        if (isTransform)
        {
            transform_window();
        }
    }

    public void get_window(GameObject btn)
    {
        windowClass wc = btn.GetComponent<windowClass>();
        transformObject = this.transform.Find(wc.transform_window_name).gameObject;
        mainObject = this.transform.Find(wc.this_window_name).gameObject;
        positon_y = wc.transform_window_position_y;
        positon_x = wc.transform_window_position_x;
        transformObject.transform.localPosition = new Vector3(positon_x,positon_y,0);
        transformObject.SetActive(true);
        isTransform = true;
    }

    private void transform_window()
    {
        transformObject.transform.localPosition = Vector3.MoveTowards(transformObject.transform.localPosition, new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, 0f), (1.4f + Time.deltaTime) * 8f);
        mainObject.transform.localPosition = Vector3.MoveTowards(mainObject.transform.localPosition, new Vector3(this.transform.localPosition.x - positon_x, this.transform.localPosition.y - positon_y, 0f), (1.4f + Time.deltaTime) * 8f);
        if (transformObject.transform.localPosition == new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, 0f))
        {
            isTransform = false;
            mainObject.SetActive(false);
        }
    }
    /*     private void Animation(int x, int y)
        {
            positon_y = y;
            positon_x = x;
            transformObject.transform.localPosition = new Vector3(positon_x, positon_y, 0);
            transformObject.SetActive(true);
            isTransform = true;
        }
        public void get_registration_window()
        {
            transformObject = this.transform.Find("Registration").gameObject;
            mainObject = this.transform.Find("Menu").gameObject;
            Animation(0,-450);
        }
        public void get_main_window()
        {
            transformObject = this.transform.Find("Menu").gameObject;
            mainObject = this.transform.Find("Settings").gameObject;
            Animation(-450,0);
        }
        public void get_settings_window()
        {
            transformObject = this.transform.Find("Settings").gameObject;
            mainObject = this.transform.Find("Menu").gameObject;
            Animation(0,-450);
        }
        public void get_main_window_from_reg()
        {
            transformObject = this.transform.Find("Menu").gameObject;
            mainObject = this.transform.Find("Registration").gameObject;
            Animation(0,-450);
        }*/
}
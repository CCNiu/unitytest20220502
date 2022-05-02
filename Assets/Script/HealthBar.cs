using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    // public Slider slider;
    private Slider slider;
    [SerializeField]
    private Text HPText;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        HPText.text = slider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHealthBar(int hp){
        slider.value = hp;
        HPText.text=hp.ToString();
        if(slider.value <= 0){
            HPText.gameObject.SetActive(false);
        }

    }
}

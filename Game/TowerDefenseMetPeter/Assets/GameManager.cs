using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float Gold = 200;
    [SerializeField]
    private Text GoldText;

    [Header("Canvasen")]
    public Canvas MainCanvas;

    private GameObject Tower;

    [Header("Health Related")]
    /// <summary>
    /// Health of the base
    /// </summary>
    private float Health = 100f;
    [SerializeField]
    private Slider HealthBar;
    [SerializeField]
    private Text HealthBarText;

	// Use this for initialization
	void Start ()
    {
        UpdateText(GoldText, Gold.ToString() + "c");
        UpdateHealth();
    }
	

    public void CanPlace()
    {
        Tower = Instantiate(Resources.Load("Tower", typeof(GameObject))) as GameObject;
        Tower.GetComponent<TowerClass>().StartPlaceingTower();
        //Debug.Log(Tower.name);
        //Tower.transform.position = transform.position;
    }

    public void StopPlacing()
    {
        if (Tower != null)
        {
            Destroy(Tower);
        }
    }

    public float GetGold()
    {
        Debug.Log("Current gold: " + Gold);
        return Gold;
    }

    public void IncreaseGold(float _amount)
    {
        Gold += _amount;
        UpdateText(GoldText, Gold.ToString() + "c");
        Debug.Log("Increased the amount of gold by: " + _amount);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_amount"></param>
    /// <returns></returns>
    public void DecreaseGold(float _amount)
    {
        Gold -= _amount;
        UpdateText(GoldText, Gold.ToString() + "c");
        Debug.Log("Decreased the amount of gold by: " + _amount);
    }

    void UpdateText(Text _text, string _string)
    {
        _text.text = _string;
    }

    /// <summary>
    /// Gets the health of the base
    /// </summary>
    public float GetHealth()
    {
        return Health;
    }

    /// <summary>
    /// Increases the health of the base
    /// </summary>
    /// <param name="_amount"></param>
    public void IncreaseHealth(float _amount)
    {
        Health += _amount;

        if (Health > 100)
            Health = 100;

        UpdateHealth();
    }

    /// <summary>
    /// Decreases the health of the base
    /// </summary>
    /// <param name="_amount"></param>
    public void DecreaseHealth(float _amount)
    {
        Health -= _amount;

        if (Health < 0)
            Health = 0;

        UpdateHealth();
    }

    /// <summary>
    /// Updates the healthbar
    /// </summary>
    private void UpdateHealth()
    {
        HealthBar.value = Health / 100;
        HealthBarText.text = "Health: " + Mathf.Round(Health) + "%";
    }
}

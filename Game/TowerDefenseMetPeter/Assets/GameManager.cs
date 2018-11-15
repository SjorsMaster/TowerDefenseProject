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

	// Use this for initialization
	void Start ()
    {
		
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

    public float CurrentGold()
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
}

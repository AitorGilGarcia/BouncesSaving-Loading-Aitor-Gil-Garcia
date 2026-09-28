using TMPro;
using UnityEngine;

public class ControllerUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] bolaController bolaController;

    private void OnEnable()
    {
        text.text = "0";
        bolaController.onBounceOffGround.AddListener(UpdateUI);
    }
    void UpdateUI()
    {
        text.text = bolaController.GetBounces().ToString();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

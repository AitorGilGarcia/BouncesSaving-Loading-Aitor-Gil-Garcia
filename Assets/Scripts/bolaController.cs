using UnityEngine;
using UnityEngine.Events;

public class bolaController : MonoBehaviour
{
    int bounces = 0;
    [HideInInspector] public UnityEvent onBounceOffGround = new UnityEvent();
    public int GetBounces() 
    { 
        return bounces; 
    }

    public void SetBounces(int totalBounces)
    {
        bounces = totalBounces;
    }

    private void OnCollisionEnter(Collision collision)
    {
        bounces++;
        onBounceOffGround.Invoke();
        Debug.Log(bounces);
    }
   



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

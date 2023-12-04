using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    [SerializeField] public int experience_reward = 50;
    private GameObject vampiro;
    
    void Awake()
    {
        vampiro = GameObject.Find("Slime");
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Inimigo" || collision.gameObject.tag == "InimigoFoda")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            vampiro.GetComponent<Level>().AddExperience(experience_reward);
        }
    }
}

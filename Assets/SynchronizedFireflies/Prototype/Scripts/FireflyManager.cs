using UnityEngine;
using System.Collections;

public class FireflyManager : MonoBehaviour
{
    #region variables
    public GameObject fireflies;

    static FireflyManager m_instance;
    public FireflyManager Instance
    {
        get {
            if (m_instance == null)
            {
                m_instance = new FireflyManager();
            }
            return m_instance;
        }   
    }

    FireflyController[] m_controllers;
    public float couplingConst = 1.0f;  // 結合強度
    #endregion

    void Awake()
    {
        
    }

    void Start()
    {
        m_controllers = fireflies.GetComponentsInChildren<FireflyController>();
    }

	void Update ()
    {
	    for (int i = 0; i < m_controllers.Length; i++)
        {
            float angularVelocity = m_controllers[i].naturalAngularFreq;
            for (int j = 0; j < i; j++)
            {
                float w_ij = couplingConst / (1.0f + Vector3.SqrMagnitude(
                    m_controllers[j].transform.position - m_controllers[i].transform.position
                ));
                angularVelocity += w_ij * Mathf.Sin(
                        m_controllers[j].phase - m_controllers[i].phase
                    );
            }
            m_controllers[i].angularFreq = angularVelocity;
        }

        for (int i = 0; i < m_controllers.Length; i++)
        {
            m_controllers[i].UpdatePhase();
        }
	}

    void Sync()
    {

    }
}

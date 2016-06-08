using UnityEngine;
using System.Collections;

public class FireflyController : MonoBehaviour {
    Material m_material;

    public float naturalAngularFreq;     // 個体固有の角速度
    public float phase;             // 明滅の位相
    public float angularFreq;       // 位相の変化速度

	void Start ()
    {
        m_material = GetComponent<MeshRenderer>().material;
        naturalAngularFreq = 2.0f * Mathf.PI * (0.3f + Random.Range(-0.1f, 0.1f));
        phase = 2.0f * Mathf.PI * Random.Range(0.0f, 1.0f);

        Camera camera = Camera.main;
        float x = camera.aspect * Random.Range(-camera.orthographicSize, camera.orthographicSize);
        float y = Random.Range(-camera.orthographicSize, camera.orthographicSize);
        transform.position = new Vector3(x, y, 0.0f);
	}

    void Update()
    {
        float intensity = 0.5f + 0.5f * Mathf.Sin(phase);
        m_material.color = Color.white * intensity;
    }

    public void UpdatePhase()
    {
        phase += angularFreq * Time.deltaTime;
    }
}

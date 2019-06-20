using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColumnConverge : MonoBehaviour
{
    private ParticleSystem pSystem;
    private ParticleSystem.Particle[] particles;
    private Vector3[] startPositions;
    private Vector3 vertCenter;

    private void Awake()
    {
        pSystem = GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        particles = new ParticleSystem.Particle[pSystem.main.maxParticles];
        startPositions = new Vector3[pSystem.main.maxParticles];

        Vector3[] vArray = new Vector3[5];
        Debug.Log("test");
    }

    // Update is called once per frame
    void Update()
    {
        int numParticles = pSystem.GetParticles(particles);
        for (int i = 0; i < numParticles; i++)
        {


            ParticleSystem.Particle particle = particles[i];

            // store the starting position of this particle if it's the first time
            if (startPositions[i] == Vector3.zero)
            {
                startPositions[i] = particle.position;
            }

            vertCenter = new Vector3(0, particle.position.y, particle.position.z);
            //particle.position = Vector3.Lerp(particle.position, vertCenter, (particle.startLifetime - particle.remainingLifetime) / particle.startLifetime);
            particle.position = Vector3.Lerp(startPositions[i], vertCenter, (particle.startLifetime - particle.remainingLifetime) / particle.startLifetime);

            particles[i] = particle;
        }
        pSystem.SetParticles(particles, numParticles);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AtivaFim : MonoBehaviour
{
    public GameObject Labirinto;
    public GameObject Fim;
    public GameObject Player;
    public GameObject Musica;
    public GameObject MusicaFim;

    public Vector3 fimPosAlvo = new Vector3(-48, 0, 90);
    public Vector3 fimPosOriginal;

    private Vector3 labirintoPosOriginal;
    private Vector3 labirintoPosSumiu = new Vector3(-72, 0, -200);

    private AudioSource _audioSource;
    private AudioSource _audioSourceFim;

    private bool Handled = false;
    
    void Start()
    {
        PlayerController.OnPlayerDeath += HandleDeath;
        labirintoPosOriginal = Labirinto.transform.position;
        fimPosOriginal = Fim.transform.position;
        _audioSource = Musica.GetComponent<AudioSource>();
        _audioSourceFim = MusicaFim.GetComponent<AudioSource>();
    }

    private void HandleDeath()
    {
        if (!Handled)
            return;
        
        Labirinto.transform.position = labirintoPosOriginal;
        Fim.transform.position = fimPosOriginal;
        _audioSource.Play();
        _audioSourceFim.Stop();

        Handled = false;
    }

    private void Update()
    {
        if (Handled)
            return;

        if (Player.transform.position.z < 140)
            return;

        Fim.transform.position = fimPosAlvo;
        Labirinto.transform.position = labirintoPosSumiu;
        _audioSource.Stop();
        _audioSourceFim.Play();

        Handled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Handled)
            return;
        
        if (other.CompareTag("Player"))
        {
            Fim.transform.position = fimPosAlvo;
            Labirinto.transform.position = labirintoPosSumiu;

            Handled = true;
        }
    }
}

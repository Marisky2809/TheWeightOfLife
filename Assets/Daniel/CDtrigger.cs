using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDtrigger : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SistemaGuardado sistemaGuardado;
    [SerializeField] private HUD canvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.CDs++;
            if (gameManager.CDs > 3)
            {
                gameManager.CDs = 0;
                gameManager.MaxVidas++;
                sistemaGuardado.partida.vidas = gameManager.MaxVidas;


                canvas.CDs[0].SetActive(false);
                canvas.CDs[1].SetActive(false);
                canvas.CDs[2].SetActive(false);


                canvas.vidas[1].SetActive(true);
                canvas.vidas[2].SetActive(true);
                canvas.vidas[3].SetActive(true);


                if (gameManager.MaxVidas == 5)
                {
                    canvas.vidas[4].SetActive(true);
                }
                if (gameManager.MaxVidas == 6)
                {
                    canvas.vidas[4].SetActive(true);
                    canvas.vidas[5].SetActive(true);
                }
                canvas.vidas[gameManager.MaxVidas - 1].SetActive(true);
            }
            else if(gameManager.CDs == 1){
                canvas.CDs[0].SetActive(true);
            }
            else if (gameManager.CDs == 2)
            {
                canvas.CDs[1].SetActive(true);
            }
            else if (gameManager.CDs == 3)
            {
                canvas.CDs[2].SetActive(true);
            }
            Destroy(this.gameObject);
        }
    }
}

using UnityEngine;

public class ComportamentoPersonagem : MonoBehaviour
{
    public float velocidadePersonagem, forcaDoPulo;

    // Update is called once per frame
    void Update()
    {
        // Este código é para fazer o personagem ir para a direita
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 novaPos = new Vector3(velocidadePersonagem * Time.deltaTime, 0, 0);
            transform.localPosition += novaPos;

            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        // Este código é para fazer o personagem ir para a esquerda
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 novaPos = new Vector3(velocidadePersonagem * Time.deltaTime, 0, 0);
            transform.localPosition -= novaPos;

            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        // Este código é para fazer o personagem pular
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (gameObject.GetComponent<Rigidbody2D>().linearVelocity.y == 0)
            {
                Vector2 sentidoCima = new Vector2(0, 1);
                gameObject.GetComponent<Rigidbody2D>().AddForce(sentidoCima * forcaDoPulo);
            }
        }
    }
}

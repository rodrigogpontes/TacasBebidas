using UnityEngine;
using UnityEngine.UI;

public class ControladorFase : MonoBehaviour
{
    internal float TempoRestante;
    public GameObject telaGanhou, telaPerdeuErrou, telaPerdeuTempo, telaPause;

    // Elementos gráficos presentes na barra superior do game
    public Image imagemTacaSelecionada;
    public Text textoTempoRestante, textoFaseAtual;

    // Vetores das imagens das garrafas e dos tipos de bebidas
    public Sprite[] bebidas;
    public string[] tipos;

    // Variáveis representando o objeto do personagem e da garrafa
    public GameObject personagem;
    public SpriteRenderer bebidaNaTela;

    // Variáveis de controle
    internal int faseAtual, numBebidaAtual;
    internal string nomeBebidaAtual, nomeTacaAtual;
    internal Vector3 posInicialPersonagem;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posInicialPersonagem = personagem.transform.localPosition;
        TempoRestante = 60;
        faseAtual = 1;
        nomeTacaAtual = "";
        EscolherUmaBebida();
        imagemTacaSelecionada.sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        // Código para diminuir o tempo
        TempoRestante -= Time.deltaTime;

        // Código para atualizar os textos na tela:
        textoTempoRestante.text = "Tempo restante:" + TempoRestante.ToString("00");
        textoFaseAtual.text = "Fase: " + faseAtual;

        // Verificar se o tempo acabou:
        if (TempoRestante <= 0)
        {
            telaPerdeuTempo.SetActive(true);
            Time.timeScale = 0;
            TempoRestante = 0;
        }
    }

    public void PegarTaca(GameObject taca)
    {
        imagemTacaSelecionada.sprite = taca.GetComponent<SpriteRenderer>().sprite;
        imagemTacaSelecionada.preserveAspect = true;
        nomeTacaAtual = taca.GetComponent<ControladorTaca>().tipo;
    }

    public void Comparar()
    {
        if (nomeTacaAtual == nomeBebidaAtual)
        {
            telaGanhou.SetActive(true);
            Time.timeScale = 0;
        }
        else if (nomeTacaAtual != "")
        {
            telaPerdeuErrou.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void EscolherUmaBebida()
    {
        int valorAleatorio = (int)(Random.value * bebidas.Length);

        if (numBebidaAtual == valorAleatorio)
            valorAleatorio++;

        bebidaNaTela.sprite = bebidas[valorAleatorio];
        nomeBebidaAtual = tipos[valorAleatorio];
    }

    public void Pausar()
    {
        telaPause.SetActive(true);
        Time.timeScale = 0;
    }
    public void Despausar()
    {
        telaPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void AvancarFase()
    {
        // Avanço para a próxima fase
        faseAtual += 1;

        // Reposiciono o personagem na posição inicial
        personagem.transform.localPosition = posInicialPersonagem;

        // Acrescento 10s ao tempo restante
        TempoRestante += 10;

        // "Tiro" a taça da mão do jogador e mando escolher nova bebida
        nomeTacaAtual = "";
        EscolherUmaBebida();
        imagemTacaSelecionada.sprite = null;

        // Desligo a "tela ganhou" e descongelo o tempo
        telaGanhou.SetActive(false);
        Time.timeScale = 1;
    }

    public void RecomecarFase()
    {
        faseAtual = 1;

        // Reposiciono o personagem na posição inicial
        personagem.transform.localPosition = posInicialPersonagem;

        TempoRestante = 60;

        // "Tiro" a taça da mão do jogador e mando escolher nova bebida
        nomeTacaAtual = "";
        EscolherUmaBebida();
        imagemTacaSelecionada.sprite = null;

        telaPerdeuErrou.SetActive(false);
        telaPerdeuTempo.SetActive(false); // ESSA LINHA É DUPLICADA DA DE CIMA, MAS ADAPTADA
        Time.timeScale = 1;
    }


    /*
    public Image imagemTacaSelecionada;
    public Text textoTempoRestante, textoFaseAtual;

    public Sprite[] bebidas;
    public string[] tipos;
    public GameObject personagem;
    public SpriteRenderer bebinaNaTela;

    internal int faseAtual, numBebidaAtual;
    internal string nomeBebidaAtual, nomeTacaAtual;
    internal Vector3 posInicialPersonagem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posInicialPersonagem = personagem.transform.localPosition;
        TempoRestante = 60;
        faseAtual = 1;

        imagemTacaSelecionada.sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        // Código para diminuir o tempo
        TempoRestante -= Time.deltaTime;

        // Código para atualizar os textos na tela:
        textoTempoRestante.text = "Tempo restante:" + TempoRestante.ToString("00");
        textoFaseAtual.text = "Fase: " + faseAtual;

        // Verificar se o tempo acabou:
        if (TempoRestante <= 0)
        {
            telaPerdeuTempo.SetActive(true);
            Time.timeScale = 0;
            TempoRestante = 0;
        }
    }

    public void PegarTaca(GameObject taca)
    {
        imagemTacaSelecionada.sprite = taca.GetComponent<SpriteRenderer>().sprite;
        nomeTacaAtual = taca.GetComponent<ControladorTaca>().tipoTaca;
    }

    public void EscolherUmaBebida()
    {
        int valorAleatorio = (int)(Random.value * bebidas.Length);

        if (numBebidaAtual == valorAleatorio)
            valorAleatorio++;

        bebinaNaTela.sprite = bebidas[valorAleatorio];
        nomeBebidaAtual = tipos[valorAleatorio];
    }



    */

}

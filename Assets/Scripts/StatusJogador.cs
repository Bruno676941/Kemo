[System.Serializable]
public class StatusJogador
{
    public Atributos atributos = new Atributos();

    public int vida;
    public int dano;
    public int iniciativa;

    public void InicializarStatus()
    {
        atributos.forca = 4;
        atributos.agilidade = 4;
        atributos.vitalidade = 4;

        vida = atributos.CalcularVida() + 12;
        dano = atributos.CalcularDano() + 2;
        iniciativa = atributos.CalcularIniciativa() + 2;
    }
}

[System.Serializable]
public class Atributos
{
    public int forca;
    public int agilidade;
    public int vitalidade;

    public int CalcularDano() => forca / 2;

    public int CalcularIniciativa() => agilidade / 2;

    public int CalcularVida() => vitalidade;
}
namespace projeto_dbm.Models
{
    public class Pessoa
{
    public int Id { get; set; }  // Certifique-se de que isso é a chave primária
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Cidade { get; set; }
    public string Profissao { get; set; }
}
}

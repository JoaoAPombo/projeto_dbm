using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto_dbm.Data;
using projeto_dbm.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace projeto_dbm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly ContextoBD _contexto;

        // Injeção de dependência para o contexto do banco de dados
        public PessoasController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        // POST: api/Pessoas/importar-csv
        [HttpPost("importar-csv")]
        public async Task<IActionResult> ImportarCsv(IFormFile arquivoCsv)
        {
            // Verifica se o arquivo foi enviado
            if (arquivoCsv == null || arquivoCsv.Length == 0)
            {
                Console.WriteLine("Nenhum arquivo foi enviado."); // Log de depuração
                return BadRequest("Nenhum arquivo foi enviado.");
            }

            // Lê o arquivo CSV enviado
            using (var stream = new StreamReader(arquivoCsv.OpenReadStream()))
            {
                var linhas = await stream.ReadToEndAsync();

                // Log para verificar o conteúdo do arquivo CSV
                Console.WriteLine("Arquivo CSV lido com sucesso.");
                Console.WriteLine($"Conteúdo do arquivo: {linhas}");

                // Processa as linhas do CSV
                var pessoas = linhas.Split("\n").Skip(1).Select(linha =>
                {
                    var dados = linha.Split(',').Select(d => d.Trim()).ToArray(); // Remover espaços extras

                    // Verifica se a linha tem pelo menos 4 colunas
                    if (dados.Length < 4)
                    {
                        Console.WriteLine($"Linha inválida (ignorada): {linha}"); // Log de depuração
                        return null; // Linha inválida
                    }

                    // Cria uma nova pessoa a partir dos dados do CSV
                    return new Pessoa
                    {
                        Nome = dados[1],  // Nome está na 1ª coluna
                        Idade = int.TryParse(dados[2], out var idade) ? idade : 0, // Idade está na 2ª coluna
                        Cidade = dados[3], // Cidade está na 3ª coluna
                        Profissao = dados[4] // Profissão está na 4ª coluna
                    };
                }).Where(p => p != null).ToList();

                // Log para verificar quantas pessoas foram processadas
                Console.WriteLine($"Total de pessoas processadas: {pessoas.Count}");

                // Adiciona as pessoas ao banco de dados
                await _contexto.Pessoas.AddRangeAsync(pessoas);

                // Log para verificar a tabela em que os dados estão sendo inseridos
                var tabela = _contexto.Model.FindEntityType(typeof(Pessoa)).GetTableName();
                Console.WriteLine($"Adicionando dados à tabela: {tabela}");

                // Obter o nome do banco de dados da string de conexão
                var connection = _contexto.Database.GetDbConnection();
                var connectionString = connection.ConnectionString;
                var databaseName = new SqlConnectionStringBuilder(connectionString).InitialCatalog;

                // Log para verificar o banco de dados
                Console.WriteLine($"Adicionando dados ao banco de dados: {databaseName}");

                // Aqui é onde o SaveChanges é chamado para salvar as alterações no banco de dados
                await _contexto.SaveChangesAsync();

                // Log após salvar os dados
                Console.WriteLine("Pessoas adicionadas ao banco de dados com sucesso.");

                // Verificação: consulta para verificar se os dados foram adicionados
                var totalPessoas = await _contexto.Pessoas.CountAsync();
                Console.WriteLine($"Total de pessoas no banco de dados após inserção: {totalPessoas}");

                // Outra consulta SQL para garantir que as pessoas foram inseridas
                var ultimaPessoa = await _contexto.Pessoas
                    .OrderByDescending(p => p.Id) // Ordena pela última inserida
                    .FirstOrDefaultAsync();
                
                if (ultimaPessoa != null)
                {
                    Console.WriteLine($"Última pessoa inserida: {ultimaPessoa.Nome}, {ultimaPessoa.Idade}, {ultimaPessoa.Cidade}, {ultimaPessoa.Profissao}");
                }
            }

            return Ok("CSV importado com sucesso.");
        }
    }
}

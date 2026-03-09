using MauiApp1MinhasCompras.Models;
using SQLite;

namespace MauiApp1MinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _connection;
        public SQLiteDatabaseHelper(string path)
        // construtor sempre é chamado quando a classe é instanciada, e nesse caso, ele é responsável
        // por estabelecer a conexão com o banco de dados SQLite. O caminho do arquivo "produtos.db"
        // é especificado para criar ou acessar o banco de dados.
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p)
        {
            return _connection.InsertAsync(p);
        }
        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade =?, Preco=? WHERE Id=? ";

            return _connection.QueryAsync<Produto>(sql, p.Descricao, p.Quantidade, p.Preco);
        }
        public Task<int> Delete(int id)
        {
            return _connection.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Produto>> GetAll()
        // o método GetAll é responsável por recuperar todos os registros da tabela
        // Produto do banco de dados. Ele utiliza o método Table para acessar a tabela
        // Produto e o método ToListAsync para converter os resultados em uma lista de objetos
        {
            return _connection.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string q)
        // faz a busca instantaneamente, sem a necessidade de clicar em um botão
        // para iniciar a busca. O método QueryAsync
        {
            string sql = "SELECT * Produto WHERE descricao LIKE  '%" + q + "%'";

            return _connection.QueryAsync<Produto>(sql);


        }
    }
}

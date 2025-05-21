using ClassFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infra.DataAcess;
public class cashflowDbcontext : DbContext
{

    public DbSet<Expenses> expenses { get; set; } // cria a variavel com o nome da tabela no caso expenses

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conectionstring = "Server=localhost;Database=cashflowdd;Uid=root;Pwd=300904Ca!";
        var version = new Version(8, 0, 42);
        var serverVersion = new MySqlServerVersion(version);

        optionsBuilder.UseMySql(conectionstring , serverVersion);
    }
}

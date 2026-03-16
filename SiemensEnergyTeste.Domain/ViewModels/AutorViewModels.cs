namespace SiemensEnergyTeste.Domain.ViewModels
{
    public class AutorViewModels
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public ICollection<LivroViewModels> Livros { get; set; }
    }
}

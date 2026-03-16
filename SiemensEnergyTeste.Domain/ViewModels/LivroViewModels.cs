namespace SiemensEnergyTeste.Domain.ViewModels
{
    public class LivroViewModels
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public AutorViewModels Autor { get; set; }
        public GeneroViewModels Genero { get; set; }
    }
}

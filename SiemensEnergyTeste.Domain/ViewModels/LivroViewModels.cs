namespace SiemensEnergyTeste.Domain.ViewModels
{
    public class LivroViewModels
    {
        public Guid? Id { get; set; }
        public string Titulo { get; set; }
        public Guid AutorId { get; set; }
        public AutorViewModels? Autor { get; set; }
        public Guid GeneroId { get; set; }
        public GeneroViewModels? Genero { get; set; }
    }
}

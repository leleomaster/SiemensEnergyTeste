namespace SiemensEnergyTeste.Domain.Dtos
{
    public class GeneroDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public ICollection<LivroDto> Livros { get; set; }
    }
}

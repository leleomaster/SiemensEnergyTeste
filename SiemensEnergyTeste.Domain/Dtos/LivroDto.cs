namespace SiemensEnergyTeste.Domain.Dtos
{
    public class LivroDto
    {
        public Guid? Id { get; set; }
        public string Titulo { get; set; }
        public Guid AutorId { get; set; }
        public AutorDto? Autor { get; set; }
        public Guid GeneroId { get; set; }
        public GeneroDto? Genero { get; set; }
    }
}

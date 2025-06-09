namespace ApiGastos.Dto;
public class GastosDto
{
    public int Id { get; set; }
    public decimal Monto { get; set; }
    public string Descripcion { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public string NombreComercio { get; set; } = null!;
    }

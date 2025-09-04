public class Ticket
{
	public int Numero { get; set; }
	public string Usuario { get; set; }

	public Ticket(int numero, string usuario)
	{
		Numero = numero;
		Usuario = usuario;
	}
}

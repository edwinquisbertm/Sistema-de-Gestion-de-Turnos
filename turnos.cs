public class Turnos
{
	private Queue<Ticket> colaTurnos = new Queue<Ticket>();

	public void AgregarTurno(Ticket ticket)
	{
		colaTurnos.Enqueue(ticket);
	}

	public Ticket SiguienteTurno()
	{
		if (colaTurnos.Count > 0)
			return colaTurnos.Peek();
		return null;
	}

	public Ticket CompletarTurno()
	{
		if (colaTurnos.Count > 0)
			return colaTurnos.Dequeue();
		return null;
	}

	public int TurnosRestantes()
	{
		return colaTurnos.Count;
	}
}

namespace examen1consola.Modelos
{
    public class TratamientoMedico
    {
        public Paciente Paciente { get; set; }
        public Medicamento[] Medicamento { get; set; } = new Medicamento[3];
    }
}

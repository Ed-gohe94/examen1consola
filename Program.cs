using examen1consola.Modelos;

class Programa
{
    public static TratamientoMedico[] tratamientosMedicos = new TratamientoMedico[10];
    public static Medicamento[] medicamentos;
    public static void Main(string[] args)
    {
        int seleccion;
        do
        {
            Console.WriteLine("==============================");
            Console.WriteLine("             Menú             ");
            Console.WriteLine("==============================");
            Console.WriteLine("1. Agregar Paciente");
            Console.WriteLine("2. Agregar medicamento al catalogo");
            Console.WriteLine("3. Asignar tratamiento médico a un paciente");
            Console.WriteLine("4. Reportes");
            Console.WriteLine("\n");

            seleccion = int.Parse(Console.ReadLine());

            switch (seleccion) //casos: 
            {
                case 1:
                    AgregarPaciente();
                    break;
                case 2:
                    AgregarMedicamentosAlCatalogo();
                    break;
                case 3:
                    AsignarMedicamentoPaciente();
                    break;
                case 4:
                    break;

            }

        } while (seleccion != 7);

    }
    public static void AgregarPaciente()
    {
        for (int i = 0; i <= tratamientosMedicos.Length; i++)
        {
            if (tratamientosMedicos[i] == null)
            {
                Console.WriteLine("Nombre del paciente");
                Paciente paciente = new Paciente();
                Console.WriteLine("Escriba su identificación");
                paciente.Cedula = Console.ReadLine();
                Console.WriteLine("Escriba su nombre");
                paciente.Nombre = Console.ReadLine();
                Console.WriteLine("Digite su numero de telefono");
                paciente.Telefono = Console.ReadLine();
                Console.WriteLine("Digite tipo de sangre");
                paciente.TipoDeSangre = Console.ReadLine();
                Console.WriteLine("Digite direccion");
                paciente.Direccion = Console.ReadLine();
                Console.WriteLine("Fecha de nacimiento");
                Console.WriteLine("Ingrese día de nacimiento");
                int dia = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese mes de nacimiento");
                int mes = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese año de nacimiento");
                int anno = int.Parse(Console.ReadLine());
                paciente.FechaDeNacimiento = new DateTime(anno, mes, dia);
                paciente.Edad = new DateTime((DateTime.Now - paciente.FechaDeNacimiento).Ticks).Year;
                tratamientosMedicos[i] = new TratamientoMedico() { Paciente = paciente };
                break;
            }
        }
    }
    public static void AgregarMedicamentosAlCatalogo()
    {
        medicamentos = new Medicamento[10];

        for (int i = 0; i <= medicamentos.Length; i++)
        {
            if (medicamentos[i] == null)
            {
                Console.WriteLine("Ingrese el medicamento al catálogo");
                Medicamento medicamento = new Medicamento();
                Console.WriteLine("Escriba el código medicamento");
                medicamento.CodigoDelMedicamento = Console.ReadLine();
                Console.WriteLine("Digite nombre del medicamento");
                medicamento.NombreDelMedicamento = Console.ReadLine();
                Console.WriteLine("Digite cantidad medicamento");
                medicamento.Cantidad = int.Parse(Console.ReadLine());
                medicamentos[i] = medicamento;
                break;
            }
        }
    }
    public static void AsignarMedicamentoPaciente()
    {
        Console.WriteLine("Ingrese la cédula del paciente");
        string id = Console.ReadLine();
        for (int posicion = 0; posicion <= tratamientosMedicos.Length; posicion++)
        {
            if (id == tratamientosMedicos[posicion].Paciente.Cedula)
            {
                Console.WriteLine($"El paciente encontrado es: {tratamientosMedicos[posicion].Paciente.Nombre}");

                Console.WriteLine("Medicamentos en catálogo:");
                foreach (Medicamento item in medicamentos)
                {
                    if (item != null)
                    {
                        Console.WriteLine($"Código{item.CodigoDelMedicamento} Nombre: {item.NombreDelMedicamento}");
                    }
                    else
                    {
                        break;
                    }
                }

                Console.WriteLine("Por favor agregar código de medicamento que quiere asociar al paciente");
                string codigoMedicamento = Console.ReadLine();

                int posicionM = 0;
                for (int m = 0; m <= medicamentos.Length; m++)
                {
                    if (codigoMedicamento == medicamentos[m].CodigoDelMedicamento)
                    {
                        if (tratamientosMedicos[posicion].Medicamento[posicionM] == null)
                        {
                            tratamientosMedicos[posicion].Medicamento[posicionM] = medicamentos[m];
                            break;
                        }
                    }
                }
                break;
            }
        }
    }

    public static void Reportes()
    {
        string[] nombresMedicamentos = new string[120];
        int cantidad = 0;
        foreach (TratamientoMedico item in tratamientosMedicos)
        {
            if (item != null) { cantidad++; }
        }
        Console.WriteLine(cantidad.ToString());

        Console.WriteLine("\n");

        foreach (TratamientoMedico item in tratamientosMedicos)
        {
            if (item != null)
            {
                foreach (Medicamento me in item.Medicamento)
                {
                    for (int i = 0; i <= nombresMedicamentos.Length; i++)
                    {
                        if (nombresMedicamentos[i] == me.NombreDelMedicamento)
                        {
                            break;
                        }
                        else
                        {
                            nombresMedicamentos[i] = me.NombreDelMedicamento;
                        }
                    }
                }
            }
        }
    }
}

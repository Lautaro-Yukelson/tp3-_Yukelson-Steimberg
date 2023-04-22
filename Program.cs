    using System;

    bool habilitado = false;
    Ticketera miTicketera = new Ticketera();
    menu();


    void menu(){
        Console.Clear();
        Console.WriteLine("*******************************");
        Console.WriteLine("¡Bienvenido al InfoPalooza 2023");
        Console.WriteLine("*******************************");
        Console.WriteLine("Eliga una opción para continuar");
        Console.WriteLine("1. Nueva Incripcion");
        Console.WriteLine("2. Obtener Estadisticas del Evento");
        Console.WriteLine("3. Buscar Cliente");
        Console.WriteLine("4. Cambiar Entrada de un Cliente");
        Console.WriteLine("5. Salir");
        int opcion = int.Parse(Console.ReadLine());
        while (opcion < 1 || opcion > 5) opcion = ingresarEntero("Esa opcion no existe, ingrese una valida");
        switch(opcion){
            case 1:
                nuevaIncripcion();
                habilitado = true;
                menu();
                break;
            case 2:
                if (habilitado) estadisticasEvento();
                else{
                    Console.WriteLine("Aun no se anoto nadie");
                    Console.WriteLine("Presione una telca para continuar...");
                    Console.ReadKey();
                }
                menu();
                break;
            case 3:
                if (habilitado) buscarCliente();
                else{
                    Console.WriteLine("Aun no se anoto nadie");
                    Console.WriteLine("Presione una telca para continuar...");
                    Console.ReadKey();
                } 
                menu();
                break;
            case 4:
                if (habilitado) cambiarEntrada();
                else{
                    Console.WriteLine("Aun no se anoto nadie");
                    Console.WriteLine("Presione una telca para continuar...");
                    Console.ReadKey();
                }
                menu();
                break;
            case 5:
                Console.Clear();
                Console.WriteLine("Saliendo del programa...");
                Environment.Exit(-1);
                break;
        }
    }

    void nuevaIncripcion(){
        Dictionary<int, int> dicPrecios = new Dictionary<int, int>(){
        { 1, 15000 },
        { 2, 30000 },
        { 3, 10000 },
        { 4, 40000 }
        };
        Console.Clear();
        Console.WriteLine("**********************************");
        Console.WriteLine("Gracas por comenzar tu instripcion");
        Console.WriteLine("**********************************");
        Console.WriteLine("Eliga una opción para continuar");
        Console.WriteLine("1. Dia 1 - $15.000");
        Console.WriteLine("2. Dia 2 - $30.000");
        Console.WriteLine("3. Dia 3 - $10.000");
        Console.WriteLine("4. Full Pass - $40.000");
        Console.WriteLine("5. Salir");
        int opcion = int.Parse(Console.ReadLine());
        while (opcion < 1 || opcion > 5) opcion = ingresarEntero("Esa opcion no existe, favor de ingresar una valida");
        if (opcion == 5){
            Console.Clear();
            Console.WriteLine("Saliendo del programa...");
            Environment.Exit(-1);
        }
        int totalABonado = dicPrecios[opcion];
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Perfecto, ahora sus datos");
        int dni = ingresarEntero("Ingrese su DNI");
        string strDNI = dni.ToString();
        while(strDNI.Length != 8){
            dni = ingresarEntero("El DNI invalido | Un DNI valido tiene 8 digitos | Ingreselo nuevamente");
            strDNI = dni.ToString();
        }
        string nombre = ingresarTexto("Ahora su nombre porfavor");
        string apellido = ingresarTexto("Seguimos con su apellido");
        Cliente cliente = new Cliente(dni, apellido, nombre, DateTime.Now, opcion, totalABonado);
        miTicketera.agregarCliente(cliente);
    }

    void estadisticasEvento(){
        List<string> listaPImprimir = miTicketera.EstadisticasTicketera();
        for (int i = 0; i<listaPImprimir.Count(); i++){
            Console.WriteLine(listaPImprimir[i]);
        }
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }

    void buscarCliente(){
        Console.Clear();
        int idBuscar = ingresarEntero("Ingres el ID del Cliente que desea buscar");
        Cliente resultado = miTicketera.buscarCliente(idBuscar);
        if (resultado != null){
            Console.WriteLine("Información del cliente:");
            Console.WriteLine("   - DNI: " + resultado.DNI);
            Console.WriteLine("   - Apellido: " + resultado.Apellido);
            Console.WriteLine("   - Nombre: " + resultado.Nombre);
            Console.WriteLine("   - Fecha de Inscripcion: " + resultado.FechaInscripcion);
            Console.WriteLine("   - Tipo de Entrada: " + resultado.TipoEntrada);
            Console.WriteLine("   - Total Abonado: $" + resultado.TotalAbonado);
        } else {
            Console.WriteLine("No existe ningun cliente con ese ID");
        }
        Console.WriteLine("Presione una telca para continuar...");
        Console.ReadKey();
    }

    void cambiarEntrada(){
        Console.Clear();
        int id = ingresarEntero("Ingrese el ID sobre el que quiere modificar la entrada");
        Console.WriteLine("Ingrese a que entrada quiere actualizar");
        Console.WriteLine("1. Dia 1 - $15.000");
        Console.WriteLine("2. Dia 2 - $30.000");
        Console.WriteLine("3. Dia 3 - $10.000");
        Console.WriteLine("4. Full Pass - $40.000");
        int aCambiar = int.Parse(Console.ReadLine());
        while(aCambiar < 1 || aCambiar > 4) aCambiar = ingresarEntero("Opcion Invalida, porfavor ingrese una opcion del menu");
        Dictionary<int, int> dicPrecios = new Dictionary<int, int>(){
        { 1, 15000 },
        { 2, 30000 },
        { 3, 10000 },
        { 4, 40000 }
        };
        if (miTicketera.cambiarEntrada(id, aCambiar, dicPrecios[aCambiar])) Console.WriteLine("Entrada moficada con exito");
        else Console.WriteLine("No se pudo cambiar la entrada");
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }


    int ingresarEntero(string txt){
        Console.WriteLine(txt);
        return int.Parse(Console.ReadLine());;
    }

    string ingresarTexto(string txt){
        Console.WriteLine(txt);
        return Console.ReadLine();
    }
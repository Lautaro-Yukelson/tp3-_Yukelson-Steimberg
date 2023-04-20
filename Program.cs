using System;

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
            break;
        case 2:
            estadisticasEvento();
            break;
        case 3:
            buscarCliente();
            break;
        case 4:
            cambiarEntrada();
            break;
        case 5:
            Console.Clear();
            Console.WriteLine("Saliendo del programa...");
            Environment.Exit(-1);
            break;
    }
}

void nuevaIncripcion(){
    int tipoEntrada, totalABonado = 0;
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
    switch (opcion){
        case 1:
            totalABonado = 15000;
            break;
        case 2:
            totalABonado = 30000;
            break;
        case 3:
            totalABonado = 10000;
            break;
        case 4:
            totalABonado = 40000;
            break;
        case 5:
            Console.Clear();
            Console.WriteLine("Saliendo del programa...");
            Environment.Exit(-1);
            break;
    }  
    tipoEntrada = opcion;
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

    Cliente cliente = new Cliente(dni, apellido, nombre, DateTime.Now, tipoEntrada, totalABonado);
}

void estadisticasEvento(){

}

void buscarCliente(){

}

void cambiarEntrada(){
    
}


int ingresarEntero(string txt){
    Console.WriteLine(txt);
    return int.Parse(Console.ReadLine());;
}

string ingresarTexto(string txt){
    Console.WriteLine(txt);
    return Console.ReadLine();
}
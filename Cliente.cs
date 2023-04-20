using System;
class Cliente{
    public int DNI {get; private set;}
    string Apellido {get; set;}
    string Nombre {get; set;}
    public DateTime FechaInscripcion {get; set;}
    public int TipoEntrada {get; set;}
    public int TotalAbonado {get; set;}

    public Cliente(int dni, string apellido, string nombre, DateTime fi, int te, int ta){
        DNI = dni;
        Apellido = apellido;
        Nombre = nombre;
        FechaInscripcion = fi;
        TipoEntrada = te;
        TotalAbonado = ta;
    }
}

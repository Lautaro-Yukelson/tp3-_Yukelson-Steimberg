using System;
class Ticketera{
    static private Dictionary<int, Cliente> dicClientes;
    static private int ultimoIdEntrada = 1;

    public int devolverUltimoID(){
        return ultimoIdEntrada;
    }
    public int agregarCliente(Cliente cliente){
        int id = ultimoIdEntrada;
        dicClientes.Add(ultimoIdEntrada, cliente);
        ultimoIdEntrada++;
        return id;
    }
    Cliente buscarCliente(int idEntrada){
        if (dicClientes.ContainsKey(idEntrada)) return dicClientes[idEntrada];
        else return null;
    }
    public bool cambiarEntrada(int id, int tipo, int total){
        bool pudo = false;
        if (dicClientes[id].TotalAbonado >= total){
            pudo = true;
            dicClientes[id].TipoEntrada = tipo;
            dicClientes[id].TotalAbonado = total;
        }
        return pudo;
        
    }
    List<string> EstadisticasTicketera(){
        List<string> listaEstadisticas = null;



        return listaEstadisticas;
        
    }
}
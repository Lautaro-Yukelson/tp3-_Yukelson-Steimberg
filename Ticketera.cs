using System;
class Ticketera {
    private Dictionary<int, Cliente> dicClientes = new Dictionary<int, Cliente>();
    public Dictionary<int, int> dicPrecios = new Dictionary<int, int>(){
        { 1, 15000 },
        { 2, 30000 },
        { 3, 10000 },
        { 4, 40000 },
        { 5, 50000 }
    };
    private int ultimoIdEntrada = 1;

    public int devolverUltimoID() {
        return ultimoIdEntrada;
    }

    public int agregarCliente(Cliente cliente) {
        int id = ultimoIdEntrada;
        dicClientes.Add(ultimoIdEntrada, cliente);
        ultimoIdEntrada++;
        return id;
    }

    public Cliente buscarCliente(int idEntrada){
        if (dicClientes.ContainsKey(idEntrada)) return dicClientes[idEntrada];
        else return null;
    }
    public bool cambiarEntrada(int id, int tipo, int importeNueva){
        bool pudo = false;
        if (dicClientes[id].TotalAbonado >= importeNueva){
            pudo = true;
            dicClientes[id].TipoEntrada = tipo;
            dicClientes[id].TotalAbonado = importeNueva;
        }
        return pudo;
        
    }
    public List<string> EstadisticasTicketera(){
        List<string> listaEstadisticas = new List<string>();
        int total;
        int[] tipos = new int[dicPrecios.Count()];
        for (int i = 0; i<tipos.Length; i++){
            tipos[i] = 0; 
        }
        for (int i = 1; i<=dicClientes.Count(); i++){
            tipos[dicClientes[i].TipoEntrada-1]++;
        }
        total = dicClientes.Count();
        listaEstadisticas.Add("Clientes inscriptos: " + total);
        listaEstadisticas.Add("Porcantaje de entradas");
        for (int i = 0; i<dicPrecios.Count()-1; i++){
            listaEstadisticas.Add("   - Dia " + (i+1) + ": " + (tipos[i] * 100 / total) + "%");
        }
        listaEstadisticas.Add("   - Full Pass: " + tipos[dicPrecios.Count()-1] * 100 / total + "%");
        listaEstadisticas.Add("Recaudacion de cada tipo");
        for (int i = 0; i<dicPrecios.Count()-1; i++){
            listaEstadisticas.Add("   - Dia " + (i+1) + ": $" + (tipos[i] * dicPrecios[i+1]));
        }
        listaEstadisticas.Add("   - Full Pass: $" + tipos[dicPrecios.Count()-1] * dicPrecios[dicPrecios.Count()]);
        int recauTotal = 0;
        for (int i = 0; i<tipos.Length; i++){
            recauTotal += tipos[i] * dicPrecios[i+1];
        }
        listaEstadisticas.Add("Recaudacion Total: $" + recauTotal);
        return listaEstadisticas; 
    }
}

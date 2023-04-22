using System;
class Ticketera {
    private Dictionary<int, Cliente> dicClientes = new Dictionary<int, Cliente>();
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
        int tipo1, tipo2, tipo3, tipo4, rTipo1, rTipo2, rTipo3, rTipo4, total;
        tipo1 = tipo2 = tipo3 = tipo4 = rTipo1 = rTipo2 = rTipo3 = rTipo4 = 0;
        total = dicClientes.Count();
        for (int i = 1; i<=dicClientes.Count(); i++){
            switch(dicClientes[i].TipoEntrada){
                case 1:
                    tipo1++;
                    rTipo1 += dicClientes[i].TotalAbonado;
                    break;
                case 2:
                    tipo2++;
                    rTipo2 += dicClientes[i].TotalAbonado;
                    break;
                case 3:
                    tipo3++;
                    rTipo3 += dicClientes[i].TotalAbonado;
                    break;
                case 4:
                    tipo4++;
                    rTipo4 += dicClientes[i].TotalAbonado;
                    break;
            }
        }
        listaEstadisticas.Add("Clientes inscriptos: " + dicClientes.Count());
        listaEstadisticas.Add("Porcantaje de entradas");
        listaEstadisticas.Add("   - Dia 1: " + tipo1 / total * 100 + "%");
        listaEstadisticas.Add("   - Dia 2: " + tipo2 / total * 100 + "%");
        listaEstadisticas.Add("   - Dia 3: " + tipo3 / total * 100 + "%");
        listaEstadisticas.Add("   - Full Pass: " + tipo4 / total * 100 + "%");
        listaEstadisticas.Add("Recaudacion de cada tipo");
        listaEstadisticas.Add("   - Dia 1: $" + rTipo1);
        listaEstadisticas.Add("   - Dia 2: $" + rTipo2);
        listaEstadisticas.Add("   - Dia 3: $" + rTipo3);
        listaEstadisticas.Add("   - Full Pass: $" + rTipo4);
        listaEstadisticas.Add("Recaudacion Total: $" + (rTipo1 + rTipo2 + rTipo3 + rTipo4));
        return listaEstadisticas; 
    }
}

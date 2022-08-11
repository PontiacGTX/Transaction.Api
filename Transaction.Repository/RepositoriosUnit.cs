using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Repository.Repositorios;

namespace Transactions.Repository;

public class RepositoriosUnit
{
    public ClienteRepositorio  ClienteRepositorio { get;  }
    public CuentaRepositorio CuentaRepositorio { get; }
    public CuentasClientesRepository CuentasClientesRepositorio { get;  }
    public MovimientosRepositorio MovimientosRepositorio { get;  }
    public PersonaRepositorio PersonaRepositorio { get;  }
    public TipoMovimientosRepositorio TipoMovimientosRepositorio { get; }
    public TipoDeCuentasRepositorio TipoDeCuentasRepositorio { get; }
    public GeneroRepositorio GeneroRepositorio { get; }
    public PropiedadCuentaRepositorio PropiedadCuentaRepositorio { get; }
    public RepositoriosUnit(ClienteRepositorio clienteRepositorio, CuentaRepositorio cuentaRepositorio, CuentasClientesRepository cuentasClientesRepositorio, MovimientosRepositorio movimientosRepositorio, PersonaRepositorio personaRepositorio, TipoMovimientosRepositorio tipoMovimientosRepositorio, TipoDeCuentasRepositorio tipoDeCuentasRepositorio,GeneroRepositorio generoRepositorio, PropiedadCuentaRepositorio propiedadCuentaRepositorio)
    {
        ClienteRepositorio = clienteRepositorio;
        CuentaRepositorio = cuentaRepositorio;
        CuentasClientesRepositorio = cuentasClientesRepositorio;
        MovimientosRepositorio = movimientosRepositorio;
        PersonaRepositorio = personaRepositorio;
        TipoMovimientosRepositorio = tipoMovimientosRepositorio;
        TipoDeCuentasRepositorio = tipoDeCuentasRepositorio;
        PropiedadCuentaRepositorio = propiedadCuentaRepositorio;
        this.GeneroRepositorio = generoRepositorio;
    }
}

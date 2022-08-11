


using Transactions.Data.Entities;
using Transactions.Data.Models;
using Transactions.Tests.Services;
using Xunit;

namespace Transactions.Test;
public class TransctionsTest
{
    private ClienteServices _ClienteServices;

    public TransctionsTest()
    {
        _ClienteServices =  new ClienteServices(new HttpClient());
    }


    [Theory]
    [InlineData("Jose Lema","Otavalo sn y Principal","098254785",true,2,"1234")]
    [InlineData("Marianela Montalvo","Amazonas y NNUU","09758965",true,1,"5678")]
    [InlineData("Juan Osorio","Amazonas y NNUU","09758965",true,1)]
    public async Task CanRegisterCliente(params object[] data)
    {
        var clienteEmail= $"{data[0].ToString().Replace(" ", "").ToLower()}@gmail.com";
        int edad = new Random().Next(0, 90);
        long id = new Random().NextInt64(1000000, 10000000);
        var cliente = new CrearClienteModel { Nombre = data[0].ToString(), Edad = edad, Email = clienteEmail, Direccion = data[1].ToString(), Telefono = data[2].ToString(), GeneroId = int.Parse(data[4].ToString()), Identificacion = id.ToString(), Contraseña = data[5].ToString() };
        var response =await _ClienteServices.CrearCliente(cliente);
        var cli = response.Data as CreateClienteResponseModel;
        Assert.Equal(200, response.StatusCode);
    }

    [Theory]
    [InlineData("Jose Lema",1,2000,true)]
    [InlineData("Marianela Montalvo",2,100,true)]
    [InlineData("Juan Osorio",1,0,true)]
    [InlineData("Marianela Montalvo",1,540,true)]
    public async Task RegistrarCuentaCliente(params object[] data)
    {
      var clienteResponse = await _ClienteServices.GetClienteByName(data[0].ToString());
      Assert.NotNull(clienteResponse);
      var cliente = clienteResponse.Data as Cliente;
      Assert.NotNull(cliente);
      var crearCuentamodel = new CrearCuentaModel { ClienteId = cliente.Id, SaldoInicial = int.Parse(data[2].ToString()), TipoCuentaId = int.Parse(data[1].ToString()) };
      var response=await  _ClienteServices.CrearCuenta(crearCuentamodel);
      Assert.Equal(201, response.StatusCode);
    }

    [Theory]
    [InlineData("Jose Lema",1,575,2)]
    [InlineData("Marianela Montalvo",2,600,1)]
    [InlineData("Juan Osorio", 1,600,1)]
    [InlineData("Marianela Montalvo", 1, 540, 2)]
    public async Task RealizarMovimientosClientes(params object[] data)
    {
        var cuenta = (await _ClienteServices.GetCuentaByNameAndTipoCuenta(data[0].ToString(), int.Parse(data[1].ToString()))).Data as IList<CuentasClientes>;
        Assert.NotNull(cuenta.Count>0);
        var movimiento = new CrearMovimientoModel { CuentaId = cuenta.FirstOrDefault().CuentaId, TipoMovimientoId = int.Parse(data[3].ToString()) };
        var respuesta =await _ClienteServices.CrearMovimiento(movimiento);
        Assert.NotNull(respuesta);       
        var movimientoRes = respuesta.Data as CrearMovimientoResponseModel;
        Assert.NotNull(movimientoRes);
        Assert.Equal(respuesta.StatusCode, 200);
    }

    [Theory]
    [InlineData("Marianela Montalvo")]
    public async Task GetMovimientos(params object[] data)
    {
        var cli = await _ClienteServices.GetClienteByName(data[0].ToString());
        Assert.NotNull(cli);
        var cliente = cli.Data as Cliente;
        var movResponse =await _ClienteServices.GetMovimientos(cliente.Id,DateTime.Today.Date);
        Assert.NotNull(movResponse);

        Assert.Equal(200, movResponse.StatusCode);
    }
}

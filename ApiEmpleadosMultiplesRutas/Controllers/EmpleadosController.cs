using NugetApiModelsPgs;
using ApiEmpleadosMultiplesRutas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmpleadosMultiplesRutas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Empleado>>>
            GetEmpleados()
        {
            return await this.repo.GetEmpleadosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> FindEmpleado
            (int id)
        {
            return await this.repo.FindEmpleadoAsync(id);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<string>>> Oficios()
        {
            return await this.repo.GetOficiosAsync();
        }

        [HttpGet]
        [Route("[action]/{oficio}")]
        public async Task<ActionResult<List<Empleado>>>
            EmpleadosOficio(string oficio)
        {
            return await this.repo.GetEmpleadosOficioAsync(oficio);
        }

        //SI TENEMOS MAS DE UN PARAMETRO DENTRO DE UN CONTROLLER
        //DEBEMOS MAPEAR LOS DATOS EN EL MISMO ORDEN DEL METODO
        [HttpGet]
        [Route("[action]/{salario}/{iddepartamento}")]
        public async Task<ActionResult<List<Empleado>>>
            EmpleadosSalarioDepartamento(int salario
            , int iddepartamento)
        {
            return await this.repo
                .GetEmpleadosSalarioAsync(salario, iddepartamento);
        }
    }
}

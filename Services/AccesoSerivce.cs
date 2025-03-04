using TODO.ContextDB;
using TODO.Interfaces;
using TODO.Models.Dtos;

namespace TODO.Services
{
    class AccesoSerivce : IAccesible
    {
        private readonly TodoContext _context;

        public AccesoSerivce(TodoContext context)
        {
            this._context = context;
        }

        public async Task Login(RegistroDTO modelo)
        {
            throw new NotImplementedException();
        }

        public async Task Registro(RegistroDTO modelo)
        {
            throw new NotImplementedException();
        }
    }
}

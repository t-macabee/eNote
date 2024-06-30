using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;

namespace eNote.Services.Services
{
    public class InstrumentService : IInstrumentService
    {
        public DataContext _context { get; set; }
        public IMapper _mapper { get; set; }

        public InstrumentService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Instrumenti> GetAll()
        {
            var list = _context.Instrumenti.ToList();

            return _mapper.Map<List<Model.Instrumenti>>(list);
        }
    }
}

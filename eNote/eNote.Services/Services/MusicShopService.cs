using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;

namespace eNote.Services.Services
{
    public class MusicShopService : IMusicShopService
    {
        public DataContext _context { get; set; }
        public IMapper _mapper { get; set; }

        public MusicShopService(DataContext context, IMapper mapper) 
        {
            _context = context;  
            _mapper = mapper;
        }

        public List<Model.MusicShop> GetAll()
        {
            var list = _context.MusicShops.ToList();

            return _mapper.Map<List<Model.MusicShop>>(list);
        }

        public MusicShop Insert(MusicShop request)
        {
            throw new NotImplementedException();
        }
    }
}

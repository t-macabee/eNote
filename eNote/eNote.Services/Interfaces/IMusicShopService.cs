using eNote.Services.Database;

namespace eNote.Services.Interfaces
{
    public interface IMusicShopService
    {
        List<Model.MusicShop> GetAll();
        MusicShop Insert(MusicShop request);
    }
}

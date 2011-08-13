using System.Linq;

namespace auctionbaseUI.Models
{
    public interface IMyRepo
    {
        IQueryable<tblVehicle> Vehicles { get; }
        void Add<T>(T item);
        void Delete<T>(T item);
        void SaveChanges();
        string GetSetName<T>();
    }
}
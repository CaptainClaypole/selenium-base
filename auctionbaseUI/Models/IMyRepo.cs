using System.Linq;

namespace auctionbaseUI.Models
{
    public interface IMyRepo
    {
        
        IQueryable<tblVehicle> Vehicles { get; }
        IQueryable<tblSearchSession>  SearchSessions{ get; }
        IQueryable<tblVehicleTypeGeneral> GeneralTypes { get; }
        IQueryable<tblVehicleTypeDefined> DefinedTypes { get; }
        IQueryable<HTMLVehicle> GetLiteaceTownace { get; }
        IQueryable<tblHtmlRow> HtmlRows { get; }
        IQueryable<tblHtml> Htmls { get; } 

        void Add<T>(T item);
        void Delete<T>(T item);
        void SaveChanges();
        string GetSetName<T>();

    }
}
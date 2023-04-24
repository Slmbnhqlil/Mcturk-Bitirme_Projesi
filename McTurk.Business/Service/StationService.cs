using McTurk.Business;
using McTurk.DataAccess;
using McTurk.Domain;
using System.Diagnostics;

namespace McTurk.Business.Service
{
    public class StationService
    {
        private McTurkContext _context = new McTurkContext();

        //public IEnumerable<StationDto> GetAll()
        //{
        //    try
        //    {
        //        return _context.Stations.Select(MapToDto).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return new List<StationDto>();
        //    }
        //}
        //public StationDto GetById(int id)
        //{
        //    try
        //    {
        //        var entity = _context.Stations.FirstOrDefault(_ => _.Id == id);
        //        if (entity != null)
        //        {
        //            var dto = MapToDto(entity);
        //            return dto;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.TraceError(ex.ToString());
        //        return null;
        //    }
        //}

        public CommandResult Create(StationDto stationDto)
        {
            if (stationDto == null)
                throw new ArgumentException(nameof(stationDto));
            try
            {
                var entity = MapToEntity(stationDto);

                _context.Stations.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }

        public CommandResult Update(StationDto stationDto)
        {
            try
            {
                var entity = MapToEntity(stationDto);

                _context.Stations.Update(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }

        public CommandResult Delete(StationDto stationDto)
        {
            var entity = MapToEntity(stationDto);
            try
            {
                _context.Stations.Remove(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex);
            }
        }

        public static StationDto? MapToDto(StationDto station)
        {
            StationDto dto = null;
            if (station != null)
            {
                dto = new StationDto()
                {
                    Id = station.Id,
                    Name = station.Name
                };
            }
            return dto;
        }
        internal static Station? MapToEntity(StationDto station)
        {
            Station entity = null;

            if (station != null)
            {
                entity = new Station()
                {
                    Id = station.Id,
                    Name = station.Name
                };
            }
            return entity;
        }
    }
}

using McTurk.Business;
using McTurk.DataAccess;
using McTurk.Domain;
using System.Diagnostics;

namespace McTurk.Business.Service
{
    public class VehicleService
    {
        private McTurkContext _context = new McTurkContext();

        //public IEnumerable<VehicleDto> GetAll()
        //{
        //    try
        //    {
        //        return _context.Vehicles.Select(MapToDto).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return new List<VehicleDto>();
        //    }
        //}
        //public VehicleDto GetById(int id)
        //{
        //    try
        //    {
        //        var entity = _context.Vehicles.FirstOrDefault(_ => _.Id == id);
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

        public CommandResult Create(VehicleDto vehicleDto)
        {
            if (vehicleDto == null)
                throw new ArgumentException(nameof(vehicleDto));
            try
            {
                var entity = MapToEntity(vehicleDto);

                _context.Vehicles.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }

        public CommandResult Update(VehicleDto vehicleDto)
        {
            try
            {
                var entity = MapToEntity(vehicleDto);

                _context.Vehicles.Update(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }

        public CommandResult Delete(VehicleDto vehicleDto)
        {
            var entity = MapToEntity(vehicleDto);
            try
            {
                _context.Vehicles.Remove(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex);
            }
        }

        public static VehicleDto? MapToDto(VehicleDto vehicle)
        {
            VehicleDto dto = null;
            if (vehicle != null)
            {
                dto = new VehicleDto()
                {
                    Id = vehicle.Id,
                    AppointmentReportsId = vehicle.AppointmentReportsId,
                    PlateNumber = vehicle.PlateNumber,
                    RegistrationDate = vehicle.RegistrationDate,
                    RegistrationNumber = vehicle.RegistrationNumber,
                    UsersId = vehicle.UsersId,
                };
            }
            return dto;
        }
        internal static Vehicle? MapToEntity(VehicleDto vehicle)
        {
            Vehicle entity = null;

            if (vehicle != null)
            {
                entity = new Vehicle()
                {
                    Id = vehicle.Id,
                    AppointmentReportsId = vehicle.AppointmentReportsId,
                    PlateNumber = vehicle.PlateNumber,
                    RegistrationDate = vehicle.RegistrationDate,
                    RegistrationNumber = vehicle.RegistrationNumber,
                    UsersId = vehicle.UsersId,
                };
            }
            return entity;
        }
    }
}

using McTurk.Business;
using McTurk.DataAccess;
using McTurk.Domain;
using System.Diagnostics;

namespace McTurk.Business.Service
{
    public class VehicleTypeTypeService
    {
        private McTurkContext _context = new McTurkContext();
        public CommandResult Create(VehicleTypeDto vehicleTypeDto)
        {
            if (vehicleTypeDto == null)
                throw new ArgumentException(nameof(vehicleTypeDto));
            try
            {
                var entity = MapToEntity(vehicleTypeDto);

                _context.VehicleTypes.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }

        public CommandResult Delete(VehicleTypeDto vehicleTypeDto)
        {
            var entity = MapToEntity(vehicleTypeDto);
            try
            {
                _context.VehicleTypes.Remove(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex);
            }
        }

        public static VehicleTypeDto? MapToDto(VehicleTypeDto vehicleType)
        {
            VehicleTypeDto dto = null;
            if (vehicleType != null)
            {
                dto = new VehicleTypeDto()
                {
                    Id = vehicleType.Id,
                    Name = vehicleType.Name
                };
            }
            return dto;
        }
        internal static VehicleType? MapToEntity(VehicleTypeDto vehicleType)
        {
            VehicleType entity = null;

            if (vehicleType != null)
            {
                entity = new VehicleType()
                {
                    Id = vehicleType.Id,
                    Name = vehicleType.Name
                };
            }
            return entity;
        }
    }
}

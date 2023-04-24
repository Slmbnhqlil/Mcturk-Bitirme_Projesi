using McTurk.Business;
using McTurk.DataAccess;
using McTurk.Domain;
using System.Diagnostics;

namespace McTurk.Business.Service
{
    public class AppointmentService
    {
        private McTurkContext _context = new McTurkContext();

        public CommandResult Create(AppointmentReportDto appointmentReportDto)
        {
            if (appointmentReportDto == null)
                throw new ArgumentException(nameof(appointmentReportDto));
            try
            {
                var entity = MapToEntity(appointmentReportDto);

                _context.AppointmentReports.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }

        public CommandResult Update(AppointmentReportDto appointmentReportDto)
        {
            try
            {
                var entity = MapToEntity(appointmentReportDto);

                _context.AppointmentReports.Update(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }

        public CommandResult Delete(AppointmentReportDto appointmentReportDto)
        {
            var entity = MapToEntity(appointmentReportDto);
            try
            {
                _context.AppointmentReports.Remove(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex);
            }
        }

        public static AppointmentReportDto? MapToDto(AppointmentReportDto appointmentReport)
        {
            AppointmentReportDto dto = null;
            if (appointmentReport != null)
            {
                dto = new AppointmentReportDto()
                {
                    Id = appointmentReport.Id,
                    StationId = appointmentReport.StationId,
                    TransactionDate = appointmentReport.TransactionDate,
                    UserId = appointmentReport.UserId,
                    VehicleTypeId = appointmentReport.VehicleTypeId
                };
            }
            return dto;
        }
        internal static AppointmentReport? MapToEntity(AppointmentReportDto appointmentReport)
        {
            AppointmentReport entity = null;

            if (appointmentReport != null)
            {
                entity = new AppointmentReport()
                {
                    Id = appointmentReport.Id,
                    StationId = appointmentReport.StationId,
                    TransactionDate = appointmentReport.TransactionDate,
                    UserId = appointmentReport.UserId,
                    VehicleTypeId = appointmentReport.VehicleTypeId
                };
            }
            return entity;
        }
    }
}

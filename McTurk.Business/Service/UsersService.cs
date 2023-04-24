using McTurk.Business;
using McTurk.DataAccess;
using McTurk.Domain;
using System.Diagnostics;

namespace McTurk.Business.Service
{
    public class UsersService
    {
        private McTurkContext _context = new McTurkContext();

        //public IEnumerable<UsersDto> GetAll()
        //{
        //    try
        //    {
        //        return _context.Userss.Select(MapToDto).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return new List<UsersDto>();
        //    }
        //}
        //public UsersDto GetById(int id)
        //{
        //    try
        //    {
        //        var entity = _context.Userss.FirstOrDefault(_ => _.Id == id);
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

        public CommandResult Create(UsersDto usersDto)
        {
            if (usersDto == null)
                throw new ArgumentException(nameof(usersDto));
            try
            {
                var entity = MapToEntity(usersDto);

                _context.Users.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }

        public CommandResult Update(UsersDto usersDto)
        {
            try
            {
                var entity = MapToEntity(usersDto);

                _context.Users.Update(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }

        public CommandResult Delete(UsersDto usersDto)
        {
            var entity = MapToEntity(usersDto);
            try
            {
                _context.Users.Remove(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex);
            }
        }

        public static UsersDto? MapToDto(UsersDto users)
        {
            UsersDto dto = null;
            if (users != null)
            {
                dto = new UsersDto()
                {
                    Id = users.Id,
                    PhoneNumber = users.PhoneNumber,
                    IdentityNumber = users.IdentityNumber,
                    VehicleId = users.VehicleId,
                    Email = users.Email,
                    FullName = users.FullName
                };
            }
            return dto;
        }
        internal static Users? MapToEntity(UsersDto users)
        {
            Users entity = null;

            if (users != null)
            {
                entity = new Users()
                {
                    Id = users.Id,
                    PhoneNumber = users.PhoneNumber,
                    IdentityNumber = users.IdentityNumber,
                    VehicleId = users.VehicleId,
                    Email = users.Email,
                    FullName = users.FullName
                };
            }
            return entity;
        }
    }
}

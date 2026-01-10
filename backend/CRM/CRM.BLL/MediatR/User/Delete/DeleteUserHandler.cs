using Ardalis.Result;
using CRM.DAL.Repositories.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.BLL.MediatR.Client.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(
            DeleteUserCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                await _userRepository.DeleteAsync(request.Id);
                return Result.Success();
            }
            catch (KeyNotFoundException knf)
            {
                return Result.NotFound(knf.Message);
            }
            catch (Exception ex)
            {
                return Result.Error($"Failed to delete user: {ex.Message}");
            }

            
        }
    }
}

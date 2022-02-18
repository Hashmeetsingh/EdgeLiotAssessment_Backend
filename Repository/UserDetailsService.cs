using EdgeLiotAssessment.Interfaces;
using EdgeLiotAssessment.Models;

namespace EdgeLiotAssessment.Repository
{
    public class UserDetailsService : IUserDetailsService
    {
        private readonly UserDbContext? _context;
        public UserDetailsService(UserDbContext userDbContext)
        {
            _context = userDbContext;
        }

        public ResponseModel SaveAndUpdateUserDetails(UserDetails userDetails) 
        {
            ResponseModel responseModel = new ResponseModel();
            User? user = null;
            Messages? messages = null;
            try
            {
                user = _context.Find<User>(userDetails.User);
                if(user != null && user?.UserID != null)
                {
                    user.DateLastSeen = DateTime.Now;
                    _context.Update(user);
                    responseModel.IsSuccess = true;
                    responseModel.Message = "User details updated successfully";
                }
                else
                {
                    user = new User();
                    user.UserID = userDetails.User;
                    user.UserName = userDetails.UserName;
                    user.Email = userDetails.Email;
                    user.DateCreated = userDetails.Date;
                    user.DateLastSeen = DateTime.Now;
                    _context.Add(user);
                    responseModel.IsSuccess = true;
                    responseModel.Message = "User details saved successfully";
                }
                messages = new Messages();
                messages.UserID = userDetails.User; 
                messages.ReceivedAt = DateTime.Now;
                messages.Payload = userDetails.Payload;
                _context.Add(messages);
                _context.SaveChanges();
                return responseModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResponseModel GetUserdetails()
        {
            ResponseModel responseModel = new ResponseModel(); 
            try
            {
                responseModel.Userdtls = (from user in _context.User
                               join messages in _context.Messages
                               on user.UserID equals messages.UserID

                               group new { user, messages } by new { user.UserName, user.DateLastSeen, messages.UserID } into result

                               select new Userdtls
                               {
                                   UserName = result.Key.UserName,
                                   DateLastSeen = result.Key.DateLastSeen.ToString(),
                                   userCount = result.Count()
                               }).ToList();

                responseModel.IsSuccess = true;
                responseModel.Message = "User details fetched successfully";
                return responseModel;
            }
            catch(Exception)
            {
                throw;
            }            
        }
    }
}

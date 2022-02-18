namespace EdgeLiotAssessment.Interfaces
{
    public interface IUserDetailsService
    {
        public ResponseModel SaveAndUpdateUserDetails(UserDetails userDetails);
        public ResponseModel GetUserdetails();
    }
}

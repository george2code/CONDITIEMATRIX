namespace HCalc.WebUI.Utils
{
    public class UserInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserImage { get; set; }
        public string Email { get; set; }

        public string GetFullName()
        {
            var result = Email;

            if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
                result = string.Format("{0} {1}", FirstName, LastName);

            return result;
        }

        public string GetAvatar()
        {
            if (!string.IsNullOrEmpty(UserImage))
            {
                return string.Format("<img class=\"img-circle\" src=\"/Images/avatar/{0}\" alt=\"{1}\" />",
                    UserImage,
                    Email);
            }

            return string.Format("<img class=\"img-circle\" src=\"/Images/avatar/{0}\" alt=\"{1}\" />",
                    "Koala.jpg",
                    Email);
        }
    }
}
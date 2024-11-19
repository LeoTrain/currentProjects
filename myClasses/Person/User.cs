namespace MyClasses
{
   public class User                            
   {
       private int _id;
       public int ID {
           get { return _id; } 
           private set
           {
               if (value < 0) throw new ArgumentException("ID must be more or equal to 0");
               _id = value;
           }
       }
       public string Username { get; private set; }
       public string Password { get; private set; }
       public Email Email { get; private set; }

       public User(int id, string username, string password, Email email)
       {
           ID = id;
           Username = username;
           Password = password;
           Email = email;
       }
   }
}

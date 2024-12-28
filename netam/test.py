from Classes.User import User
from Classes.DataBaseManager import DataBaseManager

def test():
    mng = DataBaseManager("test.db")
    users = mng.get_all_users()
    for user in users:
        print(user.fullname)



test()

